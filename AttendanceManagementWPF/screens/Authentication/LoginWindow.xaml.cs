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
using AttendanceManagementBAL;
using Entities;
using Exceptions;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();

            txtEmployeeID.Focus();

        }

        void login()
        {
            string empIDText = txtEmployeeID.Text;
            string password = txtPassword.Password.ToString();

            string employeeIDError;

            bool validEmpID;

            int employeeID;

            new Utils().EmployeeIDValidation(empIDText, out validEmpID, out employeeID, 
                out employeeIDError);

            int result;
            /// Result
            /// 0 - Failed
            /// 1 - Success

            int roleId;
            /// Role IDs
            /// 1 - Admin
            /// 2 - Manager
            /// 3 - Employee

            string empName;

            if (!validEmpID)
            {
                MessageBox.Show(employeeIDError,
                    "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            new AttendanceBALClass().CheckCredentialsBAL(
                new LoginCredentials
                {
                    EmployeeId = employeeID,
                    LoginPassword = password
                },
                out result, out roleId, out empName);


            if (result == 1)
            {

                new WelcomeWindow(empName, employeeID, roleId).Show();
                this.Close();

                return;

            }
            MessageBox.Show("Invalid Username or Password.", "Login Failed");

        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {

            new DashboardAdminWindow().Show();
            this.Close();

            try
            {
                login();
            } catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void registerEmployee(object sender, RoutedEventArgs e)
        {
            RegisterEmployeeWindow registerEmployee = new RegisterEmployeeWindow();
            registerEmployee.Show();
            this.Close();
        }
    }
}
