using AttendanceManagementBAL;
using System;
using System.Collections.Generic;
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
using Entities;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for RegisterEmployeeWindow.xaml
    /// </summary>
    public partial class RegisterEmployeeWindow : Window
    {
        AttendanceBALClass attendanceBALClass;

        ObservableCollection<Manager> managers;

        public RegisterEmployeeWindow()
        {
            InitializeComponent();

            attendanceBALClass = new AttendanceBALClass();

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

            foreach (Manager manager in managers)
            {

                txtManagerID.Items.Add(
                    new ComboBoxItem
                    {
                        Content = manager.FirstName + " " + manager.LastName,
                        Tag = manager.EmpId.ToString(),
                        TabIndex = manager.EmpId
                    }
                    );
            }

            txtDateOfBirth.DisplayDateStart = DateTime.Now.AddYears(-60);
            txtDateOfBirth.DisplayDateEnd = DateTime.Now.AddYears(-18);

        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {

            string firstName, lastName, contactNo, email, jobTitle, password, role, confirmPassword;
            int managerID;
            DateTime dateOfBirth;

            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            contactNo = txtContactNo.Text;
            email = txtEmail.Text;
            jobTitle = txtJobTitle.Text;
            password = txtPassword.Password;
            confirmPassword = txtConfirmPassword.Password;
            dateOfBirth = txtDateOfBirth.SelectedDate.HasValue ? 
                txtDateOfBirth.SelectedDate.Value.Date : DateTime.Now;
            managerID = txtManagerID.SelectedItem != null ? 
                int.Parse(((ComboBoxItem)txtManagerID.SelectedItem).Tag.ToString()) : 0;

            try
            {
                int result, empID;

                if(managerID ==  0)
                {
                    MessageBox.Show("Manager Id is mandatory.");
                    return;
                }

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


                if (result == 1)
                {

                    new AttendanceBALClass().AddEmpidandpasswordBAL(empID, password);

                    MessageBox.Show("Your Employee ID is " + empID.ToString() +
                        " Make a note of it for future authentication");

                    new WelcomeWindow(firstName + " " + lastName, empID, 3).Show();
                    this.Close();
                    return;
                }

                MessageBox.Show("Something went wrong. Please try again later.");

            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void loginEmployee_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}
