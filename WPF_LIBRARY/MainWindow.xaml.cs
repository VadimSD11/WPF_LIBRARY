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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_LIBRARY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddingUser addingUser = new AddingUser();
            addingUser.Show();
            this.Close();

        }
        private void txtPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.TextChanged += txtPassword_TextChanged;
            }
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
    }
}
