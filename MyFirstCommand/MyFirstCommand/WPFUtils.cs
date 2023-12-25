using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyFirstCommand
{
    public class WPFUtils
    {
        public static void AddListToWPFCombobox(List<string> list, ComboBox cbb)
        {
            cbb.ItemsSource = list;
            cbb.SelectedIndex = 0;
        }
    }
}
