using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AttendanceManagementBAL;
using Entities;

namespace AttendanceManagementWPF.screens.Admin
{
    /// <summary>
    /// Interaction logic for AddEmployeeToProjectAdmin.xaml
    /// </summary>
    public partial class AssignEmployeeToProjectAdmin : Window
    {

        AttendanceBALClass bal;

        DataTable dataTable;

        int _projectID;

        public AssignEmployeeToProjectAdmin(int projectID)
        {
            InitializeComponent();
            bal = new AttendanceBALClass();

            _projectID = projectID;

            getEmployees();

            gridEmployeeDetails.ItemsSource = dataTable.DefaultView;

        }

        private void getEmployees()
        {
            try
            {
                dataTable = bal.AssignEmployeeBAL(_projectID);
            } catch(Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }

        private void txtSearchEmployee_TextChanged(object sender, TextChangedEventArgs e)
        {
            getEmployees();

            TextBox textBox = sender as TextBox;

            DataTable filteredTable = new DataTable();
            filteredTable.Clear();

            filteredTable.Columns.Add("EmployeeId");
            filteredTable.Columns.Add("EmployeeName");
            filteredTable.Columns.Add("ContactNo");
            filteredTable.Columns.Add("JobTitle");

            if (textBox != null || textBox.Text.Length > 0)
            {
                string searchText = textBox.Text;

                foreach (DataRow row in dataTable.Rows)
                {
                    if(row[1].ToString().ToLower().Contains(searchText.ToLower()))
                    {
                        DataRow dataRow = filteredTable.NewRow();

                        dataRow["EmployeeId"] = row["EmployeeId"];
                        dataRow["EmployeeName"] = row["EmployeeName"];
                        dataRow["ContactNo"] = row["ContactNo"];
                        dataRow["JobTitle"] = row["JobTitle"];

                        filteredTable.Rows.Add(dataRow);
                    }
                }

                gridEmployeeDetails.ItemsSource =
                    filteredTable.DefaultView;
            } else
            {
                getEmployees();
                gridEmployeeDetails.ItemsSource = dataTable.DefaultView;
            }
        }

        private void AssignEmployee_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

                int result;

                bal.AssignProjectBAL(
                    new ProjectAttendance
                    {
                        EmployeeId = int.Parse(dataRowView.Row[0].ToString()),
                        ProjectId = _projectID
                    }, out result
                    );

                if (result == 1)
                {

                    MessageBox.Show($"Employee with ID: {dataRowView.Row[0]}.\nAdded succesfully",
                        "Added Scuccesfully");

                    getEmployees();
                    gridEmployeeDetails.ItemsSource = dataTable.DefaultView;
                    txtSearchEmployee.Text = "";

                    return;
                }

                MessageBox.Show("Failed to Add employee",
                        "Failed");
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }
    }
}
