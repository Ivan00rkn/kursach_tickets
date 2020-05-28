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

namespace KursachBorisov
{
    /// <summary>
    /// Логика взаимодействия для AddNewQuestion.xaml
    /// </summary>
    public partial class AddNewQuestion : Page
    {
        private static Questions _newQuestion;

        private static Tickets _selectedTicket;
        public AddNewQuestion(Tickets selectedTicket)
        {
            InitializeComponent();
            _selectedTicket = new Tickets();
            _selectedTicket = selectedTicket;
            List<int> dif = new List<int>() { 1, 2, 3 };
            DifficultyBox.ItemsSource = dif;
            Subject.ItemsSource = BiletyBDEntities.GetContext().Subjects.ToList();
            DataContext = _selectedTicket;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(QuestionText.Text))
                errors.AppendLine("Добавьте текст вопроса");
            if (DifficultyBox.SelectedItem == null)
                errors.AppendLine("Выберите сложность вопроса");
            if (Subject.SelectedItem == null)
                errors.AppendLine("Выберите предмет");
            //_newQuestion.Subject_ID = _selectedTicket.Subject_ID;
            _newQuestion.Text = QuestionText.Text;
            if (BiletyBDEntities.GetContext().Questions.Count() == 0)
            {
                _newQuestion.Id = 1;
            }
            else
                _newQuestion.Id = BiletyBDEntities.GetContext().Questions.Last().Id + 1;

            if (errors == null)
            {
                try
                {
                    BiletyBDEntities.GetContext().Questions.Add(_newQuestion);
                    MessageBox.Show("Вопрос добавлен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
            }
            else
            {
                MessageBox.Show(errors.ToString());
            }

            try
            {
                BiletyBDEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения сохранены!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }
}
