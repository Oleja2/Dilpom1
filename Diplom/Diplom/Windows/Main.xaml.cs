using Diplom.Frame;
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

namespace Diplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            if (MainWindow.Globals.Access == 2)
            {
                menuG.IsEnabled = false;
                menuA.IsEnabled = false;
                menuL.IsEnabled = false;
                menuU.IsEnabled = false;
                Frame.Content = new Grups();
            }
            else if (MainWindow.Globals.Access == 3)
            {
                menuG.IsEnabled = false;
                menuA.IsEnabled = false;
                menuL.IsEnabled = false;
                Frame.Content = new Grups();
            }
            else
            {
                menuU.IsEnabled = false;
            }
        }

        private void Grup_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Grups();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Exit = new MainWindow();
            Exit.Show();
            Close();
        }

        private void ABT_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new ABT();
        }

        private void Lists_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Lists();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Users();
        }
    }
}
