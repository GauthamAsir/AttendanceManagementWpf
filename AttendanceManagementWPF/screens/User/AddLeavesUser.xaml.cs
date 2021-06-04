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
using AttendanceManagementWPF.screens.User;
using AttendanceManagementBAL;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for RequestLeaveUser.xaml
    /// </summary>
    public partial class AddLeavesUser : Page
    {

        int _employeeID, _roleID, _trancsactionID, noOfLeavesLeft;

        bool _update;

        DateTime _startDate, _endDate;

        string _reason;

        public AddLeavesUser(int employeeId, int roleID,
            bool update = false, int transactionID = 0,
            DateTime? startdate = null, DateTime? enddate = null, string reason = "")
        {
            InitializeComponent();
            _employeeID = employeeId;
            _roleID = roleID;

            txtEmployeeID.Text = _employeeID.ToString();

            txtStartDate.DisplayDateStart = DateTime.Now;

            txtEndDate.DisplayDateStart = DateTime.Now;


            _update = update;

            noOfLeavesLeft = new AttendanceBALClass().GetRemainingLeaveBAL(_employeeID);

            //if(noOfLeavesLeft <= -6)
            //{
            //    txtLeavesLeft.Content = "You have used maximum leaves.";
            //    addLeaveButton.IsEnabled = false;

            //} else if(noOfLeavesLeft <= 0 || noOfLeavesLeft > -6)
            //{
            //    txtLeavesLeft.Content = noOfLeavesLeft <= 0  ? "You have taken all " +
            //    "the available leaves\nfor this month, your new leaves\nwill be deducted " +
            //    "from next month." : $"No. of Leaves Left : {noOfLeavesLeft}";
            //    addLeaveButton.IsEnabled = true;
            //} else
            //{
            //    txtLeavesLeft.Content = noOfLeavesLeft;
            //    addLeaveButton.IsEnabled = true;
            //}

            txtLeavesLeft.Content = noOfLeavesLeft <= 0 ? "You have taken all " +
                "the available leaves\nfor this month, your new leaves\nwill be deducted " +
                "from next month." : $"No. of Leaves Left : {noOfLeavesLeft}";

            if (update)
            {

                _startDate = startdate.Value.Date;
                _endDate = enddate.Value.Date;

                _trancsactionID = transactionID;

                _reason = reason;

                txtTransactionID.Text = _trancsactionID.ToString();
                txtTransactionID.Visibility = Visibility.Visible;

                txtStartDate.SelectedDate = _startDate;
                txtEndDate.SelectedDate = _endDate;

                txtReason.Text = _reason;

                addLeaveButton.Content = "Update Leave";
                title.Content = "Update Leave";
            }

        }

        private void addLeaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DateTime startDate = txtStartDate.SelectedDate.HasValue ? txtStartDate.SelectedDate.Value.Date
                : DateTime.Now,
                endDate = txtEndDate.SelectedDate.HasValue ? txtEndDate.SelectedDate.Value.Date
                : DateTime.Now;

                string reason = txtReason.Text;

                if (reason.Length <= 2)
                {
                    MessageBox.Show("Enter a valid reason");
                    return;
                }

                if (_update)
                {
                    if (startDate.Date > endDate.Date || endDate.Date < startDate.Date)
                    {
                        MessageBox.Show("Invalid Date", "Update");
                    }
                }
                else
                {
                    if (startDate.Date < DateTime.Now.Date || endDate.Date < DateTime.Now.Date ||
                    startDate.Date > endDate.Date || endDate.Date < startDate.Date)
                    {
                        MessageBox.Show("Invalid Date");
                        return;
                    }
                }

                //if(noOfLeavesLeft <= -6)
                //{
                //    MessageBox.Show("You have used maximum leaves.", "Error");
                //    return;
                //}

                //double n =  noOfLeavesLeft - (endDate.Date - startDate.Date).TotalDays;

                //if (n <= -6)
                //{
                //    MessageBox.Show("You have used maximum leaves. Try applying less number of days leave.", "Error");
                //    return;
                //}

                int result;

                if (_update)
                {
                    new AttendanceBALClass().UpdateLeaveRequestBAL(_trancsactionID, _employeeID,
                    startDate, endDate, reason, out result);

                }
                else
                {
                    new AttendanceBALClass().LeaveRequestBAL(_employeeID,
                    startDate, endDate, reason, out result);
                }

                string actionPerformed = _update ? "Update" : "Add";

                if (result == 1)
                {
                    MessageBox.Show($"Leave Request {actionPerformed} Succesfully");
                    if (_roleID == 2)
                    {
                        this.NavigationService.Navigate(new LeavesScreenManager(_employeeID));
                        return;
                    }
                    this.NavigationService.Navigate(new LeavesScreenEmployee(_employeeID));
                    return;
                }

                MessageBox.Show($"You already have a leave request or pending leave request at this day.");
            } 
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
            

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_roleID == 2)
            {
                this.NavigationService.Navigate(new LeavesScreenManager(_employeeID));
                return;
            }
            this.NavigationService.Navigate(new LeavesScreenEmployee(_employeeID));
        }
    }
}
