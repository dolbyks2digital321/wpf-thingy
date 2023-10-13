using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_thingy.Cumponents
{
    public partial class Product
    {
        public string NewCost
        {
            get
            {
                if (Discount == 0) return $"{Cost}";
                else return Cost.ToString();
            }
        }
    }
}
