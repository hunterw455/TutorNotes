using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
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
            this.Cells = ((Educator)App.CurrentUser).Cells;
            PopulateCells();

            DataContext = this;
        }

        private void PopulateCells()
        {
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor7");

            // Example: Populate 77 cells (7 columns x 11 rows)
             for (int row = 1; row <= 11; row++)
                {
                    for (int col = 1; col <= 7; col++)
                    {

                    if (((Educator)App.CurrentUser).Cells.Count < 77 || ((Educator)App.CurrentUser).Cells == null )
                    {
                        string name = ""; // If empty, will know it's not occupied by a student.

                        //string name = $"row{row}col{col}";
                        ((Educator)App.CurrentUser).addToCell(new CellInfo(name, customBrush, new Thickness(
                            left: col == 1 ? 2 : 1,
                            top: row == 1 ? 2 : 1,    
                            right: col == 7 ? 2 : 1,   
                            bottom: row == 11 ? 2 : 1  
                        ), row, col, Brushes.Transparent));
                    }
                    else
                    {
                        return;
                    }
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
                if (s != null)
                {
                    StudentInfoScreen infoScreen = new StudentInfoScreen(s);
                    this.Visibility = Visibility.Hidden;
                    infoScreen.Show();
                }
            }
        }

        private void editListBttn_Click(object sender, RoutedEventArgs e)
        {
            StudentListWindow studentListWindow = new StudentListWindow();
            studentListWindow.Show();
        }

        private void addStudentBttn_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.Show();
        }


        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rectangle = sender as Rectangle;
            if (rectangle == null) return;

            var border = VisualTreeHelper.GetParent(rectangle) as Border;
            if (border == null) return;

            var cellInfo = border.DataContext as CellInfo;
            if (cellInfo == null) return;

            if (cellInfo.Fill != Brushes.Transparent)
            {
                MessageBox.Show($"A session time already occurs for {cellInfo.CellName}.");
                return;
            }

            if (((Educator)App.CurrentUser).StudentsAssigned.Count != 0)
            {
                AddSessionWindow addSessionWindow = new AddSessionWindow(cellInfo, this);
                addSessionWindow.Show();
            }
            else
            {
                MessageBox.Show("You do not have any students assigned yet to add sessions.");
            }

        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;

            var cell = menuItem?.Tag as CellInfo;

            if (cell != null)
            {
                cell.Fill = Brushes.Transparent;
                cell.CellName = "";
                cell.Emptiness = true;
            }
        }
    }
}

