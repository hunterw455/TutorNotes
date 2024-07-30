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
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            InitializeComponent();
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
            HomeScreen homeScreen = new HomeScreen();
            this.Visibility = Visibility.Hidden;
            homeScreen.Show();
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

        private void addStudentBttn_Click(object sender, RoutedEventArgs e)
        {
            var fName = addFirstName.Text.Trim();
            var lName = addLastName.Text.Trim();
            var goal = addCurrentGoal.Text.Trim();
            var level = (ComboBoxItem)GradeLevelComboBox.SelectedItem;
            var valid = 0;
            if (string.IsNullOrEmpty(fName))
            {
                MessageBox.Show("You must enter a first name.");
                valid++;
            }
            if (string.IsNullOrEmpty(lName))
            {
                MessageBox.Show("You must enter a last name.");
                valid++;
            }
            if (level == null)
            {
                MessageBox.Show("You must select a grade level.");
                valid++; 
            }
            if (string.IsNullOrEmpty(goal))
            {
                MessageBox.Show("You must enter an academic goal.");
                valid++;
            }



            if (valid == 0)
            {
                var gradeLevel = level.Content.ToString();
                Student student = new Student(fName, lName, gradeLevel, goal);
                ((Educator)App.CurrentUser).addStudentToList(student);
                this.Visibility = Visibility.Hidden;
            }

        }
    }
}