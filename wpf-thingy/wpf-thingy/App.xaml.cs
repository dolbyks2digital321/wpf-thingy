using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using wpf_thingy.Cumponents;

namespace wpf_thingy
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareShop312Entities2 db = new HardwareShop312Entities2();
        public static bool isAdmin = false;
    }
}
