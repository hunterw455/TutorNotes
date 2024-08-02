using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace TutorNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            SizeChanged += Window_SizeChanged;
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


        // Signs the user in if they have the correct username and password
        private void loginBttn_Click(object sender, RoutedEventArgs e)
        {
            var enteredUsername = usernameText.Text;
            var enteredPassword = passwordText.Password;

            var users = App.TutorNotesUsers;


            if (users.ContainsKey(enteredUsername))
            {
                if (users[enteredUsername].Password == enteredPassword)
                {

                    App.CurrentUser = users[enteredUsername];
                    // Will load in new window once user inputs valid login credentials
                    HomeScreen homeScreen = new HomeScreen();
                    this.Visibility = Visibility.Hidden;
                    homeScreen.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
        }
        private void createAccount_MouseEnter(object sender, MouseEventArgs e)
        {
            createAccountTxt.Foreground = Brushes.Purple;
            createAccountTxt.FontWeight = FontWeights.Bold;
        }

        private void createAccountTxt_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor1");
            createAccountTxt.Foreground = customBrush;
            createAccountTxt.FontWeight = FontWeights.Light;
        }

        private void forgotPasswordTxt_MouseEnter(object sender, MouseEventArgs e)
        {
            forgotPasswordTxt.Foreground = Brushes.Purple;
            forgotPasswordTxt.FontWeight= FontWeights.Bold;
        }

        private void forgotPasswordTxt_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor1");
            forgotPasswordTxt.Foreground= customBrush;
            forgotPasswordTxt.FontWeight = FontWeights.Light;
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
            maxmzBttn.Background= Brushes.Transparent;
        }

        private void maxmzBttn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void createAccountTxt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow();
            this.Visibility = Visibility.Hidden;
            createAccountWindow.Show();
        }

        private void createAccountTxt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CreateAccountWindow createAccountWin = new CreateAccountWindow();
            this.Visibility = Visibility.Hidden;
            createAccountWin.Show();
        }

        private void forgotPasswordTxt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            this.Visibility= Visibility.Hidden;
            forgotPasswordWindow.Show();
        }
    }
}
