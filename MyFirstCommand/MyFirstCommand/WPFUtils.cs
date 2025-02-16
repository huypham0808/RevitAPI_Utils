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
        public static void CheckTextBoxValue(TextBox textBox)
        {
            string bo = textBox.Text;
            bool check = double.TryParse(bo, out double val1);
            if (!check && bo != string.Empty)
            {
                MessageBox.Show("Input number");
                textBox.Clear();
                textBox.Text = "0";
            }
        }
    }
}
