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
        private Student _s;
        public StudentInfoScreen(Student s)
        {
            InitializeComponent();
            _s = s; // Copies student to modify

            if (_s != null)
            {
                studentNameText.Text = $"Name: {_s.DisplayName}";
                studentGradeLevelText.Text = $"Level: {_s.Level}";
                academicGoalText.Text = $"{_s.AcademicGoal}";
                DateTime today = DateTime.Today;
                calendar.SelectedDate = today;
                notesDateDisplay.Text = today.ToString("MMMM d, yyyy");
                updateTextBlock(_s.Grade);
                currentTopic.Text = _s.StudentCurriculum.currentTopic();
                curriculumTopicsList.ItemsSource = _s.StudentCurriculum.CurrentCurriculum;


                if (s.StudentNotes.containsNote(today))
                {
                    notesFromDay.Text = _s.StudentNotes.getNote(today);
                }
            }
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
            UpdateInfoWindow updateInfo = new UpdateInfoWindow(_s, this);
            updateInfo.Show();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar.SelectedDate;
            if (selectedDate.HasValue && _s != null)
            {
                DateTime date = selectedDate.Value;
                notesDateDisplay.Text = date.ToString("MMMM d, yyyy");

                notesFromDay.Text = _s.StudentNotes.getNote(date);
            }
        }

        private void addNote_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = calendar.SelectedDate;
            if (selectedDate.HasValue)
            {
                var date = selectedDate.Value;
                var note = notesFromDay.Text;
                if (_s != null)
                {
                    _s.StudentNotes.addNote(note, date); // Adds the note from the selected day to the notes
                }
            }
        }

        private void updateTextBlock(string letter)
        {
            if (this._s.Grade != "" && this._s != null)
            {
                letterGradeText.Text = this._s.Grade;

                Brush color;
                switch (letter.ToUpper())
                {
                    case "A":
                    case "B":
                        color = Brushes.DarkSeaGreen;
                        break;
                    case "C":
                    case "D":
                        color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ebd564"));
                        break;
                    case "F":
                        color = Brushes.Red;
                        break;
                    default:
                        color = Brushes.Black; // Default color
                        break;
                }

                letterGradeText.Foreground = color;
            }
        }
    }
}
