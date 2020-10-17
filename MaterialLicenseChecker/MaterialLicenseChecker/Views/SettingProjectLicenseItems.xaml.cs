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
using System.Windows.Shapes;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// SettingProjectLicenseItems.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingProjectLicenseItems : Window
    {
        public SettingProjectLicenseItems()
        {
            InitializeComponent();
        }

        private void ClickedAddingProjectLicenseItem(object sender, RoutedEventArgs e)
        {
            var window = new ProjectLicenseItemAddtional();
            window.Owner = GetWindow(this);
            window.ShowDialog();
        }

        private void ClickedEditingProjectLicenseItem(object sender, RoutedEventArgs e)
        {
            var window = new EditingProjectLicenseItem();
            window.Owner = GetWindow(this);
            window.ShowDialog();
        }
    }
}
