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
    /// Interaction logic for UpdateInfoWindow.xaml
    /// </summary>
    public partial class UpdateInfoWindow : Window
    {
        public UpdateInfoWindow()
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
            StudentInfoScreen studentInfoScreen = new StudentInfoScreen();
            this.Visibility = Visibility.Hidden;
            studentInfoScreen.Show();
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


    }
}
