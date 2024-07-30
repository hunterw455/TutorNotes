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

namespace TutorNotes
{
    /// <summary>
    /// Interaction logic for CreateAccountWindow.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        public CreateAccountWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(8);
            }
            else
            {
                this.BorderThickness = new System.Windows.Thickness(0);
            }
        }

        private void dragWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {
                //
            }
        }

        private void closeBttn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minmzBttn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void minmzBttn_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor5");
            minmzBttn.Background = customBrush;
        }

        private void minmzBttn_MouseLeave(object sender, MouseEventArgs e)
        {
            minmzBttn.Background = Brushes.Transparent;
        }

        private void closeBttn_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor5");
            closeBttn.Background = customBrush;
        }

        private void closeBttn_MouseLeave(object sender, MouseEventArgs e)
        {
            closeBttn.Background = Brushes.Transparent;
        }

        private void maxmzBttn_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor5");
            maxmzBttn.Background = customBrush;
        }

        private void maxmzBttn_MouseLeave(object sender, MouseEventArgs e)
        {
            maxmzBttn.Background = Brushes.Transparent;
        }

        private void maxmzBttn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void createAccountbttn_Click(object sender, RoutedEventArgs e)
        {
            var userFirstName = addFirstName.Text.Trim();
            var userLastName = addLastName.Text.Trim();
            var userUsername = createUsername.Text.Trim();
            var userPassword = createPassword.Text.Trim();

            var users = App.TutorNotesUsers;

            if (string.IsNullOrEmpty(userFirstName))
            {
                MessageBox.Show("Input a first name");
            }
            else if (string.IsNullOrEmpty(userLastName))
            {
                MessageBox.Show("Input a last name");
            }
            else if (string.IsNullOrEmpty(userUsername))
            {
                MessageBox.Show("Input a username");
            }
            else if (string.IsNullOrEmpty(userPassword))
            {
                MessageBox.Show("Input a password");
            }
            else if (users.ContainsKey(userUsername))
            {
                MessageBox.Show("Enter a unique username");
            }
            else
            {
                User user = new User(userUsername, userPassword, userFirstName, userLastName);
                users.Add(userUsername, user);
                MainWindow mainWindow = new MainWindow();
                this.Visibility = Visibility.Hidden;
                mainWindow.Show();
            }
        }
    }
}
