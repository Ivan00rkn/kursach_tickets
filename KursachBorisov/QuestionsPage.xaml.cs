using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace KursachBorisov
{
    /// <summary>
    /// Логика взаимодействия для QuestionsPage.xaml
    /// </summary>
    public partial class QuestionsPage : Page
    {
        private static Tickets _newTicket;
        private int _questCountPerTicket;
        private int _studCount;
        private bool _dif;
        private static List<Questions> _selectedQuestions;
        private static List<Tickets> _tickets;
        private static System.Random rand;
        private string TemplateFileName = "C:\test.docx";
        public QuestionsPage(Tickets selectedTicket,int questCount,int studCount,bool difficulty)
        {
            InitializeComponent();
            _newTicket = selectedTicket;
            _questCountPerTicket = questCount;
            _studCount = studCount;
            _dif = difficulty;
            Questions.ItemsSource = BiletyBDEntities.GetContext().Questions.ToList();
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddNewQuestion(_newTicket));
        }

        private void MakeTickets_Click(object sender, RoutedEventArgs e)
        {
            _selectedQuestions = new List<Questions>();
            _selectedQuestions = Questions.SelectedItems.Cast<Questions>().ToList();

            if (_selectedQuestions.Count()<((_studCount+1)*_questCountPerTicket))
            {
                MessageBox.Show("Выбрано недостаточное количество вопросов!");
            }
            else
            {
                if (_dif)
                {
                    List<Questions> easyQuestions = new List<Questions>();
                        easyQuestions = _selectedQuestions.Where(x => x.Dificulty == 1).ToList();
                    List<Questions> normalQuestions = new List<Questions>();
                        normalQuestions = _selectedQuestions.Where(x => x.Dificulty == 2).ToList();
                    List<Questions> hardQuestions = new List<Questions>();
                        hardQuestions = _selectedQuestions.Where(x => x.Dificulty == 3).ToList();

                    switch (_questCountPerTicket)
                    {
                        case 3:

                            if (easyQuestions.Count < _studCount + 1)
                                MessageBox.Show("Выбрано недостаточно ЛЕГКИХ вопросов для формирования билета");
                            else if (normalQuestions.Count < _studCount + 1)
                                MessageBox.Show("Выбрано недостаточно СРЕДНИХ вопросов для формирования билета");
                            else if (hardQuestions.Count < _studCount + 1)
                                MessageBox.Show("Выбрано недостаточно СЛОЖНЫХ вопросов для формирования билета");

                            for (int i = 1; i < (_studCount+1)*3; i++)
                            {
                                int random = rand.Next(0, easyQuestions.Count-1);
                                _newTicket.Questions.Add(easyQuestions[random]);
                                easyQuestions.RemoveAt(random);

                                random = rand.Next(0, normalQuestions.Count - 1);
                                _newTicket.Questions.Add(normalQuestions[random]);
                                normalQuestions.RemoveAt(random);

                                random = rand.Next(0, hardQuestions.Count - 1);
                                _newTicket.Questions.Add(hardQuestions[random]);
                                hardQuestions.RemoveAt(random);
                            }
                            break;
                        case 4:

                            if (easyQuestions.Count < (_studCount + 1)*2)
                                MessageBox.Show("Выбрано недостаточно ЛЕГКИХ вопросов для формирования билета");
                            else if (normalQuestions.Count < _studCount + 1)
                                MessageBox.Show("Выбрано недостаточно СРЕДНИХ вопросов для формирования билета");
                            else if (hardQuestions.Count < _studCount + 1)
                                MessageBox.Show("Выбрано недостаточно СЛОЖНЫХ вопросов для формирования билета");

                            for (int i = 1; i < (_studCount + 1)*4; i++)
                            {
                                int random = rand.Next(0, easyQuestions.Count - 1);
                                _newTicket.Questions.Add(easyQuestions[random]);
                                easyQuestions.RemoveAt(random);

                                random = rand.Next(0, easyQuestions.Count - 1);
                                _newTicket.Questions.Add(easyQuestions[random]);
                                easyQuestions.RemoveAt(random);

                                random = rand.Next(0, normalQuestions.Count - 1);
                                _newTicket.Questions.Add(normalQuestions[random]);
                                normalQuestions.RemoveAt(random);

                                random = rand.Next(0, hardQuestions.Count - 1);
                                _newTicket.Questions.Add(hardQuestions[random]);
                                hardQuestions.RemoveAt(random);
                            }

                            break;
                        case 5:
                            if (easyQuestions.Count < (_studCount + 1)*2)
                                MessageBox.Show("Выбрано недостаточно ЛЕГКИХ вопросов для формирования билета");
                            else if (normalQuestions.Count < (_studCount + 1)*2)
                                MessageBox.Show("Выбрано недостаточно СРЕДНИХ вопросов для формирования билета");
                            else if (hardQuestions.Count < _studCount + 1)
                                MessageBox.Show("Выбрано недостаточно СЛОЖНЫХ вопросов для формирования билета");

                            for (int i = 1; i < (_studCount + 1)*5; i++)
                            {
                                int random = rand.Next(0, easyQuestions.Count - 1);
                                _newTicket.Questions.Add(easyQuestions[random]);
                                easyQuestions.RemoveAt(random);

                                random = rand.Next(0, easyQuestions.Count - 1);
                                _newTicket.Questions.Add(easyQuestions[random]);
                                easyQuestions.RemoveAt(random);

                                random = rand.Next(0, normalQuestions.Count - 1);
                                _newTicket.Questions.Add(normalQuestions[random]);
                                normalQuestions.RemoveAt(random);

                                random = rand.Next(0, normalQuestions.Count - 1);
                                _newTicket.Questions.Add(normalQuestions[random]);
                                normalQuestions.RemoveAt(random);

                                random = rand.Next(0, hardQuestions.Count - 1);
                                _newTicket.Questions.Add(hardQuestions[random]);
                                hardQuestions.RemoveAt(random);
                            }
                            break;
                    }
                    try
                    {
                        BiletyBDEntities.GetContext().SaveChanges();

                        MessageBox.Show("Данные успешно сохранились!");
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        throw;
                    }
                }
                else
                {

                }
                foreach (Tickets t in BiletyBDEntities.GetContext().Tickets.Include(t=>t.))
                {
                    
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BiletyBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
        private void PrintIntoWord()
        {

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            var wordDocument = wordApp.Documents.Open(TemplateFileName);
            ReplaceWordStub("{num}", , wordDocument);
            //ReplaceWordStub("{name", name, wordDocument);

            wordDocument.SaveAs("filename");
            
        }

        private void ReplaceWordStub(string stub, string text,Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stub, ReplaceWith: text);
        }
    }
}
