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

namespace AttendanceManagementWPF.screens.User
{
    /// <summary>
    /// Interaction logic for AttendanceEmployee.xaml
    /// </summary>
    public partial class AttendanceEmployee : Page
    {
        int _employeeID;

        AttendanceBALClass bal;

        public AttendanceEmployee(int employeeID)
        {
            InitializeComponent();
            _employeeID = employeeID;
            bal = new AttendanceBALClass();
            
            try
            {
                gridEmployeeAttendance.ItemsSource = bal.EmployeeViewAttendanceBAL(_employeeID).DefaultView;
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }
        private void addAttendanceButton_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new AddAttendanceUser(_employeeID, 3));
        }

        private void deleteAttendanceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

                if(!dataRowView["AttendanceStatus"].ToString().Equals("Pending"))
                {
                    MessageBox.Show("Your attendance is accepted for the day.\nYou cannot edit/delete");
                    return;
                }

                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure want to delete Attendance",
                     "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {

                    int success;

                    bal.DeleteAttendanceBAL(_employeeID, int.Parse(dataRowView["ProjectId"].ToString()),
                        out success);

                    if(success == 0)
                    {
                        MessageBox.Show("You cannot delete this record. Since this is your first record.");
                        return;
                    } 

                    gridEmployeeAttendance.ItemsSource = bal.EmployeeViewAttendanceBAL(_employeeID).DefaultView;

                    return;
                }
                    
            } catch(Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }
    }
}
