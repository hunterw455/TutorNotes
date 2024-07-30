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
        public StudentInfoScreen(Student s)
        {
            InitializeComponent();
            studentNameText.Text = $"Name: {s.DisplayName}";
            studentGradeLevelText.Text = $"Level: {s.Level}";
            academicGoalText.Text = $"{s.AcademicGoal}";

            DateTime today = DateTime.Today;
            notesDateDisplay.Text = today.ToString("MMMM d, yyyy");

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
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void backBttn_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();
            this.Visibility = Visibility.Hidden;
            homeScreen.Show();
        }

        private void editStudentInfoBttn_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfoWindow updateInfo = new UpdateInfoWindow();
            updateInfo.Show();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar.SelectedDate;

            // Check if a date is selected
            if (selectedDate.HasValue)
            {
                // Format the date as "Day July 14th, 2024"
                var dayOfWeek = selectedDate.Value.DayOfWeek.ToString();
                var dayOfMonth = selectedDate.Value.Day;
                var month = selectedDate.Value.ToString("MMMM");
                var year = selectedDate.Value.Year;


                // Set the formatted date to the TextBlock
                notesDateDisplay.Text = $"{month} {dayOfMonth}, {year}";
            }
        }
    }
}
