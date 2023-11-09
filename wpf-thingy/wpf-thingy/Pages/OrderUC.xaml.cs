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
    /// Логика взаимодействия для OrderUC.xaml
    /// </summary>
    public partial class OrderUC : UserControl
    {
        private OrderList order;
        public OrderUC(OrderList _order)
        {
            InitializeComponent();
            order = _order;
            var prodord = App.db.Product.Where(x => x.Id == order.ProductId);
            foreach (var obj in prodord.ToList())
                MessageBox.Show(obj.Title);
            //MessageBox.Show();
        }
    }
}
