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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            IEnumerable<OrderList> orderList = App.db.OrderList;
            //var orderList = App.db.Product.ToList();
            ProductionWP.Children.Clear();
            foreach (var ord in orderList)
            {
                ProductionWP.Children.Add(new OrderUC(ord));
            }
            //CountDataTbx.Text = productSortList.Count() + " из " + App.db.Product.Count();
        }
    }
}
