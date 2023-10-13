using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace wpf_thingy.Cumponents
{
    public partial class Product
    {
        public string NewCost
        {
            get
            {
                if (Discount == 0) return $"{Cost} ₽";
                else return $"{Cost - Cost * (decimal)Discount/100} ₽";
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

        public string Comments_Amount
        {
            get
            {
                //SqlConnection conn = new SqlConnection(@"Server=(local);Database=Sample_db;Trusted_Connection=Yes;");
                //conn.Open();
                //string cmd = "SELECT f.Evaluation FROM Feedback f WHERE ";
                var feeds = App.db.Feedback.ToList();
                foreach (var feed in feeds)
                {
                    if (feed.Product = ProductID);
                }
                return "";
            }
        }   
    }
}
