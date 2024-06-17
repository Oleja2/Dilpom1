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
using Diplom.Windows;

namespace Diplom.Frame
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();
            Update_Table();
        }

        void Update_Table()
        {
            DGG.ItemsSource = DiplomEntities.GetContext().User.ToList();
        }

        private void AddU_Click(object sender, RoutedEventArgs e)
        {
            UsersAD UAD = new UsersAD(null);
            UAD.ShowDialog();
            Update_Table();
        }

        private void EditU_Click(object sender, RoutedEventArgs e)
        {
            if (DGG.SelectedItem != null)
            {
                UsersAD UAD = new UsersAD(DGG.SelectedItem as User);
                UAD.ShowDialog();
                Update_Table();
            }
            else
            {
                MessageBox.Show("Выберите пользователя которого хотите отредактировать", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeliteU_Click(object sender, RoutedEventArgs e)
        {
            if (DGG.SelectedItems != null)
            {
                var removing = DGG.SelectedItems.Cast<User>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        foreach (var remove in removing)
                        {
                            DiplomEntities.GetContext().User.Remove(remove);
                        }
                        DiplomEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удаленны");
                        Update_Table();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя которого хотите удалить", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
