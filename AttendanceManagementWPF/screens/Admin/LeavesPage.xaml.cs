using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AttendanceManagementBAL;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for LeavesPage.xaml
    /// </summary>
    public partial class LeavesPage : Page
    {

        DataTable dataTable;

        public LeavesPage()
        {
            getEmployeeLeaves();
        }

        void getEmployeeLeaves()
        {
            try
            {
                InitializeComponent();
                dataTable = new AttendanceBALClass().AdminViewAllLeaveBAL();
                gridLeaves.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtSearchEmployee_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            DataTable filteredTable = new DataTable();
            filteredTable.Clear();

            filteredTable.Columns.Add("EmployeeId");
            filteredTable.Columns.Add("Employee Name");
            filteredTable.Columns.Add("Start Date");
            filteredTable.Columns.Add("End Date");
            filteredTable.Columns.Add("NoOfDays");
            filteredTable.Columns.Add("Reason");

            if (textBox != null || textBox.Text.Length > 0)
            {
                string searchText = textBox.Text;

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row[1].ToString().ToLower().Contains(searchText.ToLower()))
                    {
                        DataRow dataRow = filteredTable.NewRow();

                        dataRow["EmployeeId"] = row["EmployeeId"];
                        dataRow["Employee Name"] = row["Employee Name"];
                        dataRow["Start Date"] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(row["Start Date"].ToString()));
                        dataRow["End Date"] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(row["End Date"].ToString()));
                        dataRow["NoOfDays"] = row["NoOfDays"];
                        dataRow["Reason"] = row["Reason"];

                        filteredTable.Rows.Add(dataRow);
                    }
                }

                gridLeaves.ItemsSource = filteredTable.DefaultView;

                return;
            }

            getEmployeeLeaves();

        }
    }

}
