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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AttendanceManagementBAL;

namespace AttendanceManagementWPF.screens.Admin
{
    /// <summary>
    /// Interaction logic for EmployeeDetailsPage.xaml
    /// </summary>
    public partial class EmployeeDetailsPage : Page
    {

        string _employeeID;

        public EmployeeDetailsPage(string employeeId)
        {
            InitializeComponent();
            _employeeID = employeeId;

            try
            {
                AttendanceBALClass bal = new AttendanceBALClass();
                DataTable dataTable = new DataTable();
                dataTable = bal.GetEmployeeInfoBAL(_employeeID);

                int mgrID;

                if(dataTable.Rows[0]["ManagerId"].ToString().Length <= 0)
                {
                    mgrID = 0;
                } else
                {
                    mgrID = int.Parse(dataTable.Rows[0]["ManagerId"].ToString());
                }

                txtEmployeeID.Content = dataTable.Rows[0]["EmployeeId"].ToString();
                txtEmployeeName.Content = dataTable.Rows[0]["FirstName"].ToString() + " " + dataTable.Rows[0]["LastName"].ToString();
                txtContactNo.Content = dataTable.Rows[0]["ContactNo"].ToString();
                txtEmail.Content = dataTable.Rows[0]["Email"].ToString();
                txtDateofbirth.Content = dataTable.Rows[0]["DateOfBirth"].ToString().Substring(0, 10);
                txtJobTitle.Content = dataTable.Rows[0]["JobTitle"].ToString();
                txtManagerId.Content = mgrID <= 0 ? "Null" : mgrID.ToString();

                int roleID = int.Parse(dataTable.Rows[0]["RoleId"].ToString());

                txtRole.Content = roleID == 2 ? "Manager" :
                   roleID == 1 ? "Admin" : "Employee";
            } catch (Exception exec)
            {
                MessageBox.Show(exec.StackTrace);
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
