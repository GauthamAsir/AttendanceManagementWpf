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
using AttendanceManagementWPF.screens.Admin;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {

        public EmployeesPage()
        {
            InitializeComponent();
            AttendanceBALClass bal = new AttendanceBALClass();

            try
            {
                gridEmployeeDetails.ItemsSource = bal.GetEmployeeDetailsBAL().DefaultView;

            }
            catch(Exception exec)
            {
                MessageBox.Show(exec.Message);
            }

        }

        private void txtSearchEmployee_TextChanged(object sender, TextChangedEventArgs e)
        {
            AttendanceBALClass bal = new AttendanceBALClass();

            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string theText = textBox.Text;

                gridEmployeeDetails.ItemsSource =
                    bal.SearchEmployeeDetailsBAL(theText).DefaultView;
            }
            
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new AddEmployeeAdmin());
        }

        private void menuItemMore_Click(object sender, RoutedEventArgs e)
        {

            DataRowView dataRowView = (DataRowView)((MenuItem)e.Source).DataContext;

            this.NavigationService.Navigate(new EmployeeDetailsPage(dataRowView.Row[0].ToString()));

        }

        private void menuItemUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((MenuItem)e.Source).DataContext;
            this.NavigationService.Navigate(new UpdateEmployeeAdmin(employeeID: int.Parse(dataRowView.Row[0].ToString())));
        }

        private void menuItemRemove_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int result = 0;
                DataRowView dataRowView = (DataRowView)((MenuItem)e.Source).DataContext;

                int EmployeeID = Convert.ToInt32(dataRowView[0]);
                string EmplolyeeName = dataRowView[1].ToString();
                MessageBoxResult messageBoxResult = MessageBox.Show($"Are You Sure Want to " +
                    $"Delete the Record? \nEmployee ID : {EmployeeID}\tEmployee Name : " +
                    $"{EmplolyeeName}", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {

                    AttendanceBALClass bal = new AttendanceBALClass();
                    bal.DeleteEmployeeBAL(EmployeeID, out result);
                    if (result == 1)
                    {
                        MessageBox.Show("Record Deleted Successfully !");
                        dataRowView.Row.Delete();
                        return;
                    }

                    MessageBox.Show("Something went wrong.");
                }
                else
                {
                    MessageBox.Show("Delete Terminated !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
