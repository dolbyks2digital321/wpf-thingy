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
using Authorisation.Components;

namespace Authorisation.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationPage.xaml
    /// </summary>
    public partial class AuthorisationPage : Page
    {
        public AuthorisationPage()
        {
            InitializeComponent();
        }

        private void RegistrateButt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void AuthorizeButt_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<User> users = App.db.User.ToList();
            if (users.Any(x => x.Login == LoginTbx.Text && x.Password == PasswordPbx.Password))
            {
                var user = users.Where(x => x.Login == LoginTbx.Text && x.Password == PasswordPbx.Password).First();
                if (App.db.Workers.Any(x => x.Id_Staff == user.Id_User))
                {
                    var origUser = App.db.Workers.Where(x => x.Id_Staff == user.Id_User).First();
                    MessageBox.Show($"Вы вошли как сотрудник {origUser.Name} {origUser.Surname}!");
                }
                else
                {
                    var origUser = App.db.Client.Where(x => x.Id_Client == user.Id_User).First();
                    MessageBox.Show($"Вы вошли как клиент {origUser.Name} {origUser.Surname}!");
                }
                NavigationService.Navigate(new Page1());
            }
            else MessageBox.Show("Вы ввели некорректный пароль и/или логин!");
        }
    }
}
