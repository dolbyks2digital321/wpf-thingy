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
using wpf_thingy.Cumponents;

namespace wpf_thingy.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductionList.xaml
    /// </summary>
    public partial class ProductionList : Page
    {
        public ProductionList()
        {
            InitializeComponent();
            if (App.isAdmin == false) AddBtn.Visibility = Visibility.Collapsed;
            else OrderListButt.Visibility = Visibility.Collapsed;

            var productList = App.db.Product.ToList();
            Refresh();
        }

        private void Refresh()
        {
            IEnumerable<Product> productSortList = App.db.Product;
            if (SortCB.SelectedIndex == 1)
            {
                productSortList = productSortList.OrderBy(x => x.Cost);
            }
            else if (SortCB.SelectedIndex == 2)
            {
                productSortList = productSortList.OrderByDescending(x => x.NewCost);
            }

            if (DiscountFilterCbx.SelectedIndex != 0)
            {
                if (DiscountFilterCbx.SelectedIndex == 1)
                    productSortList = productSortList.Where(x => x.Discount >= 0 && x.Discount < 5);
                if (DiscountFilterCbx.SelectedIndex == 2)
                    productSortList = productSortList.Where(x => x.Discount >= 5 && x.Discount < 15);
                if (DiscountFilterCbx.SelectedIndex == 3)
                    productSortList = productSortList.Where(x => x.Discount >= 15 && x.Discount < 30);
                if (DiscountFilterCbx.SelectedIndex == 4)
                    productSortList = productSortList.Where(x => x.Discount >= 30 && x.Discount < 70);
                if (DiscountFilterCbx.SelectedIndex == 5)
                    productSortList = productSortList.Where(x => x.Discount >= 70 && x.Discount < 100);
            }
            if (SearchTbx.Text != null)
            {
                productSortList = productSortList.Where(x => x.Title.ToLower().Contains(SearchTbx.Text.ToLower()) || x.Description.ToLower().Contains(SearchTbx.Text.ToLower()));
            }

            ProductionWP.Children.Clear();
            foreach (var service in productSortList)
            {
                ProductionWP.Children.Add(new ProductionUC(service));
            }
            CountDataTbx.Text = productSortList.Count() + " из " + App.db.Product.Count();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountFilterCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Добавление услуг", new AddEditPage(new Product())));
        }

        private void OrderListButt_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Корзина", new OrdersPage()));
        }
    }
}
