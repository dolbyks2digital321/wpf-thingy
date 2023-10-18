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
            var ProductionList = App.db.Product.ToList();
            var FeedList = App.db.Feedback.ToList();
            ProductionWP.Children.Clear();
            foreach (var product in ProductionList)
            {
                //var feed = FeedList.Where(x => x.ProductId == product.Id).ToList();
                ProductionWP.Children.Add(new ProductionUC(product));
            }
        }
    }
}
