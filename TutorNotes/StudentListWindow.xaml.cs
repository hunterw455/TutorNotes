﻿using System;
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
    /// Interaction logic for StudentListWindow.xaml
    /// </summary>
    public partial class StudentListWindow : Window
    {
        public StudentListWindow()
        {
            InitializeComponent();
            editListBox.ItemsSource = ((Educator)App.CurrentUser).StudentsAssigned;
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

        private void deleteStudentBttn_Click(object sender, RoutedEventArgs e)
        {
            var selectedValue = (Student)editListBox.SelectedValue;
            if (selectedValue != null) 
            {
                ((Educator)App.CurrentUser).removeStudent(selectedValue); // Will remove the student from the educator's list and it should automatically update in the home screen
                
                foreach (CellInfo c in ((Educator)App.CurrentUser).Cells)
                {
                    if (c.CellName == selectedValue.DisplayName)
                    {
                        c.Fill = Brushes.Transparent;
                        c.CellName = "";
                        c.Emptiness = true;
                    }
                }
            }
        }
    }
}
