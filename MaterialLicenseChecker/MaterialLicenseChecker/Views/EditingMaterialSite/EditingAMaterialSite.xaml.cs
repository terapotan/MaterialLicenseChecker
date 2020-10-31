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
using EditingMaterialSiteSpace = MaterialLicenseChecker.ViewModels.EditingMaterialSiteSpace;
using MaterialSiteDataSpace = MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// EditingAMaterialSite.xaml の相互作用ロジック
    /// </summary>
    public partial class EditingAMaterialSite : Window
    {
        private string editingMaterialSite;
        private EditingMaterialSiteSpace.IReceiverCommandFromView ReceiverOfView;

        public EditingAMaterialSite(string EditingMaterialSiteName)
        {
            InitializeComponent();
            ReceiverOfView = new EditingMaterialSiteSpace.EditingMaterialSiteViewModel();
            editingMaterialSite = EditingMaterialSiteName;
            SetMaterialSiteValue(EditingMaterialSiteName);
        }

        private void ClickedEditingLicenseCheckItems(object sender, RoutedEventArgs e)
        {
            Window win = new EditingLicenseCheckItems();
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void SetMaterialSiteValue(string EditingMaterialSiteName)
        {
            MaterialSiteDataSpace.MaterialSiteData SiteData = new MaterialSiteDataSpace.MaterialSiteData();
            EditingMaterialSiteSpace.FetchMaterialSiteGivenSiteName cmd = new EditingMaterialSiteSpace.FetchMaterialSiteGivenSiteName();
            cmd.FetchedMaterialSiteData = SiteData;
            cmd.SearchedMaterialSiteName = EditingMaterialSiteName;
            ReceiverOfView.CommandViewModelTo(cmd);

            SiteName.Text = cmd.FetchedMaterialSiteData.MaterialSiteName;
            TeamsOfUseURL.Text = cmd.FetchedMaterialSiteData.TeamsOfURL;
            LicenseText.Text = cmd.FetchedMaterialSiteData.LicenseText;
            LicenseMemo.Text = cmd.FetchedMaterialSiteData.LicenseMemo;
        }

        private void ClickedOKButton(object sender, RoutedEventArgs e)
        {
            EditingMaterialSiteSpace.UpdateMaterialSite cmd = new EditingMaterialSiteSpace.UpdateMaterialSite();
            
            var ReplaceingMaterialSiteData = new MaterialSiteDataSpace.MaterialSiteData();
            ReplaceingMaterialSiteData.MaterialSiteName = SiteName.Text;
            ReplaceingMaterialSiteData.TeamsOfURL = TeamsOfUseURL.Text;
            ReplaceingMaterialSiteData.LicenseText = LicenseText.Text;
            ReplaceingMaterialSiteData.LicenseMemo = LicenseMemo.Text;

            cmd.ReplacedMaterialSiteName = editingMaterialSite;
            cmd.ReplaceingMaterialSite = ReplaceingMaterialSiteData;

            ReceiverOfView.CommandViewModelTo(cmd);

            MessageBox.Show("編集が完了しました。", "編集完了", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
