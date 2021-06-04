using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using AttendanceManagementWPF.screens.Admin;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardAdminWindow : Window
    {
        const string projects = "projects_menu_item";
        const string employees = "employees_menu_item";
        const string attendance = "attendance_menu_item";
        const string attendanceApproval = "attendance_approval_menu_item";
        const string leaveApproval = "leave_approval_menu_item";
        const string leaves = "leave_menu_item";
        const string logOut = "logout_menu_item";

        Grid currentGridSelected;

        public DashboardAdminWindow()
        {
            InitializeComponent();

            frame.Navigate(new ProjectsPage());
            currentGridSelected = projects_menu_item;
            currentGridSelected.Background = new SolidColorBrush(Colors.White) { Opacity = 0.25 };
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
                case attendanceApproval:

                    if(currentGridSelected == attendance_approval_menu_item)
                    {
                        break;
                    }

                    currentGridSelected = attendance_approval_menu_item;
                    frame.Navigate(new AttendanceApprovalAdmin());
                    break;
                case leaveApproval:
                    if (currentGridSelected == leave_approval_menu_item)
                    {
                        break;
                    }
                    currentGridSelected = leave_approval_menu_item;
                    frame.Navigate(new LeaveApprovalAdmin());
                    break;
                case projects:

                    if (currentGridSelected == projects_menu_item)
                    {
                        break;
                    }

                    currentGridSelected = projects_menu_item;
                    frame.Navigate(new ProjectsPage());
                    break;
                case employees:

                    if (currentGridSelected == employees_menu_item)
                    {
                        break;
                    }

                    currentGridSelected = employees_menu_item;
                    frame.Navigate(new EmployeesPage());
                    break;
                case leaves:

                    if (currentGridSelected == leave_menu_item)
                    {
                        break;
                    }

                    currentGridSelected = leave_menu_item;
                    frame.Navigate(new LeavesPage());
                    break;
                case attendance:

                    if (currentGridSelected == attendance_menu_item)
                    {
                        break;
                    }

                    currentGridSelected = attendance_menu_item;
                    frame.Navigate(new AttendancePage());
                    break;
                case logOut:
                    currentGridSelected = logout_menu_item;
                    LoginWindow login = new LoginWindow();
                    login.Show();
                    this.Close();
                    break;
                default:
                    frame.Navigate(new ProjectsPage());
                    currentGridSelected = projects_menu_item;
                    break;
            }


            currentGridSelected.Background = new SolidColorBrush(Colors.White) { Opacity = 0.25 };
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
