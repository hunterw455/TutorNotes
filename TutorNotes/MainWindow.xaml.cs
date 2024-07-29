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
using System.ComponentModel;

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

            // Subscribe to SizeChanged event for dynamic resizing
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


        private void loginBttn_Click(object sender, RoutedEventArgs e)
        {
            // Add functions and capabilities that take care of password authentication



            // Will load in new window once user inputs valid login credentials
            HomeScreen homeScreen = new HomeScreen();
            this.Visibility = Visibility.Hidden;
            homeScreen.Show();
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

/*        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            // Restore original font size and button size
            CurrentFontSize = OriginalFontSize;
            CurrentButtonSize = OriginalButtonSize;
        }*/

    }
}
