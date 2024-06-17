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
    /// Логика взаимодействия для GrupsAD.xaml
    /// </summary>
    public partial class GrupsAD : Window
    {
        private Specialization tankGroup = new Specialization();

        public GrupsAD(Specialization selectedGroup)
        {
            InitializeComponent();
            if (selectedGroup != null)
            {
                tankGroup = selectedGroup;
                ADG.Content = "Сохранить";
            }

            DataContext = tankGroup;
        }

        private void AddG_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (NameGrups.Text == "")
                Errors.AppendLine("Не указанно сокращённое название!");
            if (QuantityGrups.Text == "")
                Errors.AppendLine("Не указанно название!");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            tankGroup.Group_Status = "Не утверждена";
            tankGroup.Spaces_Left = tankGroup.Number_of_Seats;

            if (tankGroup.ID == 0)
            {
                DiplomEntities.GetContext().Specialization.Add(tankGroup);
            }

            try
            {
                DiplomEntities.GetContext().SaveChanges();
                MessageBox.Show("Группа сохранена", "Успех", MessageBoxButton.OK);
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
