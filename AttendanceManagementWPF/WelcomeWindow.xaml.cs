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
using System.Windows.Shapes;
using AttendanceManagementBAL;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {

        string _empName;
        int _empId, _roleId;

        AttendanceBALClass attendanceBALClass;

        public WelcomeWindow(string employeeName, int employeeId, int roleId)
        {
            InitializeComponent();

            _empId = employeeId;
            _empName = employeeName;
            _roleId = roleId;

            attendanceBALClass = new AttendanceBALClass();

            loadContents();

        }

        async void loadContents()   
        {

            ((Storyboard)FindResource("transformEllipse")).Begin(circle1);

            ((Storyboard)FindResource("transformEllipse")).Begin(circle2);

            await Task.Delay(1000);

            welcome.Visibility = Visibility.Visible;
            ((Storyboard)FindResource("fade")).Begin(welcome);

            await Task.Delay(1500);

            empName.Visibility = Visibility.Visible;
            empName.Content = _empName;
            ((Storyboard)FindResource("fade")).Begin(empName);


            stackTitle.Visibility = Visibility.Visible;
            ((Storyboard)FindResource("fade")).Begin(stackTitle);

            await Task.Delay(1500);

            Continue.Visibility = Visibility.Visible;

            ((Storyboard)FindResource("fade")).Begin(Continue);
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            navigate();
        }

        private void navigate() 
        {
            if (_roleId == 1)
            {

                DashboardAdminWindow adminWindow = new DashboardAdminWindow();
                adminWindow.Show();
                this.Close();
                return;
            }

            DateTime? lastRefreshedDate;

            attendanceBALClass.GetLastRefreshedDateBAL(_empId, out lastRefreshedDate);

            if (lastRefreshedDate.Value.Month != DateTime.Now.Month &&
                lastRefreshedDate.Value.Month < DateTime.Now.Month &&
                lastRefreshedDate.Value.Year <= DateTime.Now.Year)
            {
                attendanceBALClass.AddLeaveEveryMonthBAL(_empId);
            }

            DashboardUserWindow userWindow = new DashboardUserWindow(_roleId, _empId);
            userWindow.Show();
            this.Close();
        }

    }
}
