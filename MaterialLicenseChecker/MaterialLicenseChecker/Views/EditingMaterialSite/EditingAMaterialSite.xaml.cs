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
    /// EditingAMaterialSite.xaml の相互作用ロジック
    /// </summary>
    public partial class EditingAMaterialSite : Window
    {
        private string editingMaterialSite;
        public EditingAMaterialSite(string EditingMaterialSiteName)
        {
            InitializeComponent();
            editingMaterialSite = EditingMaterialSiteName;
            MessageBox.Show(editingMaterialSite);
        }

        private void ClickedEditingLicenseCheckItems(object sender, RoutedEventArgs e)
        {
            Window win = new EditingLicenseCheckItems();
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }
    }
}
