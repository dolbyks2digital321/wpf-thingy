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
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace wpf_thingy.Pages
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

        private void Butt_Click(object sender, RoutedEventArgs e)
        { 
            Regex regexPhone = new Regex(@"^(\+7|8)\s\d{3}\s\d{3}\s\d{2}\s\d{2}$");
            if (regexPhone.IsMatch(PhoneTb.Text))
            {
                MessageBox.Show("Верный номер!");
            }

            Regex regexEmail = new Regex(@"\S+@(gmail\.com|yandex\.ru|mail\.ru)$");
            if (regexEmail.IsMatch(MailTb.Text))
            {
                MessageBox.Show("Верная почта!");
            }


        }
    }
}
