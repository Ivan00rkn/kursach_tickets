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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (pbPassword!=null && tbLogin!=null)
            {
                if (BiletyBDEntities.GetContext().Users.FirstOrDefault(x=>x.Login==tbLogin.Text && x.Password == pbPassword.Password)!=null)
                {
                    Manager.MainFrame.Navigate(new UserPage());
                }
                else
                {
                    MessageBox.Show("Неверно введен логин или пароль!");
                }
            }
            else
            {
                MessageBox.Show("Неверно введен логин или пароль!");
            }
        }
    }
}
