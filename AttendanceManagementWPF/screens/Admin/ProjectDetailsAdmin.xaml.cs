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
using AttendanceManagementWPF.screens.Admin;
using Entities;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for ProjectDetailsAdmin.xaml
    /// </summary>
    public partial class ProjectDetailsAdmin : Page
    {

        AttendanceBALClass attendanceBALClass;

        int _projectId;

        DataTable dataTable;

        ProjectDetails projectDetails = new ProjectDetails();

        public ProjectDetailsAdmin(int projectId)
        {
            InitializeComponent();

            _projectId = projectId;
            projectDetails.ProjectId = _projectId;

            txtProjectID.Content = _projectId.ToString();

            attendanceBALClass = new AttendanceBALClass();

            updateProjectDetails();
            getEmployees();
            
        }

        void updateProjectDetails()
        {
            try
            {
                SqlDataReader reader = attendanceBALClass.GetDateForProjecttBAL(_projectId);

                while (reader.Read())
                {

                    DateTime startDate = DateTime.Parse(reader[0].ToString());

                    DateTime endDateDate = DateTime.Parse(reader[1].ToString());

                    projectDetails.EndDate = endDateDate;
                    projectDetails.StartDate = startDate;

                    txtStartDate.Content = String.Format("{0:d/M/yyyy}", startDate);

                    txtEndDate.Content = String.Format("{0:d/M/yyyy}", endDateDate);

                    txtProjectName.Content = reader[2].ToString();

                    projectDetails.ProjectName = reader[2].ToString();

                }
            } catch(Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }

        void getEmployees()
        {
            try
            {
                dataTable = attendanceBALClass.GetEmployeeDetailsForProjectBAL(_projectId);
                gridEmployessProject.ItemsSource = dataTable.DefaultView;

                txtEmolyeesWorking.Content = dataTable.Rows.Count.ToString();
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProjectsPage());
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            new AssignEmployeeToProjectAdmin(_projectId).ShowDialog();
            getEmployees();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult messageBoxResult = 
                MessageBox.Show($"Are You Sure Want to Delete the Record? \nProject ID : " +
                $"{_projectId}\nTotal no. of employees Working : " +
                $"{dataTable.Rows.Count}", "Delete Confirmation", 
                System.Windows.MessageBoxButton.YesNo);

            if(messageBoxResult == MessageBoxResult.Yes)
            {
                int result;

                try
                {
                    attendanceBALClass.DeleteProjectBAL(_projectId, out result);

                    if (result == 1)
                    {
                        MessageBox.Show("Record Deleted Successfully !");
                        this.NavigationService.Navigate(new ProjectsPage());
                        return;
                    }

                    MessageBox.Show("Something went wrong.");
                } catch(Exception exec)
                {
                    MessageBox.Show(exec.Message);
                }

            }
            else
            {
                MessageBox.Show("Delete Terminated !");
            }

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddUpdateProjectPage(true, projectDetails));

        }

        private void RemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                MessageBoxResult result = MessageBox.Show("Are you sure want to remove this employee" +
                    "from the project", "Confirmation", MessageBoxButton.YesNo);

                if(result == MessageBoxResult.Yes)
                {
                    DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

                    attendanceBALClass.RemoveAssignedEmployeeProjectBAL(
                        int.Parse(dataRowView["EmployeeId"].ToString()), _projectId);

                    getEmployees();
                }

            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }
    }

}
