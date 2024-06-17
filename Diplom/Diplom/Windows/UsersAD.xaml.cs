using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для UsersAD.xaml
    /// </summary>
    public partial class UsersAD : Window
    {
        User _currnetUser = new User();
        public UsersAD(User selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
            {
                _currnetUser = selectedUser;
                ADG.Content = "Сохранить";
            }

            DataContext = _currnetUser;

            RoleUser.ItemsSource = DiplomEntities.GetContext().Table_Role.ToList();
        }

        private void AddU_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (LoginUser.Text == "")
                Errors.AppendLine("Не указан логин!");
            if (PasswordUser.Text == "")
                Errors.AppendLine("Не указан пароль!");
            if (RoleUser.SelectedValue == null)
                Errors.AppendLine("Не указанна роль!");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_currnetUser.ID == 0)
            {
                DiplomEntities.GetContext().User.Add(_currnetUser);
            }

            try
            {
                DiplomEntities.GetContext().SaveChanges();
                MessageBox.Show("Пользователь сохранён", "Успех", MessageBoxButton.OK);
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
