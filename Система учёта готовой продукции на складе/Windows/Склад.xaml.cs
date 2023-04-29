using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Net.Http.Headers;
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
    public partial class Склад : Window
    {
        public Склад()
        {
            InitializeComponent();
            Товары.ItemsSource = DataBaseWork.Entities.Product.ToList();
        }
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            DataBaseWork.Entities.SaveChanges();
            Товары.ItemsSource = DataBaseWork.Entities.Product.ToList();
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Добавление_товара добавление_Товара = new Добавление_товара();
            добавление_Товара.Show();
            Close();
        }
        private void Search_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Товары.ItemsSource = DataBaseWork.Entities.Product.ToList().Where(x=>x.Name.Contains(Search_text.Text));
        }
        private void Товары_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                foreach (Система_учёта_готовой_продукции_на_складе.Product product in Товары.SelectedItems)
                {
                    DataBaseWork.Entities.Product.Remove(product);
                    DataBaseWork.Entities.SaveChanges();
                    MessageBox.Show("Товар успешно удалён", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                }                
            }
        }
    }
}
