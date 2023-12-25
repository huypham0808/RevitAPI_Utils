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
        public WPFCreateColumn()
        {
            InitializeComponent();
            List<string> listTypeFamily = new List<string>() { "Cot vuong", "Cot tron", "Cot thep I" };
            WPFUtils.AddListToWPFCombobox(listTypeFamily, cbb_FamilyName);

            List<string> listLevel = new List<string>() { "Level 1", "Level 2", "Level 3" };
            WPFUtils.AddListToWPFCombobox(listLevel, cbb_BaseLevel);
            WPFUtils.AddListToWPFCombobox(listLevel, cbb_TopLevel);
        }
    }
}
