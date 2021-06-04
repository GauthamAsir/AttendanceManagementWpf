using AttendanceManagementBAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AttendanceManagementWPF.screens.Admin
{
    /// <summary>
    /// Interaction logic for UpdateEmployeeAdmin.xaml
    /// </summary>
    public partial class UpdateEmployeeAdmin : Page
    {

        int updateEmployeeId;

        AttendanceBALClass attendanceBALClass;

        ObservableCollection<Manager> managers;

        public UpdateEmployeeAdmin(int employeeID)
        {
            InitializeComponent();

            updateEmployeeId = employeeID;
            lblemployeeId.Content = $"Employee ID : " + updateEmployeeId;

            attendanceBALClass = new AttendanceBALClass();

            DataTable dataTable = new DataTable();
            dataTable = attendanceBALClass.GetEmployeeInfoBAL(updateEmployeeId.ToString());

            SqlDataReader managerReader = attendanceBALClass.GetManagerNameBAL();

            managers = new ObservableCollection<Manager>();

            while (managerReader.Read())
            {

                managers.Add(new Manager
                {
                    EmpId = int.Parse(managerReader[0].ToString()),
                    FirstName = managerReader[1].ToString(),
                    LastName = managerReader[2].ToString()
                });

            }

            string mgrID = dataTable.Rows[0]["ManagerId"].ToString();

            txtManagerID.Items.Add(
                new ComboBoxItem
                {
                    Content = 0 + " " + "None",
                    Tag = 0,
                    IsSelected = mgrID.Equals("0")  || mgrID.Length <= 0,
                    TabIndex = 0
                });

            foreach (Manager manager in managers)
            {

                if(manager.EmpId == updateEmployeeId)
                {
                    continue;
                }

                txtManagerID.Items.Add(new ComboBoxItem
                {
                    Content = manager.EmpId + " " + manager.FirstName + " " + manager.LastName,
                    Tag = manager.EmpId,
                    IsSelected = mgrID.Equals(manager.EmpId.ToString()),
                    TabIndex = manager.EmpId
                });

            }

            int roleID = int.Parse(dataTable.Rows[0]["RoleId"].ToString());

            txtDateOfBirth.DisplayDateStart = DateTime.Now.AddYears(-60);
            txtDateOfBirth.DisplayDateEnd = DateTime.Now.AddYears(-18);

            txtFirstName.Text = dataTable.Rows[0]["FirstName"].ToString();

            txtLastName.Text = dataTable.Rows[0]["LastName"].ToString();
            txtContactNo.Text = dataTable.Rows[0]["ContactNo"].ToString();
            txtEmail.Text = dataTable.Rows[0]["Email"].ToString();
            txtDateOfBirth.Text = dataTable.Rows[0]["DateOfBirth"].ToString().Substring(0, 10);
            txtJobTitle.Text = dataTable.Rows[0]["JobTitle"].ToString();
            txtManagerID.SelectedItem = dataTable.Rows[0]["ManagerId"].ToString();

            txtDateOfBirth.Visibility = Visibility.Collapsed;

            if(roleID == 2)
            {
                txtRole.IsEnabled = false;
            }

            txtRole.SelectedIndex = roleID == 2 ? 1 : 0;

        }

        void update()
        {
            string firstName, lastName, contactNo, email, jobTitle;
            int managerID, role;
            DateTime dateOfBirth;

            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            contactNo = txtContactNo.Text;
            email = txtEmail.Text;
            jobTitle = txtJobTitle.Text;
            role = txtRole.SelectedItem != null ? txtRole.SelectedIndex : -1;
            dateOfBirth = txtDateOfBirth.SelectedDate.Value.Date;
            managerID = txtManagerID.SelectedItem != null ?
                int.Parse(((ComboBoxItem)txtManagerID.SelectedItem).Tag.ToString()) : 0;


            int result;
            int roleId = role == 0 ? 3 : 2;

            attendanceBALClass.UpdateEmployeeBAL(

                new EmployeeDetails
                {
                    EmployeeId = updateEmployeeId,
                    FirstName = firstName,
                    LastName = lastName,
                    ContactNo = contactNo,
                    Email = email,
                    JobTitle = jobTitle,
                    ManagerId = managerID,
                    DateOfBirth = dateOfBirth,
                    RoleId = roleId,
                }, out result
                );


            if (result == 1)
            {
                MessageBox.Show("Updated Successfully Done.", "Update Successful");
                this.NavigationService.Navigate(new EmployeesPage());
                return;
            }

            MessageBox.Show("Something went wrong. Please try again later.");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
