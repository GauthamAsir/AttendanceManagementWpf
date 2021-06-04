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
    /// Interaction logic for AttendanceApprovalAdmin.xaml
    /// </summary>
    public partial class AttendanceApprovalAdmin : Page
    {

        AttendanceBALClass attendanceBALClass;

        DataTable dt;

        public AttendanceApprovalAdmin()
        {
            InitializeComponent();

            attendanceBALClass = new AttendanceBALClass();

            try
            {
                dt = attendanceBALClass.AdminViewPendingAttendanceRequestBAL();
                gridManagerAttendance.ItemsSource = dt.DefaultView;
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }

        private void present_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                attendanceBALClass.UpdateAttendanceManagerBAL(int.Parse(dataRowView["EmployeeId"].ToString()),
                    int.Parse(dataRowView["ProjectId"].ToString()), 1);
                dt.Rows.Remove(dataRowView.Row);
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
                    int.Parse(dataRowView["ProjectId"].ToString()), 0);
                dt.Rows.Remove(dataRowView.Row);
            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }
    }
}
