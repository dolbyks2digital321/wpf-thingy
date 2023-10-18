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
//using wpf_thingy.Cumponents.Party_Class;

namespace wpf_thingy.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductionUC.xaml
    /// </summary>
    public partial class ProductionUC : UserControl
    {
        public ProductionUC(Product product)
        {
            InitializeComponent();
            TitleTb.Text = product.Title;
            CostNewTb.Text = product.NewCost.ToString();
            CostOldTb.Text = product.Cost.ToString();
            CostOldTb.Visibility = product.CostVisibility;

            var FeedList = App.db.Feedback.ToList();
            var feed = FeedList.Where(x => x.ProductId == product.Id).ToList();

            double cunt = 0;
            double sum = 0;
            //Img.Source = GetImageSources(product.MainImage);
            foreach (var feeds in feed)
            {
                cunt++;
                sum += feeds.Evaluation;
            }
            double rating = sum / cunt;
            //MessageBox.Show($"{sum} / {cunt} = {rating}");
            StarAmountTb.Text = $"★{rating.ToString("0.00")}";

        }

        //public BitmapImage GetImageSources(byte[] byteImage)
        //{
        //    MemoryStream byteStream = new MemoryStream(byteImage);
        //    BitmapImage image = new BitmapImage();
        //    image.BeginInit();
        //    image.StreamSource = byteStream;
        //    image.EndInit();
        //    return image;
        //}
    }
}
