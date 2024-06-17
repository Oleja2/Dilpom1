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
    /// Логика взаимодействия для ABTAD.xaml
    /// </summary>
    public partial class ABTAD : Window
    {
        private The_Applicant tankGroup = new The_Applicant();
        public ABTAD(The_Applicant selectedGroup)
        {
            InitializeComponent();
            if (selectedGroup != null)
            {
                tankGroup = selectedGroup;
                DateOfBirth.Text = Convert.ToString(tankGroup.Date_of_birth).Remove(10);
                ADABT.Content = "Сохранить";
            }

            DataContext = tankGroup;
            Specialization.ItemsSource = DiplomEntities.GetContext().Specialization.ToList();
        }

        private void AddABT_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (Number.Text == "")
                Errors.AppendLine("Не указан номер телефона!");
            if (FullName.Text == "")
                Errors.AppendLine("Не указанно ФИО!");
            if (PassportData.Text == "")
                Errors.AppendLine("Не указан паспорт!");
            if (PlaceOfResidence.Text == "")
                Errors.AppendLine("Не указанна прописка!");
            if (DateOfBirth.Text == "")
                Errors.AppendLine("Не указан день рождение!");
            if (AverageScore.Text == "")
                Errors.AppendLine("Не указан средний балл!");
            if (Specialization.SelectedValue == null)
                Errors.AppendLine("Не указанна специальность!");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            tankGroup.Status = "В рассмотрении";

            tankGroup.Date_of_birth = Convert.ToDateTime(DateOfBirth.Text);

            if (tankGroup.ID == 0)
            {
                DiplomEntities.GetContext().The_Applicant.Add(tankGroup);
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
