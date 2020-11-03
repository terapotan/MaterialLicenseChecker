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
using Microsoft.Win32;

using MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog;
using MaterialLicenseChecker.Views.CMainView;
using MaterialAdditional = MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// MaterialAdditionalDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class MaterialAdditionalDialog : Window
    {
        private ViewModels.MaterialAdditionalDialog.IReceiverCommandFromView ReceiverOfViewModel;

        public MaterialAdditionalDialog()
        {
            InitializeComponent();
            ReceiverOfViewModel = new MaterialAdditionalDialogViewModel();
            UpdateMaterialSiteList();

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
            MaterialLicenseChecker.Models.MaterialData AddedMaterialData = new MaterialLicenseChecker.Models.MaterialData();
            AddedMaterialData.MaterialCreationSiteName = MaterialSiteList.Text;
            AddedMaterialData.MaterialType = MaterialType.Text;
            AddedMaterialData.MaterialName = MaterialName.Text;

            MaterialAdditional.AddMaterialDataToFile cmd = new MaterialAdditional.AddMaterialDataToFile();

            cmd.AddedMaterialData = AddedMaterialData;

            //FIXME:本当はこれではまずい。なぜなら、ViewからViewへダイレクトに呼び出しているからだ。
            //ただ時間が無い。これで許してくれ……
            ReceiverOfViewModel.CommandViewModelTo(cmd);
            MainView MainViewInstance = (MainView)this.Owner;
            MainViewInstance.UpdateMaterialDataGrid();
            Close();
        }



        /*
        //以下イベント発生処理
        private void ClickedFileLocationButton(object sender, RoutedEventArgs e)
        {
            var Dialog = new OpenFileDialog();
            Dialog.Title = "素材ファイルを指定する";
            Dialog.ShowDialog();

            MaterialFilePath.Text = Dialog.FileName;
        }

        private void ClickedMaterialSiteButton(object sender, RoutedEventArgs e)
        {
            FetchMaterialSiteLIst siteLIst = new FetchMaterialSiteLIst();
            SentCommand.CommandViewModelTo(siteLIst);
            string MessageDialog = "";

            foreach (var str in siteLIst.MaterialSiteList)
            {
                MessageDialog += (str + '\n');
            }

            MessageBox.Show(MessageDialog, "素材配布サイト名一覧");
        }

        private void ClickedRegistrationButton(object sender, RoutedEventArgs e)
        {
            var Message = new AddMaterialDataToFile();

            Message.MaterialName = MaterialName.Text;
            Message.MaterialFilePath = MaterialFilePath.Text;
            Message.MaterialSiteName = MaterialSiteName.Text;

            SentCommand.CommandViewModelTo(Message);


            //FIXME:このswitch文何とかなりませんか。
            switch (Message.ProcessingResult)
            {
                case AddMaterialDataToFile.NOT_INPUT_ITEM_EXISTS:
                    MessageBox.Show("まだ入力されていない項目があります。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case AddMaterialDataToFile.MATERIALSITE_NOT_FOUND:
                    MessageBox.Show("指定された素材配布サイトが見つかりません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case AddMaterialDataToFile.PROCESS_SUCCESSFUL:
                    MessageBox.Show("登録が完了しました。", "登録完了", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainView ins = (MainView)Owner;
                    //TODO:ここらへんの、インタフェースの名前をどのように指定するか
                    //を考えなくてはならない。数が多くなると、区別できなくなる。
                    CMainView.IReceiverCommandFromView instance = ins;
                    instance.CommandViewTo(new UpdateMaterialListBox());
                    Close();
                    break;

                default:
                    break;
            }




        }
        */
    }
}
