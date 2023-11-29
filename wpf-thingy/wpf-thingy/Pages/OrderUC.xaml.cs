using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для OrderUC.xaml
    /// </summary>
    public partial class OrderUC : UserControl
    {
        private OrderList order;
        public OrderUC(OrderList _order)
        {
            InitializeComponent();
            order = _order;
            AmountTb.Text = order.Amount.ToString();
            CostForManyTb.Text = order.TotalPrice.ToString();
           // var prodord = App.db.Product.Where(x => x.Id == order.ProductId);
            Refresh();
        }

        public void Refresh()
        { 
            order.Amount = int.Parse(AmountTb.Text);
            var prodord = App.db.Product.Where(x => x.Id == order.ProductId);
            foreach (var obj in prodord.ToList())
            {
                TitleTb.Text = "Название: " + obj.Title;
                DescriptionTb.Text = "Описание: " + obj.Description;
                CostForOneTb.Text = "Цена за 1 шт.: " + obj.NewCost.ToString();
                CostWithoutDiscountTb.Text = "Цена без скидки: " + obj.Cost.ToString();
                CostForManyTb.Text = "Цена за " + order.Amount.ToString() + " шт.: " + (obj.NewCost * order.Amount).ToString();
            } 
            order.TotalPrice = decimal.Parse(CostForManyTb.Text.Split(' ')[4]);
            
        }

        private void MinusButt_Click(object sender, RoutedEventArgs e)
        {
            if (AmountTb.Text == "1") MessageBox.Show("Невозможно уменьшить количество. При необходимости удалите товар с помощью кнопки 'Удалить'.");
            else AmountTb.Text = (int.Parse(AmountTb.Text) - 1).ToString();
            Refresh();
            App.db.SaveChanges();
            Navigation.NextPage(new PageComponent("Корзина", new OrdersPage()));
        }

        private void PlusButt_Click(object sender, RoutedEventArgs e)
        {
            AmountTb.Text = (int.Parse(AmountTb.Text) + 1).ToString();
            Refresh();
            App.db.SaveChanges();
            Navigation.NextPage(new PageComponent("Корзина", new OrdersPage()));
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            App.db.OrderList.Remove(order);
            Refresh();
            App.db.SaveChanges();
            Navigation.NextPage(new PageComponent("Корзина", new OrdersPage()));
        }

        private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if 
        }
    }
}
