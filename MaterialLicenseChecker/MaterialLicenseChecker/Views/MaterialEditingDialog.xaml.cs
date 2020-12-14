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

using MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog;
using MaterialLicenseChecker.Views.CMainView;
using MaterialAdditional = MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// MaterialEditingDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class MaterialEditingDialog : Window
    {
        private ViewModels.MaterialAdditionalDialog.IReceiverCommandFromView ReceiverOfViewModel;
        private string ReplacedMaterialName = "";
        public MaterialEditingDialog(string InputMaterialName)
        {
            //FIXME:本来はViewModelも別々にすべきなのだろうが……
            //時間が無いので、ひとまずMaterialAdditionalDialogの方とViewModelは共有する
            ReplacedMaterialName = InputMaterialName;
            InitializeComponent();
            ReceiverOfViewModel = new MaterialAdditionalDialogViewModel();

            UpdateMaterialSiteList();

            var cmd = new MaterialAdditional.FetchMaterialData();
            cmd.SearchMaterialName = InputMaterialName;
            ReceiverOfViewModel.CommandViewModelTo(cmd);

            MaterialName.Text = cmd.FetchedMaterialData.MaterialName;
            MaterialType.Text = cmd.FetchedMaterialData.MaterialType;
            FileAbsoluteLocationPath.Text = cmd.FetchedMaterialData.MaterialFileAbsolutePath;
            MaterialSiteList.Text = cmd.FetchedMaterialData.MaterialCreationSiteName;
        }

        private void ClickedMaterialSiteListButton(object sender, RoutedEventArgs e)
        {
            EditingMaterialSite win = new EditingMaterialSite();
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void ClickedUpdateMaterialSiteListButton(object sender, RoutedEventArgs e)
        {
            UpdateMaterialSiteList();
        }

        private void UpdateMaterialSiteList()
        {
            List<string> MaterialSiteNameList;
            MaterialAdditional.FetchMaterialSiteLIst cmd = new MaterialAdditional.FetchMaterialSiteLIst();
            ReceiverOfViewModel.CommandViewModelTo(cmd);

            MaterialSiteNameList = cmd.MaterialSiteList;

            MaterialSiteList.Items.Clear();

            foreach (var MaterialSiteName in MaterialSiteNameList)
            {
                ListBoxItem listItem = new ListBoxItem();
                listItem.Content = MaterialSiteName;
                MaterialSiteList.Items.Add(listItem);
            }
        }

        private void ClickedCancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClickedOKButton(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MaterialName.Text))
            {
                MessageBox.Show("素材名を入力してください", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(MaterialSiteList.Text))
            {
                MessageBox.Show("素材配布サイトを選択してください。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(MaterialType.Text))
            {
                MessageBox.Show("ファイルの種類を選択してください。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MaterialLicenseChecker.Models.MaterialData UpdateMaterialData = new MaterialLicenseChecker.Models.MaterialData();
            UpdateMaterialData.MaterialCreationSiteName = MaterialSiteList.Text;
            UpdateMaterialData.MaterialType = MaterialType.Text;
            UpdateMaterialData.MaterialName = MaterialName.Text;
            UpdateMaterialData.MaterialFileAbsolutePath = "";//将来的には実装される

            UpdateMaterialDataToFile cmd = new UpdateMaterialDataToFile();

            cmd.ReplacedMaterialData = UpdateMaterialData;
            cmd.ReplacedMaterialName = ReplacedMaterialName;

            //FIXME:本当はこれではまずい。なぜなら、ViewからViewへダイレクトに呼び出しているからだ。
            //ただ時間が無い。これで許してくれ……
            ReceiverOfViewModel.CommandViewModelTo(cmd);
            MainView MainViewInstance = (MainView)this.Owner;
            MainViewInstance.UpdateMaterialDataGrid();
            Close();
        }
    }
}
