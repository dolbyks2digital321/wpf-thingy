﻿using System;
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
    public partial class ProductionUC : UserControl
    {
        private Product product;
        public ProductionUC(Product _product)
        {
            InitializeComponent();
            product = _product;
            TitleTb.Text = product.Title;
            CostNewTb.Text = $"{product.NewCost} ₽";
            CostOldTb.Text = product.Cost.ToString();
            CostOldTb.Visibility = product.CostVisibility;

            var FeedList = App.db.Feedback.ToList();
            var feed = FeedList.Where(x => x.ProductId == product.Id).ToList();

            double cunt = 0;
            double sum = 0;
            Img.Source = GetImageSources(product.MainImage);
            foreach (var feeds in feed)
            {
                cunt++;
                sum += feeds.Evaluation;
            }
            double rating = sum / cunt;
            if (cunt > 0) StarAmountTb.Text = $"★{rating.ToString("0.00")}";
            else StarAmountTb.Text = "★-";


            CommentsTb.Text = $"{cunt} отзывов";
            DiscoTB.Visibility = product.CostVisibility;
            DiscoTB.Text = $"{product.Discount}% !!!";
            MainBorder.BorderBrush = product.ColorBorder;

            if (App.isAdmin == false)
            {
                BuyButt.Visibility = Visibility.Visible;
                RedactButt.Visibility = Visibility.Collapsed;
                LikeButt.Visibility = Visibility.Visible;
                DeleteButt.Visibility = Visibility.Collapsed;
            }
            else
            {
                BuyButt.Visibility=Visibility.Collapsed;
                RedactButt.Visibility=Visibility.Visible;
                LikeButt.Visibility = Visibility.Collapsed;
                DeleteButt.Visibility = Visibility.Visible;
            }
        }

        private BitmapImage GetImageSources(byte[] byteImage)
        {
            if (product.MainImage != null)
            {
                MemoryStream byteStream = new MemoryStream(byteImage);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                return image;
            }
            return new BitmapImage(new Uri(@"\Resources\school_logo.png", UriKind.Relative));
        }


        private void RedactButt_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Редактирование услуг", new AddEditPage(product)));
        }

        private void DeleteButt_Click(object sender, RoutedEventArgs e)
        {
            App.db.Product.Remove(product);
            App.db.SaveChanges();
            MessageBox.Show("Удалено: " + product.Title);
            Navigation.NextPage(new PageComponent("Список услуг", new ProductionList()));
        }

        private void BuyButt_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (App.db.OrderList.Any(X => X.ProductId == product.Id))
                {
                    error.AppendLine("Такой товар уже добавлен!");
                    MessageBox.Show(error.ToString());
                }
            
            else
            {   
                OrderList order = new OrderList();
                order.ProductId = product.Id;
                order.Amount = 1;
                order.Visible = true;
                App.db.OrderList.Add(order);
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            App.db.SaveChanges();
            MessageBox.Show("Сохранено!");

            
        }
    }
}
