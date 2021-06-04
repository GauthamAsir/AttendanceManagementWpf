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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AttendanceManagementWPF.screens.User;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for DashboardUserWindow.xaml
    /// </summary>
    public partial class DashboardUserWindow : Window
    {

        int roleID;
        int _empID;

        Grid currentGridSelected;

        const string myAttendance = "dasboard_my_attendance";
        const string myLeaves = "dasboard_my_leave";

        const string leaves = "dasboard_leave_approvals";
        const string attendance = "dasboard_attendance_approval";

        const string logOut = "logout_menu_item";

        public DashboardUserWindow(int role_id, int empID)
        {
            InitializeComponent();

            roleID = role_id;
            _empID = empID;

            roleLabel.Content = roleID == 2 ? "Manager" : "Employee";

            frame.Navigate(new AttendanceEmployee(_empID));

            if (roleID == 3)
            {
                dasboard_attendance_approval.Visibility = Visibility.Collapsed;
                dasboard_leave_approvals.Visibility = Visibility.Collapsed;
                
            }

            currentGridSelected = dasboard_my_attendance;
            currentGridSelected.Background = new SolidColorBrush(Colors.Black) { Opacity = 0.25 };
        }

        private void selectItem(object sender, MouseButtonEventArgs e)
        {
            if (currentGridSelected != null)
            {
                currentGridSelected.Background = new SolidColorBrush(Colors.Transparent);
            }

            string gridName = ((Grid)sender).Name;

            switch (gridName)
            {
                case myAttendance:
                    currentGridSelected = dasboard_my_attendance;
                    frame.Navigate(new AttendanceEmployee(_empID));
                    break;
                case myLeaves:
                    currentGridSelected = dasboard_my_leave;
                    frame.Navigate(new LeavesScreenEmployee(_empID));
                    break;
                case leaves:
                    currentGridSelected = dasboard_leave_approvals;
                    frame.Navigate(new LeavesScreenManager(_empID));
                    break;
                case attendance:
                    currentGridSelected = dasboard_attendance_approval;
                    frame.Navigate(new AttendanceManager(_empID));
                    break;
                case logOut:
                    currentGridSelected = logout_menu_item;
                    LoginWindow login = new LoginWindow();
                    login.Show();
                    this.Close();
                    break;
                default:
                    currentGridSelected = dasboard_my_attendance;
                    frame.Navigate(new AttendanceEmployee(_empID));
                    break;
            }


            currentGridSelected.Background = new SolidColorBrush(Colors.Black) { Opacity = 0.25 };
        }

        private void frameNavigation(object sender, NavigatingCancelEventArgs e)
        {

            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.3);
            ta.DecelerationRatio = 0.7;
            ta.To = new Thickness(0, 0, 0, 0);
            if (e.NavigationMode == NavigationMode.New)
            {
                ta.From = new Thickness(500, 0, 0, 0);
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                ta.From = new Thickness(0, 0, 500, 0);
            }
                 (e.Content as Page).BeginAnimation(MarginProperty, ta);


        }
    }
}
