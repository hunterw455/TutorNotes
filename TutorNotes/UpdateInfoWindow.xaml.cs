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
    /// Interaction logic for UpdateInfoWindow.xaml
    /// </summary>
    public partial class UpdateInfoWindow : Window
    {
        private Student _s;
        private Window _windowA;
        public UpdateInfoWindow(Student s, Window windowA)
        {
            InitializeComponent();
            this._s = s;
            if (this._s != null)
            {
                updateGoal.Text = _s.AcademicGoal;
                updateCurrentTopic.Text = _s.StudentCurriculum.currentTopic();
                updateNextTopics.ItemsSource = _s.StudentCurriculum.CurrentCurriculum;
                this._windowA = windowA;
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

            this.Visibility = Visibility.Hidden;

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

        private void saveStudentEditsBttn_Click(object sender, RoutedEventArgs e)
        {
            var goal = updateGoal.Text.Trim();
            var grade = (ComboBoxItem)updateLetterGrade.SelectedItem;
            var valid = 0;
            if (string.IsNullOrEmpty(goal))
            {
                MessageBox.Show("You must enter a goal.");
                valid++;
            }
            if (grade == null)
            {
                MessageBox.Show("You must select a letter grade.");
                valid++;
            }

            if (valid == 0)
            {
                var gradeLevel = grade.Content.ToString();
                this._s.Grade = gradeLevel;
                this._s.AcademicGoal = goal;
                this.Visibility = Visibility.Hidden;
                this._windowA.Visibility = Visibility.Hidden;
                StudentInfoScreen studentInfo = new StudentInfoScreen(this._s);
                studentInfo.Show();
            }
        }
    }
}