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
using Microsoft.Win32;
using System.IO;
using Система_учёта_готовой_продукции_на_складе.Classes;

namespace Система_учёта_готовой_продукции_на_складе.Windows
{
    public partial class Добавление_товара : Window
    {
        byte[] image;
        public Добавление_товара()
        {
            InitializeComponent();
        }
        private void Add_tovar_Click(object sender, RoutedEventArgs e)
        {
            if(image == null)
            {
                MessageBox.Show("Не выбрано изображение!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Name.Text == null|| Count.Text == null ||Cost_ed.Text==null)
            {
                MessageBox.Show("Необходимо заполнить все поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                DataBaseWork.Entities.Product.Add(new Product { Name = Name.Text,Count = Convert.ToInt32(Count.Text),Cost_ed=Convert.ToDecimal(Cost_ed.Text),Photo=image});
                DataBaseWork.Entities.SaveChanges();
                MessageBox.Show("Товар успешно добавлен", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("При добавлении данных произошла ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Склад склад = new Склад();
            склад.Show();
            Close();
        }
        private void Select_Photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Графические изображения|*.jpg;*.jpeg;*.png;";
            openFileDialog.ShowDialog();
            string s = openFileDialog.FileName;
            image = File.ReadAllBytes(s);
            ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri(s)));
            Photo.Source = imageBrush.ImageSource;
        }
    }
}
