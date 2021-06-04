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

namespace AttendanceManagementWPF.screens.User
{
    /// <summary>
    /// Interaction logic for LeavesScreenEmployee.xaml
    /// </summary>
    public partial class LeavesScreenEmployee : Page
    {

        int employee_id;

        AttendanceBALClass attendanceBALClass;

        public LeavesScreenEmployee(int employeeID)
        {
            InitializeComponent();
            employee_id = employeeID;

            attendanceBALClass = new AttendanceBALClass();
            getLeaveRequests();

        }

        void getLeaveRequests()
        {
            try
            {
                DataTable dataTable = attendanceBALClass.EmployeeViewLeaveRequestBAL(employee_id);

                //gridEmployeeLeaves.ItemsSource = dataTable.DefaultView;

                //return;

                DataTable filteredTable = new DataTable();
                filteredTable.Clear();

                filteredTable.Columns.Add("TransactionId");
                filteredTable.Columns.Add("DateOfRequest");
                filteredTable.Columns.Add("StartDate");
                filteredTable.Columns.Add("EndDate");
                filteredTable.Columns.Add("TransactionStatus");
                filteredTable.Columns.Add("Reason");

                foreach (DataRow row in dataTable.Rows)
                {

                    DateTime startDate = DateTime.Parse(row["StartDate"].ToString());
                    DateTime endDate = DateTime.Parse(row["EndDate"].ToString());

                    string leaveStatus = row["TransactionStatus"].ToString();

                    if (startDate.Date == DateTime.Now.Date 
                        && endDate.Date == DateTime.Now.Date
                        && leaveStatus.Equals("Accepted"))
                    {
                        continue;
                    }

                    DataRow dataRow = filteredTable.NewRow();

                    dataRow["TransactionId"] = row["TransactionId"];
                    dataRow["DateOfRequest"] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(row["DateOfRequest"].ToString()));
                    dataRow["StartDate"] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(row["StartDate"].ToString()));
                    dataRow["EndDate"] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(row["EndDate"].ToString()));
                    dataRow["TransactionStatus"] = row["TransactionStatus"];
                    dataRow["Reason"] = row["Reason"];

                    filteredTable.Rows.Add(dataRow);

                    //if (startDate.Date == DateTime.Now.Date &&
                    //    endDate.Date == DateTime.Now.Date &&
                    //    leaveStatus.Equals("Pending"))
                    //{
                    //    DataRow dataRow = filteredTable.NewRow();

                    //    dataRow["TransactionId"] = row["TransactionId"];
                    //    dataRow["DateOfRequest"] = row["DateOfRequest"];
                    //    dataRow["StartDate"] = row["StartDate"];
                    //    dataRow["EndDate"] = row["EndDate"];
                    //    dataRow["TransactionStatus"] = row["TransactionStatus"];

                    //    filteredTable.Rows.Add(dataRow);

                    //}
                    //else if (!leaveStatus.Equals("Accepted"))
                    //{
                    //    DataRow dataRow = filteredTable.NewRow();

                    //    dataRow["TransactionId"] = row["TransactionId"];
                    //    dataRow["DateOfRequest"] = row["DateOfRequest"];
                    //    dataRow["StartDate"] = row["StartDate"];
                    //    dataRow["EndDate"] = row["EndDate"];
                    //    dataRow["TransactionStatus"] = row["TransactionStatus"];

                    //    filteredTable.Rows.Add(dataRow);
                    //}

                }

                gridEmployeeLeaves.ItemsSource = filteredTable.DefaultView;
            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
        }

        private void addLeave_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddLeavesUser(employee_id, 3));
        }

        private void editLeave_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            this.NavigationService.Navigate(new AddLeavesUser(employee_id, 3,
                update: true, int.Parse(dataRowView.Row[0].ToString()),
                DateTime.Parse(dataRowView.Row[2].ToString()),
                DateTime.Parse(dataRowView.Row[3].ToString()),
                dataRowView.Row["Reason"].ToString()));
        }

        private void deleteLeave_Click(object sender, RoutedEventArgs e)
        {

            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            MessageBoxResult messageBoxResult = MessageBox.Show($"Are you " +
                $"sure want to delete leave request", "Delete Confirmation",
                MessageBoxButton.YesNo
                );

            if (messageBoxResult == MessageBoxResult.Yes)
            {

                try
                {
                    int result;

                    attendanceBALClass.DeleteLeaveRequestBAL(
                        int.Parse(dataRowView.Row[0].ToString()), out result);

                    if (result == 1)
                    {
                        MessageBox.Show($"Leave Request was deleted succesfuly.", "Success");
                        getLeaveRequests();
                        return;
                    }


                    MessageBox.Show("Failed to delete leave request.", "Failed");
                }
                catch (Exception exec)
                {
                    MessageBox.Show(exec.Message);
                }
            }

        }
    }
}
