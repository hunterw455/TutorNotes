using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public ObservableCollection<CellInfo> Cells { get; set; }
        public HomeScreen()
        {
            InitializeComponent();

            if (App.CurrentUser != null)
            {
                WelcomeBackTxt.Text = $"Welcome Back {App.CurrentUser.FirstName}";
            }
            else
            {
                WelcomeBackTxt.Text = "Welcome Back";
            }

            listBox.ItemsSource = ((Educator)App.CurrentUser).StudentsAssigned;

            DataContext = this;
            PopulateCells();
        }
        private void PopulateCells()
        {
            Cells = new ObservableCollection<CellInfo>();
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor7");

            // Example: Populate 77 cells (7 columns x 11 rows)
            for (int row = 1; row <= 11; row++)
            {
                for (int col = 1; col <= 7; col++)
                {
                    string name = $"row{row}col{col}";
                    Cells.Add(new CellInfo(name, customBrush, new Thickness(
                        left: col == 1 ? 2 : 1,    // Adjust as needed
                        top: row == 1 ? 2 : 1,     // Adjust as needed
                        right: col == 7 ? 2 : 1,   // Adjust as needed
                        bottom: row == 11 ? 2 : 1  // Adjust as needed
                    )));
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
            
            if (((Educator)App.CurrentUser).StudentsAssigned.Count != 0)
            {
                Student s = (Student)listBox.SelectedItem;
                StudentInfoScreen infoScreen = new StudentInfoScreen(s);
                this.Visibility = Visibility.Hidden;
                infoScreen.Show();
            }
        }

        private void editListBttn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addStudentBttn_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.Show();
        }
    }
    public class CellInfo
    {
        public string CellName { get; set; }
        public Brush BorderBrush { get; set; }
        public Thickness BorderThickness { get; set; }
        // Add more properties as needed

        public CellInfo(string name, Brush borderBrush, Thickness borderThickness)
        {
            CellName = name;
            BorderBrush = borderBrush;
            BorderThickness = borderThickness;
        }
    }
}

