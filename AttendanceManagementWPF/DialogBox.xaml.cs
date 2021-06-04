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
using System.Windows.Shapes;

namespace AttendanceManagementWPF
{
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {

        public DialogBox(string message = "", string title = "Error")
        {
            InitializeComponent();
            txtMessage.Content = message;

            if(title.Length <= 0)
            {
                txtTitle.Visibility = Visibility.Collapsed;
            } else
            {
                txtTitle.Visibility = Visibility.Visible;
                txtTitle.Content = title;
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
