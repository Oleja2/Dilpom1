using Diplom.Windows;
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

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static class Globals
        {
            public static int Access;
        }

        public MainWindow()
        {
            InitializeComponent();
            Login.ItemsSource = DiplomEntities.GetContext().User.ToList();
        }

        private void PassBlock_Up(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

              Button_Click(sender, e);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var auth = DiplomEntities.GetContext().User.AsNoTracking().FirstOrDefault(a => a.Login == Login.Text && a.Password == PassBox.Password);
            if (auth != null)
            {
                Globals.Access = auth.Role;

                Main main = new Main();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
