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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private static Tickets _newTicket;
        public UserPage()
        {
            InitializeComponent();
            _newTicket = new Tickets();
            DataContext = _newTicket;
            Colleges.ItemsSource = BiletyBDEntities.GetContext().Colleges.ToList();
            Comissions.ItemsSource = BiletyBDEntities.GetContext().Comisions.ToList();
            // Specialties.ItemsSource = BiletyBDEntities.GetContext().Specialities.ToList();
            Teachers.ItemsSource = BiletyBDEntities.GetContext().Teachers.ToList();
            List<int> count = new List<int>() { 1, 2, 3 };
            QuestCountBox.ItemsSource = count;

        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            bool dif;
            if (Complexity.IsChecked == true)
            {
                dif = true;
            }
            else
                dif = false;
            Manager.MainFrame.Navigate(new QuestionsPage(_newTicket,Convert.ToInt32(QuestCountBox.SelectedIndex),Convert.ToInt32(StudCount.Text),dif));
        }
    }
}
