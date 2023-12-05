using Authorisation.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Authorisation.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationButt_Click(object sender, RoutedEventArgs e)
        {
            if (SurnameTbx.Text != "" && NameTbx.Text != "" && PatronTbx.Text != "" && LoginTbx.Text != "" && PasswordTbx.Text != "")
            {
                if (App.db.User.Any(x => x.Login == LoginTbx.Text))
                {
                    MessageBox.Show("Уже есть такой логин!");
                }
                else
                {
                    string pass = "!@#$%^";
                    if (PasswordTbx.Text.Length >= 6)
                    {
                        bool smallLetter = false;
                        bool digit = false;
                        bool symbol = false;
                        foreach (char letter in PasswordTbx.Text)
                        {
                            if (letter == '!' || letter == '@' || letter == '#' || letter == '$' || letter == '%' || letter == '^')
                                symbol = true;

                            if (char.IsDigit(letter)) digit = true;

                            if (char.IsUpper(letter)) smallLetter = true;
                        }
                        if (smallLetter && symbol && digit)
                        {
                            Client client = new Client();
                            client.Surname = SurnameTbx.Text;
                            client.Name = NameTbx.Text;
                            client.Patronymic = PatronTbx.Text;
                            App.db.Client.Add(new Client
                                ( ));
                            MessageBox.Show("Регистрация прошла!");
                        }
                        else MessageBox.Show("Неправильный пароль");
                    }
                    MessageBox.Show("Пароль меньше 6 символов");
                }
            }
            else MessageBox.Show("Не все обязательные данные введены!");
        }
    }
}
