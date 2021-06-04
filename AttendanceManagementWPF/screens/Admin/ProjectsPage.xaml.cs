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

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for ProjectsPage.xaml
    /// </summary>
    public partial class ProjectsPage : Page
    {

        DataTable dataTable;

        public ProjectsPage()
        {
            InitializeComponent();

            getProjects();

        }

        void getProjects()
        {
            try
            {
                dataTable = new AttendanceBALClass().FewProjectDetailsBAL();
                gridProjects.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }


        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddUpdateProjectPage());
        }


        private void viewProjectDetails_Click(object sender, RoutedEventArgs e)
        {

            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            this.NavigationService.Navigate(new ProjectDetailsAdmin( 
                projectId: int.Parse(dataRowView.Row[0].ToString())));
        }

        private void txtSearchProject_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            DataTable filteredTable = new DataTable();
            filteredTable.Clear();

            filteredTable.Columns.Add("ProjectId");
            filteredTable.Columns.Add("ProjectName");

            if (textBox != null || textBox.Text.Length > 0)
            {
                string searchText = textBox.Text;

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row[1].ToString().ToLower().Contains(searchText.ToLower()))
                    {
                        DataRow dataRow = filteredTable.NewRow();

                        dataRow["ProjectId"] = row["ProjectId"];
                        dataRow["ProjectName"] = row["ProjectName"];

                        filteredTable.Rows.Add(dataRow);
                    }
                }

                gridProjects.ItemsSource = filteredTable.DefaultView;

                return;
            }

            getProjects();

        }
    }
}
