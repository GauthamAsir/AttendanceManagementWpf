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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AttendanceManagementBAL;
using System.Data;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for AttendanceUser.xaml
    /// </summary>
    public partial class AttendanceManager : Page
    {

        int _employeeID;

        AttendanceBALClass attendanceBALClass;

        public AttendanceManager(int employeeID)
        {
            InitializeComponent();
            _employeeID = employeeID;

            attendanceBALClass = new AttendanceBALClass();
            getPendingAttendance();
            
        }

        void getPendingAttendance()
        {
            try
            {
                DataTable dt = attendanceBALClass.ManagerViewPendingAttendanceRequestBAL(_employeeID);
                gridManagerAttendance.ItemsSource = dt.DefaultView;
            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }

        private void present_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            try
            {
                attendanceBALClass.UpdateAttendanceManagerBAL(int.Parse(dataRowView["EmployeeId"].ToString()),
                int.Parse(dataRowView["ProjectId"].ToString()), 1);
                getPendingAttendance();
            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }

        private void absent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                attendanceBALClass.UpdateAttendanceManagerBAL(int.Parse(dataRowView["EmployeeId"].ToString()),
                    int.Parse(dataRowView["ProjectId"].ToString()), 2);
                getPendingAttendance();
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }

        private void addAttendanceButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddAttendanceUser(_employeeID, 2));
        }
    }
}
