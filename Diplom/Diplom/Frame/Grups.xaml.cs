using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using Word = Microsoft.Office.Interop.Word;

namespace Diplom.Frame
{
    /// <summary>
    /// Логика взаимодействия для Grups.xaml
    /// </summary>
    public partial class Grups : Page
    {
        public Grups()
        {
            InitializeComponent();

            if (MainWindow.Globals.Access == 2)
            {
                addBTN.Visibility = Visibility.Hidden;
                editBTN.Visibility = Visibility.Hidden;
                delBTN.Visibility = Visibility.Hidden;
                repBTN.Visibility = Visibility.Hidden;
            }
            else if (MainWindow.Globals.Access == 3)
            {
                repBTN.Visibility = Visibility.Hidden;
                approveBTN.Visibility = Visibility.Hidden;
                noapproveBTN.Visibility = Visibility.Hidden;
            }
            else
            {
                approveBTN.Visibility = Visibility.Hidden;
                noapproveBTN.Visibility = Visibility.Hidden;
            }

            Update_Table();
        }
        private void Update_Table()
        {
            DGG.ItemsSource = DiplomEntities.GetContext().Specialization.ToList();
        }

        private void AddG_Click(object sender, RoutedEventArgs e)
        {
            GrupsAD grupsAD = new GrupsAD(null);
            grupsAD.ShowDialog();
            Update_Table();
        }

        private void EditG_Click(object sender, RoutedEventArgs e)
        {
            if (DGG.SelectedItem != null)
            {
                GrupsAD GAD = new GrupsAD(DGG.SelectedItem as Specialization);
                GAD.ShowDialog();
            }
            else
                MessageBox.Show("Выберите редактируемую группу!", "Успех", MessageBoxButton.OK);

            Update_Table();
        }

        private void DeliteG_Click(object sender, RoutedEventArgs e)
        {
            if (DGG.SelectedItem != null)
            {
                var Removing = DGG.SelectedItems.Cast<Specialization>().ToList();

                foreach (var check in Removing)
                {
                    if (DiplomEntities.GetContext().The_Applicant.FirstOrDefault(n => n.Specialization == check.ID) != null)
                    {
                        MessageBox.Show($"Невозможно удалить группу {check.Name} пока в неё хотят зачислиться абритуенты!",
                                        "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                if (MessageBox.Show($"Вы точно хотите удалить следующие {Removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        foreach (var rem in Removing)
                        {
                            DiplomEntities.GetContext().Specialization.Remove(rem);
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
                MessageBox.Show("Выберите удаляемый проект!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            if (DGG.SelectedItem != null)
            {
                var spec = DGG.SelectedItem as Specialization;

                spec.Group_Status = "Утверждено";
                DiplomEntities.GetContext().SaveChanges();

                MessageBox.Show($"Группа {spec.Name} утверждена", "Успех", MessageBoxButton.OK);

                Update_Table();
            }
            else
            {
                MessageBox.Show("Выберите группу которую нужно утвердить!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ReportG_Click(object sender, RoutedEventArgs e)
        {
            if (DGG.SelectedItem != null)
            {
                var select = DGG.SelectedItem as Specialization;

                Task generate_report = new Task(() => Generate_Report(select));
                generate_report.Start();
            }
            else
            {
                MessageBox.Show("Выберите группу по которой нужно сделать отчёт!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        void Generate_Report(Specialization select)
        {
            if (select.Group_Status == "Утверждено")
            {
                try
                {
                    var applicant = DiplomEntities.GetContext().The_Applicant.Where(a => a.Specialization1.Name == select.Name && a.Status == "Зачислен").ToList();
                    string[] columsName = { "№", "ФИО абитуриента", "Средний балл" };
                    int line_number = 1;

                    var app = new Word.Application();
                    app.Visible = false;

                    Word.Document doc = app.Documents.Open(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Templates\Group_Report.docx");
                    Word.Document newDoc = app.Documents.Add();
                    newDoc.Content.FormattedText = doc.Content.FormattedText;

                    Word.Find find = app.Selection.Find;
                    find.Text = "~Groups_Name~";
                    find.Replacement.Text = Convert.ToString(select.Name);
                    find.Execute(Replace: Word.WdReplace.wdReplaceAll);

                    Word.Find findT = app.Selection.Find; // Логика для вставки таблицы в поле ~Order_Table~
                    findT.Text = "~Groups_Table~";
                    findT.Execute();

                    app.Selection.ClearFormatting();

                    if (findT.Found)
                    {
                        Word.Range range = app.Selection.Range;
                        Word.Table newTable = newDoc.Tables.Add(range, applicant.Count + 1, 3);
                        newTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle; // Устанавливаем стиль линии для внутренних границ
                        newTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle; // Устанавливаем стиль линии для внешних границ

                        // Заполнение заголовков таблицы
                        for (int i = 0; i < columsName.Count(); i++)
                        {
                            newTable.Cell(1, i + 1).Range.Text = columsName[i];
                        }

                        for (int row = 2; row <= applicant.Count + 1; row++)
                        {
                            newTable.Cell(row, 1).Range.Text = Convert.ToString(line_number); // Заполнение столбца "№"
                            newTable.Cell(row, 2).Range.Text = applicant[row - 2].Full_Name; // Заполнение столбца "ФИО абитуриента"
                            newTable.Cell(row, 3).Range.Text = Convert.ToString(applicant[row - 2].Average_Score); // Заполнение столбца "Средний балл"
                            line_number++;
                        }
                    }

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Взятие путя до рабочего стола

                    newDoc.SaveAs(path + $@"\Отчёт по группе {select.Name}.docx"); // Создание и сборка полного пути до файла

                    doc.Close();
                    newDoc.Close();

                    app.Quit();

                    MessageBox.Show("Отчёт создан на рабочем столе", "Успех", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Отчёт по выбранной группе нельзя составить, так как она не утверждена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void noApprove_Click(object sender, RoutedEventArgs e)
        {
            if (DGG.SelectedItem != null)
            {
                var spec = DGG.SelectedItem as Specialization;

                spec.Group_Status = "Не утверждена";
                DiplomEntities.GetContext().SaveChanges();

                MessageBox.Show($"Группа {spec.Name} Не утверждена", "Успех", MessageBoxButton.OK);

                Update_Table();
            }
            else
            {
                MessageBox.Show("Выберите группу которую нужно Отклонить!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
