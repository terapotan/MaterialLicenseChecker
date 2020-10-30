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
using MaterialSiteList = MaterialLicenseChecker.ViewModels.MaterialSiteList;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// EditingMaterialSite.xaml の相互作用ロジック
    /// </summary>
    public partial class EditingMaterialSite : Window
    {
        private MaterialSiteList.EditingMaterialSiteViewModel receiverOfViewModel;
        public EditingMaterialSite()
        {
            receiverOfViewModel = new MaterialSiteList.EditingMaterialSiteViewModel();
            InitializeComponent();
        }

        public void GetViewModelInstance(out MaterialSiteList.EditingMaterialSiteViewModel ViewModelInstance)
        {
            ViewModelInstance = receiverOfViewModel;
        }

        private void ClickedEditingAMaterialSite(object sender, RoutedEventArgs e)
        {
            Window win = new EditingAMaterialSite();
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void ClickedMaterialSiteAdditional(object sender, RoutedEventArgs e)
        {
            Window win = new MaterialSiteAdditionalScreen();
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void ClickedDeletingMaterialSiteButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("素材配布サイト「配布サイト名」に関するデータは完全に削除されます。\n本当に削除しますか?", "素材配布サイトの削除", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
