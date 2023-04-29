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
using System.Windows.Shapes;
using Система_учёта_готовой_продукции_на_складе.Classes;
namespace Система_учёта_готовой_продукции_на_складе.Windows
{
    public partial class Авторизация : Window
    {
        public Авторизация()
        {
            InitializeComponent();
        }
        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Password == "")
            {
                MessageBox.Show("Не введён логин или пароль!!!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                DataBaseWork.AutoUser = DataBaseWork.Entities.Users.Single(x=>x.Login == Login.Text & x.Password==Password.Password);
                Склад склад = new Склад();
                склад.Show();
                Close();
            }
            catch
            {
                MessageBox.Show("Неверно введён логин или пароль!!!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Регистрация регистрация = new Регистрация();
            регистрация.Show();
            Close();
        }
    }
}
