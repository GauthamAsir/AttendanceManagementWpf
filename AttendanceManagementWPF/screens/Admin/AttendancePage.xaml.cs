using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for AttendancePage.xaml
    /// </summary>
    public partial class AttendancePage : Page
    {

        public static SqlConnection con;
        public static SqlCommand cmd;

        int selectedIndex;

        public AttendancePage()
        {
            InitializeComponent();

            startdate.SelectedDate = DateTime.Now;
            enddate.SelectedDate = DateTime.Now;

            try
            {
                AttendanceBALClass attendanceBALClass = new AttendanceBALClass();
                DataTable dt = attendanceBALClass.AdminViewAllAttendanceBAL(startdate.SelectedDate.Value, enddate.SelectedDate.Value);
                gridProducts.ItemsSource = dt.DefaultView;
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }

        private void sortby_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            selectedIndex = sortby.SelectedIndex;

            if (sortby.SelectedIndex == 0)
            {
                enddate.Visibility = System.Windows.Visibility.Collapsed;
                startdate.Visibility = System.Windows.Visibility.Visible;
            }

            if (sortby.SelectedIndex == 1)
            {
                enddate.Visibility = System.Windows.Visibility.Visible;
                startdate.Visibility = System.Windows.Visibility.Visible;
            }

            if (sortby.SelectedIndex == 2)
            {
                enddate.Visibility = System.Windows.Visibility.Collapsed;
                startdate.Visibility = System.Windows.Visibility.Visible;
            }
            
        }

        private void updateSort_Click(object sender, RoutedEventArgs e)
        {
            AttendanceBALClass attendanceBALClass = new AttendanceBALClass();

            DataTable dt;

            if (selectedIndex == 0)
            {
                dt = attendanceBALClass.AdminViewAllAttendanceBAL(startdate.SelectedDate.Value.Date,
                    startdate.SelectedDate.Value.Date);
                gridProducts.ItemsSource = dt.DefaultView;
                return;
            }

            if(selectedIndex == 2)
            {
                dt = attendanceBALClass.AdminViewAllAttendanceBAL(startdate.SelectedDate.Value.Date,
                startdate.SelectedDate.Value.Date.AddMonths(1));
                gridProducts.ItemsSource = dt.DefaultView;
                return;
            }

            if(selectedIndex == 1)
            {

                if (enddate.SelectedDate.Value.Date < startdate.SelectedDate.Value.Date)
                {
                    MessageBox.Show("Invalid Date. Please choose date greater than start date.");
                    return;
                }

                dt = attendanceBALClass.AdminViewAllAttendanceBAL(startdate.SelectedDate.Value.Date,
                    enddate.SelectedDate.Value.Date);
                gridProducts.ItemsSource = dt.DefaultView;
                return;
            }

            MessageBox.Show("Invalid Condition");
        }

        private void startdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            /// 
        }

        private void enddate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(enddate.SelectedDate.Value.Date < startdate.SelectedDate.Value.Date)
            {
                MessageBox.Show("Invalid Date. Please choose date greater than start date.");
                return;
            }
        }
    }
}
