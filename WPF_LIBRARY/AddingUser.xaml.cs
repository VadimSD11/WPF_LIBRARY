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

namespace WPF_LIBRARY
{
    /// <summary>
    /// Interaction logic for AddingUser.xaml
    /// </summary>
    public partial class AddingUser : Window
    {
        private Button selectedButton;
        private Color slcolor = (Color)ColorConverter.ConvertFromString("#8A8370");
        private bool isDragging = false;
        private Point startPoint;
        Thickness oldbtnloc = new Thickness(0, 350, 0, 0);
        Thickness newbtnloc = new Thickness(0,255,0,0);
        public AddingUser()
        {
            InitializeComponent();
            selectedButton = btn1; // Select the "User" button by default
            selectedButton.Background = new SolidColorBrush(slcolor); // Set the initial background color for the selected button

        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            startPoint = e.GetPosition(this);
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPoint = e.GetPosition(this);
                double offsetX = currentPoint.X - startPoint.X;
                double offsetY = currentPoint.Y - startPoint.Y;

                Left += offsetX;
                Top += offsetY;
            }
        }
        private void txtPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.TextChanged += txtPassword_TextChanged;
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Close the window
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Text = "Password";
            }
        }
        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPassword.Text != "Password")
                txtPassword.Text = new string('*', txtPassword.Text.Length);

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Color rgbColor = (Color)ColorConverter.ConvertFromString("#E8DBB9");

            // If the clicked button is already selected, do nothing
            if (clickedButton == selectedButton)
                return;


            // Restore the background color of the previously selected button
            if (selectedButton != null)
                selectedButton.Background = new SolidColorBrush(rgbColor);
            // Set the background color of the clicked button to yellow
            clickedButton.Background = new SolidColorBrush(slcolor);


            // Update the selectedButton reference
            selectedButton = clickedButton;
            if (selectedButton == btn3)
            {
                Contact.Visibility = Visibility.Hidden;
                Addbutton.Margin = newbtnloc;
            }
            else
            {
                Contact.Visibility = Visibility.Visible;
                Addbutton.Margin = oldbtnloc;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BookAdding bookAdding = new BookAdding();
            bookAdding.Show();
            this.Close();
        }
    }
}
