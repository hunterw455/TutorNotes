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
    /// Interaction logic for StudentInfoScreen.xaml
    /// </summary>
    public partial class StudentInfoScreen : Window
    {
        public StudentInfoScreen()
        {
            InitializeComponent();
        }

        private void HomeScreen_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
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
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor2");
            minmzBttn.Background = customBrush;
        }

        private void minmzBttn_MouseLeave(object sender, MouseEventArgs e)
        {
            minmzBttn.Background = Brushes.Transparent;
        }

        private void closeBttn_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor2");
            closeBttn.Background = customBrush;
        }

        private void closeBttn_MouseLeave(object sender, MouseEventArgs e)
        {
            closeBttn.Background = Brushes.Transparent;
        }

        private void maxmzBttn_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor2");
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

    }
}
