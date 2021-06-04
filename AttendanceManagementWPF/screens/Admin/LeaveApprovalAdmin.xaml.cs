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
    /// Interaction logic for LeaveApprovalAdmin.xaml
    /// </summary>
    public partial class LeaveApprovalAdmin : Page
    {

        AttendanceBALClass attendanceBALClass;

        public LeaveApprovalAdmin()
        {
            InitializeComponent();
            attendanceBALClass = new AttendanceBALClass();
            getLeavesManager();
        }

        void getLeavesManager()
        {
            try
            {

                DataTable dt = attendanceBALClass.AdminViewPendingLeaveRequestsBAL();
                gridLeavesApproval.ItemsSource = dt.DefaultView;
            }
            catch (Exception exec)
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
                getLeavesManager();
            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }

        private void acceptLeave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                attendanceBALClass.UpdateLeaveStatusManagerBAL(int.Parse(dataRowView["TransactionId"].ToString()), "Accepted");
                getLeavesManager();

            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }

    }
}
