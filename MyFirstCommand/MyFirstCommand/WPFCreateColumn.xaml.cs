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

namespace MyFirstCommand
{
    /// <summary>
    /// Interaction logic for WPFCreateColumn.xaml
    /// </summary>
    public partial class WPFCreateColumn : Window
    {
        public WPFCreateColumn(List<string> listTypeFamily, List<string> listLevel)
        {
            InitializeComponent();
            WPFUtils.AddListToWPFCombobox(listTypeFamily, cbb_FamilyName);
            WPFUtils.AddListToWPFCombobox(listLevel, cbb_BaseLevel);
            WPFUtils.AddListToWPFCombobox(listLevel, cbb_TopLevel);

            txb_BaseOffset.Text = "0";
            txb_TopOffset.Text = "0";
        }
        private void txb_BaseOffset_TextChanged(object sender, TextChangedEventArgs e)
        {
            WPFUtils.CheckTextBoxValue(txb_BaseOffset);
        }

        private void txb_TopOffset_TextChanged(object sender, TextChangedEventArgs e)
        {
            WPFUtils.CheckTextBoxValue(txb_TopOffset);
        }

        private void btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            string pt1 = cbb_FamilyName.SelectedItem.ToString();
            MessageBox.Show(pt1);
        }
    }
}
