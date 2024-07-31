using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for AddSessionWindow.xaml
    /// </summary>
    public partial class AddSessionWindow : Window
    {
        private CellInfo _cellInfo;
        private Window _windowA;
        public AddSessionWindow(CellInfo cellInfo, Window windowA)
        {
            InitializeComponent();
            addStudentList.ItemsSource = ((Educator)App.CurrentUser).StudentsAssigned;
            _cellInfo = cellInfo;
            _windowA = windowA;
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

        private void addSessionBttn_Click(object sender, RoutedEventArgs e)
        {
            
            SolidColorBrush customBrush = (SolidColorBrush)FindResource("CustomColor3");
            _cellInfo.Fill = customBrush;

            Student s = (Student)addStudentList.SelectedItem;
            _cellInfo.CellName = s.DisplayName;


            this.Visibility = Visibility.Hidden;
            this._windowA.Visibility = Visibility.Hidden;
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Show();
        }
    }
}
