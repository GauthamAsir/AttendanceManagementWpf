using System;
using System.Collections.Generic;
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
using AttendanceManagementWPF.screens.User;
using Entities;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for AddAttendanceUser.xaml
    /// </summary>
    public partial class AddAttendanceUser : Page
    {
        int _employeeID, _roleID;

        List<ProjectDetails> projects = new List<ProjectDetails>();

        public AddAttendanceUser(int employeeId, int roleID)
        {
            InitializeComponent();
            _employeeID = employeeId;
            _roleID = roleID;

            getprojects();

        }

        void getprojects() {

            try
            {
                projects = new AttendanceBALClass().GetProjectIDForAttendance(_employeeID);

                if (projects.Count <= 0)
                {
                    Message.Visibility = Visibility.Visible;
                    projectsList.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Message.Visibility = Visibility.Collapsed;
                    projectsList.Visibility = Visibility.Visible;
                }

                //txtProjectID.ItemsSource = projectIds;

                projectsList.ItemsSource = projects;
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }


        private void addAttendanceButton_Click(object sender, RoutedEventArgs e)
        {   

            try
            {
                ProjectDetails curItem = ((ListViewItem)projectsList.ContainerFromElement((Button)sender)).Content as ProjectDetails;
                

                AttendanceBALClass bal = new AttendanceBALClass();
                bal.AddAttendanceBAL(_employeeID, curItem.ProjectId);

                MessageBox.Show("Attendance Added Successfully");

                if (_roleID == 2)
                {
                    this.NavigationService.Navigate(new AttendanceManager(_employeeID));
                    return;
                }

                this.NavigationService.Navigate(new AttendanceEmployee(_employeeID));

            }
            catch (Exception exception)
            {

                MessageBox.Show("Attendance Already Added for this Project ID.", 
                    "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_roleID == 2)
            {
                this.NavigationService.Navigate(new AttendanceManager(_employeeID));
                return;
            }

            this.NavigationService.Navigate(new AttendanceEmployee(_employeeID));
        }
    }

}
