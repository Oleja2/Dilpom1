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
    /// Логика взаимодействия для ABT.xaml
    /// </summary>
    public partial class ABT : Page
    {
        public ABT()
        {
            InitializeComponent();

            if (MainWindow.Globals.Access == 2 || MainWindow.Globals.Access == 3)
            {
                addBTN.Visibility = Visibility.Hidden;
                editBTN.Visibility = Visibility.Hidden;
                delBTN.Visibility = Visibility.Hidden;

            }



            Update_Table();
        }
        private void Update_Table()
        {
            DGA.ItemsSource = DiplomEntities.GetContext().The_Applicant.Where(a => a.Status != "Зачислен").ToList();
        }

        private void AddA_Click(object sender, RoutedEventArgs e)
        {
            ABTAD ABT = new ABTAD(null);
            ABT.ShowDialog();
            Update_Table();
        }

        private void EditA_Click(object sender, RoutedEventArgs e)
        {
            if (DGA.SelectedItem != null)
            {
                ABTAD ABT = new ABTAD(DGA.SelectedItem as The_Applicant);
                ABT.ShowDialog();
            }
            else
                MessageBox.Show("Выберите редактируемого абитуриента!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            Update_Table();
        }

        private void DeliteA_Click(object sender, RoutedEventArgs e)
        {
            if (DGA.SelectedItem != null)
            {
                var Removing = DGA.SelectedItems.Cast<The_Applicant>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {Removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        foreach (var rem in Removing)
                        {
                            DiplomEntities.GetContext().The_Applicant.Remove(rem);
                        }
                        DiplomEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удаленны", "Успех", MessageBoxButton.OK);
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
                MessageBox.Show("Выберите удаляемого абитуриента!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Search_method(object sender, TextChangedEventArgs e)
        {
            if (SearchTxb.Text == "")
            {
                Update_Table();
            }
            else
            {
                DGA.ItemsSource = DiplomEntities.GetContext().The_Applicant.Where(a => a.Status != "Зачислен" && (a.Full_Name == SearchTxb.Text || a.Full_Name.Contains(SearchTxb.Text))).ToList();
            }
        }
    }
}
