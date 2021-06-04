using AttendanceManagementBAL;
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

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for LeavesScreenManager.xaml
    /// </summary>
    public partial class LeavesScreenManager : Page
    {

        int _employeeID;

        AttendanceBALClass attendanceBALClass;

        public LeavesScreenManager(int employeeID)
        {
            InitializeComponent();
            _employeeID = employeeID;

            attendanceBALClass = new AttendanceBALClass();

            getLeavesManager();
        }

        void getLeavesManager()
        {
            try
            {

                DataTable dt = attendanceBALClass.ManagerViewPendingLeaveRequestBAL(_employeeID);
                gridProducts.ItemsSource = dt.DefaultView;

            } catch(Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }

        private void btnRejectStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                attendanceBALClass.UpdateLeaveStatusManagerBAL(int.Parse(dataRowView["TransactionId"].ToString()), "Rejected");
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
            getLeavesManager();

        }

        private void addNewLeave_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddLeavesUser(_employeeID, 2));
        }

        private void acceptLeave_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            try
            {
                attendanceBALClass.UpdateLeaveStatusManagerBAL(int.Parse(dataRowView["TransactionId"].ToString()), "Accepted");
            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

            getLeavesManager();

        }
    }
}
