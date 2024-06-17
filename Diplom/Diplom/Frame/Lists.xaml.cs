using Diplom.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Diplom.Frame
{
    /// <summary>
    /// Логика взаимодействия для Lists.xaml
    /// </summary>
    public partial class Lists : Page
    {
        public Lists()
        {
            InitializeComponent();

            if (MainWindow.Globals.Access == 2)
            {
                confBTN.Visibility = Visibility.Hidden;
                rejBTN.Visibility = Visibility.Hidden;
            }
            else if (MainWindow.Globals.Access == 3)
            {
                confBTN.Visibility = Visibility.Hidden;
                rejBTN.Visibility = Visibility.Hidden;
            }

            LGR.ItemsSource = DiplomEntities.GetContext().Specialization.ToList();
        }

        private void СonfirmL_Click(object sender, RoutedEventArgs e)
        {
            if (Grup.SelectedItem != null)
            {
                var Removing = Grup.SelectedItems.Cast<The_Applicant>().ToList();
                try
                {
                    foreach (var rem in Removing)
                    {
                        var aaa = DiplomEntities.GetContext().Specialization.Find(rem.Specialization);
                        if (aaa.Spaces_Left != 0)
                        {
                            rem.Status = "Зачислен";
                            aaa.Spaces_Left--;
                        }
                        else
                        {
                            MessageBox.Show($"Мест в группе {aaa.Name} больше нет");
                            return;
                        }
                    }
                    DiplomEntities.GetContext().SaveChanges();
                    LGR_SelectionChanged(null, null);

                    MessageBox.Show("Абритуент выбран", "Успех", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Выберите абритуента", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RejectL_Click(object sender, RoutedEventArgs e)
        {
            if (Grup.SelectedItem != null)
            {
                var Removing = Grup.SelectedItems.Cast<The_Applicant>().ToList();
                try
                {
                    foreach (var rem in Removing)
                    {
                        var aaa = DiplomEntities.GetContext().Specialization.Find(rem.Specialization);
                        aaa.Spaces_Left++;
                        rem.Status = "Не зачислен";
                    }
                    DiplomEntities.GetContext().SaveChanges();
                    LGR_SelectionChanged(null, null);

                    MessageBox.Show("Сохраненно", "Успех", MessageBoxButton.OK);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Выберите абритуента", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LGR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ID_spec = (LGR.SelectedItem as Specialization).ID;
            Grup.ItemsSource = DiplomEntities.GetContext().The_Applicant.Where(p => p.Specialization == ID_spec).ToList();
            remCB.IsChecked = false;
            remCB.IsEnabled = true;
        }
        private void Remove_Approved(object sender, RoutedEventArgs e)
        {
            int ID_spec = (LGR.SelectedItem as Specialization).ID;
            var Check = sender as CheckBox;
            if (SearchTxb.Text != null)
            {
                Search_method(null, null);
            }
            else if (remCB.IsChecked.Value)
            {
                Grup.ItemsSource = DiplomEntities.GetContext().The_Applicant.Where(a => a.Status != "Зачислен" && a.Specialization == ID_spec).ToList();
            }
            else
            {
                 Grup.ItemsSource = DiplomEntities.GetContext().The_Applicant.Where(a => a.Specialization == ID_spec).ToList();
            }
        }

        private void Search_method(object sender, TextChangedEventArgs e)
        {
            if (LGR.SelectedIndex == -1)
                return;

            int ID_spec = (LGR.SelectedItem as Specialization).ID;

            if (SearchTxb.Text == "")
            {
                if (remCB.IsChecked.Value)
                {
                    Grup.ItemsSource = DiplomEntities.GetContext().The_Applicant.Where(a => a.Status != "Зачислен" && a.Specialization == ID_spec).ToList();
                }
                else
                {
                    Grup.ItemsSource = DiplomEntities.GetContext().The_Applicant.Where(a => a.Specialization == ID_spec).ToList();
                }
            }
            else
            {
                if (remCB.IsChecked.Value)
                {
                    Grup.ItemsSource = DiplomEntities.GetContext().The_Applicant.Where(a => a.Status != "Зачислен" && a.Specialization == ID_spec && (a.Full_Name == SearchTxb.Text || a.Full_Name.Contains(SearchTxb.Text))).ToList();
                }
                else
                {
                    Grup.ItemsSource = DiplomEntities.GetContext().The_Applicant.Where(a => a.Specialization == ID_spec && (a.Full_Name == SearchTxb.Text || a.Full_Name.Contains(SearchTxb.Text))).ToList();
                }
            }

        }
    }
}
