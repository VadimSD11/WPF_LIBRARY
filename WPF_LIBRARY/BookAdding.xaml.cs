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

namespace WPF_LIBRARY
{
    /// <summary>
    /// Interaction logic for BookAdding.xaml
    /// </summary>
    public partial class BookAdding : Window
    {
        private Button selectedButton;
        private Color slcolor = (Color)ColorConverter.ConvertFromString("#8A8370");
        private bool isDragging = false;
        private Point startPoint;
        Thickness two = new Thickness(0, 161, 0, 0);
        Thickness three = new Thickness(0, 209, 0, 0);
        Thickness four = new Thickness(0, 260, 0, 0);
        Thickness five = new Thickness(0, 313, 0, 0);
        Thickness six = new Thickness(0, 364, 0, 0);
        Thickness seven = new Thickness(0, 417, 0, 0);
        Thickness eight = new Thickness(0, 468, 0, 0);
        Thickness addbtnloc = new Thickness(0, 529, 0, 0);
        public BookAdding()
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
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Close the window
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Color rgbColor = (Color)ColorConverter.ConvertFromString("#E8DBB9");


            if (clickedButton == selectedButton)
                return;


            if (selectedButton != null)
                selectedButton.Background = new SolidColorBrush(rgbColor);

            clickedButton.Background = new SolidColorBrush(slcolor);



            selectedButton = clickedButton;
            if (selectedButton == btn3)
            {
                Authors.Visibility = Visibility.Collapsed;
                Genre.Visibility = Visibility.Collapsed;
                Language.Margin = two;
                Tags.Margin = three;
                Publisher.Margin = four;
                Publishingdate.Margin = five;
                ImagePath.Margin = six;
                AddButton.Margin = seven;
            }
            else if (selectedButton == btn2)
            {
                Authors.Visibility = Visibility.Visible;
                Genre.Visibility = Visibility.Collapsed;
                Language.Margin = three;
                Tags.Margin = four;
                Publisher.Margin = five;
                Publishingdate.Margin = six;
                ImagePath.Margin = seven;
                AddButton.Margin = eight;
            }
            else {
                Authors.Visibility = Visibility.Visible;
                Genre.Visibility = Visibility.Visible;
                Authors.Margin = two;
                Genre.Margin= three;
                Language.Margin= four;
                Tags.Margin = five;
                Publisher.Margin = six;
                Publishingdate.Margin = seven;
                ImagePath.Margin = eight;
                AddButton.Margin = addbtnloc;

            }
        }
    }
}
