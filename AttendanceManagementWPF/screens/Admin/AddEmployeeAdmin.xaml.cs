using AttendanceManagementBAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using AttendanceManagementWPF.screens.Admin;

namespace AttendanceManagementWPF.screens.Admin
{
    /// <summary>
    /// Interaction logic for AddEmployeeAdmin.xaml
    /// </summary>
    public partial class AddEmployeeAdmin : Page
    {


        AttendanceBALClass attendanceBALClass;

        ObservableCollection<Manager> managers;

        public AddEmployeeAdmin()
        {
            InitializeComponent();
            attendanceBALClass = new AttendanceBALClass();

            try
            {
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

                txtManagerID.Items.Add(
                new ComboBoxItem
                {
                    Content = 0 + " " + "None",
                    Tag = 0,
                    TabIndex = 0
                });

                foreach (Manager manager in managers)
                {

                    txtManagerID.Items.Add(
                        new ComboBoxItem
                        {
                            Content = manager.EmpId + " " + manager.FirstName + " " + manager.LastName,
                            Tag = manager.EmpId,
                            TabIndex = manager.EmpId
                        }
                        );
                }
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

            txtDateOfBirth.DisplayDateStart = DateTime.Now.AddYears(-60);
            txtDateOfBirth.DisplayDateEnd = DateTime.Now.AddYears(-18);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EmployeesPage());
        }

        void addEmployee()
        {
            string firstName, lastName, contactNo, email, jobTitle, password, confirmPassword;
            int managerID;
            DateTime dateOfBirth;

            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            contactNo = txtContactNo.Text;
            email = txtEmail.Text;
            jobTitle = txtJobTitle.Text;
            password = txtPassword.Password;
            confirmPassword = txtConfirmPassword.Password;
            dateOfBirth = txtDateOfBirth.SelectedDate.Value.Date;
            managerID = txtManagerID.SelectedItem != null ?
                int.Parse(((ComboBoxItem)txtManagerID.SelectedItem).Tag.ToString()) : 0;

            int result, empID;

            attendanceBALClass.AddEmployeeBAL(

                new EmployeeDetails
                {
                    FirstName = firstName,
                    LastName = lastName,
                    ContactNo = contactNo,
                    Email = email,
                    JobTitle = jobTitle,
                    ManagerId = managerID,
                    DateOfBirth = dateOfBirth,
                    RoleId = 3,
                }, password, confirmPassword, out result, out empID
                );

            new AttendanceBALClass().AddEmpidandpasswordBAL(empID, password);

            if (result == 1)
            {
                MessageBox.Show("Added Successfully.\nEmployee Added With Employee ID : " + empID, "Added Successfully");
                this.NavigationService.Navigate(new EmployeesPage());
                return;
            }

            MessageBox.Show("Something went wrong. Please try again later.");

        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                addEmployee();
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed!");
            }
        }
    }
}
