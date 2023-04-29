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
    public partial class Регистрация: Window
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            Авторизация авторизация = new Авторизация();
            авторизация.Show();
            Close();
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Password == "")
            {
                MessageBox.Show("Не введён логин или пароль!!!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                DataBaseWork.Entities.Users.Single(x=> x.Login==Login.Text);
                MessageBox.Show("Пользователь с таким логином уже существует!!!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            catch
            {
                DataBaseWork.Entities.Users.Add(new Users { Login=Login.Text,Password=Password.Password});
                DataBaseWork.Entities.SaveChanges();
                MessageBox.Show("Регистрация выполнена успешно", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);                
            }
        }
    }
}
