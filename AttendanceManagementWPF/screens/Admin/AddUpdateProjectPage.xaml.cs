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
using Entities;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for AddNewProject.xaml
    /// </summary>
    public partial class AddUpdateProjectPage : Page
    {

        bool _update;

        public AddUpdateProjectPage(
            bool update = false, ProjectDetails projectDetails = null)
        {
            InitializeComponent();

            _update = update;

            txtStartDate.DisplayDateStart = DateTime.Now;
            txtStartDate.SelectedDate = DateTime.Now;

            txtEndDate.DisplayDateStart = DateTime.Now.AddMonths(1);
            txtEndDate.SelectedDate = DateTime.Now.AddMonths(1);

            if(update && projectDetails != null)
            {
                title.Content = "Update Project";

                txtProjectName.Text = projectDetails.ProjectName;

                txtProjectID.Text = projectDetails.ProjectId.ToString();
                txtProjectID.Visibility = Visibility.Visible;

                txtStartDate.SelectedDate= projectDetails.StartDate.Date;

                txtEndDate.SelectedDate = projectDetails.EndDate.Date;

                addprojectButton.Content = "Update";

            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(_update)
            {
                this.NavigationService.Navigate(new ProjectDetailsAdmin(
                int.Parse(txtProjectID.Text.ToString())));
                return;
            }

            this.NavigationService.Navigate(new ProjectsPage());

        }

        private void addprojectButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                addUpdateProject();
            } catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }


        void addUpdateProject()
        {
            string projectName = txtProjectName.Text;
            DateTime startDate = txtStartDate.SelectedDate.HasValue ? txtStartDate.SelectedDate.Value.Date
                : DateTime.Now,
                endDate = txtEndDate.SelectedDate.HasValue ? txtEndDate.SelectedDate.Value.Date
                : DateTime.Now;

            int result;

            ProjectDetails projectDetails = new ProjectDetails();

            if (_update)
            {
                projectDetails = new ProjectDetails
                {
                    ProjectId = int.Parse(txtProjectID.Text),
                    EndDate = endDate,
                    StartDate = startDate,
                    ProjectName = projectName
                };

                new AttendanceBALClass().UpdateProjectBAL(projectDetails, out result);

            }
            else
            {
                projectDetails = new ProjectDetails
                {
                    EndDate = endDate,
                    StartDate = startDate,
                    ProjectName = projectName
                };

                new AttendanceBALClass().AddProjectBAL(projectDetails, out result);
            }

            if (result == 1)
            {
                if (_update)
                {
                    MessageBox.Show($"Project Updated Successful");
                    this.NavigationService.Navigate(new ProjectDetailsAdmin(
                        int.Parse(txtProjectID.Text.ToString())));

                }
                else
                {
                    MessageBox.Show($"Project Added Successful");
                    txtProjectName.Text = "";
                }
            }
        }

    }
}
