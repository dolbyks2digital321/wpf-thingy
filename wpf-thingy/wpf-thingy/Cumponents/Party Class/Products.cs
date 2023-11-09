using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace wpf_thingy.Cumponents
{
    public partial class Product
    {
        public decimal NewCost
        {
            get
            {
                if (Discount == 0 || Discount is null) return Cost;
                else return Cost - Cost * (decimal)Discount / 100;
            }
        }

        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                    return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }

        public SolidColorBrush ColorBorder
        {
            get
            {
                if (Discount == 0)
                    return new SolidColorBrush(Color.FromRgb(251, 169, 255));
                else return new SolidColorBrush(Color.FromRgb(117, 255, 169));
            }
        }
    }
}
