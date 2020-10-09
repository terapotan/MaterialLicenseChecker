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

//FIXME:大抵というか原則として、ViewとViewModelは一組である。
//そこで、一組にした名前空間を別に作ってViewsと階層構造にするというのはどうか。
//たぶんそのほうがいいのでは?
using MaterialLicenseChecker.VAndVMCommons.MainViewModel;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// MainView.xaml の相互作用ロジック
    /// </summary>
    public partial class MainView : Window, CMainView.IReceiverCommandFromView
    {
        //ここはViewsの名前空間の中であるから、IRCFVTVインタフェースにつけるのは、CMainViewだけでよい。
        public MainView()
        {
            InitializeComponent();
            MainViewModelMessanger.Default.RegisterAction<MainVewModelMessage>(this, ShowMaterilalSiteDialog);
            MainViewModelMessanger.Default.RegisterAction<GenerateNewDialogMessage>(this, GenerateNewDialog);
            MainViewModelMessanger.Default.RegisterAction<UpdatingMaterialListBoxMessage>(this, UpdatingMaterialListBoxMessage);
            MainViewModelMessanger.Default.RegisterAction<GetMaterialListMessage>(this, GetMaterialList);
            UpdateMaterialListBox();
        }


        private void UpdatingMaterialListBoxMessage(UpdatingMaterialListBoxMessage msg)
        {
            UpdateMaterialListBox();
        }


        private void ShowMaterilalSiteDialog(MainVewModelMessage msg)
        {

            var win = new MaterialSiteAdditionalScreen();
            win.Owner = GetWindow(this);
            win.ShowDialog();

        }

        private void GenerateNewDialog(GenerateNewDialogMessage msg)
        {
            //FIXME:今はswitch文で書いているが、何かいい案はないだろうか?
            Window win = null;

            switch (msg.GeneratingDialogNumber)
            {
                case GenerateNewDialogMessage.MATERIAL_SITE_WINDOW:
                    win = new MaterialSiteAdditionalScreen();
                    break;
                case GenerateNewDialogMessage.MATERIAL_WINDOW:
                    win = new MaterialAdditionalDialog();
                    break;
                default:
                    break;
            }

            win.Owner = GetWindow(this);
            win.ShowDialog();

        }

        private void GetMaterialList(GetMaterialListMessage msg)
        {

            var MaterialListItems = MaterialListBox.Items;

            foreach (ListBoxItem OneListItem in MaterialListItems)
            {
                msg.MateiralNameList.Add(OneListItem.Content as string);
            }


            
        }




        //以下イベント発生コード

        //素材配布サイト追加クリック
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainViewModelEventMessenger.Default
                .CallEvent(new ClickedMaterialSiteMenuEventMessage(this));
        }

        //素材追加クリック
        private void ClikedMaterialAdditionalMenuItem(object sender, RoutedEventArgs e)
        {
            MainViewModelEventMessenger.Default
            .CallEvent(new ClickedMaterialAdditionalMenuEventMessage(this));
        }

        //素材削除クリック
        private void ClickedRemoveMaterialFromListButton(object sender, RoutedEventArgs e)
        {
            var msg = new ClickedRemoveMaterialFromListEventMessage(this);
            
            
            //FIXME:本当はここらへん、ViewとViewModelを分離しておいたほうがいいのだろうが
            //面倒くさいのでこのままにしている。何か不都合があれば、修正すること。

            //何も選択されずに削除コマンドが実行された場合
            if(MaterialListBox.SelectedIndex == -1)
            {
                MessageBox.Show("削除する素材が選択されていません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ListBoxItem SelectedItem = (ListBoxItem)(MaterialListBox.SelectedItem);

            msg.ListFromDeletedMaterialName = (string)(SelectedItem.Content);

            MainViewModelEventMessenger.Default.CallEvent(msg);

            MaterialListBox.Items.Remove(SelectedItem);

            MessageBox.Show("削除が完了しました。", "削除完了", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        //このソフトウェアについてをクリック
        private void ClickedAboutSoftwareMenu(object sender,RoutedEventArgs e)
        {
            var window = new AboutThisSoftware();
            window.Owner = GetWindow(this);
            window.ShowDialog();
        }

        //ライセンス出力ボタンをクリック
        private void ExportLicenseTextButton(object sender, RoutedEventArgs e)
        {
            var window = new ExportLlicenseText();
            window.Owner = GetWindow(this);
            window.ShowDialog();
        }










        //以下それ以外の関数
        void CMainView.IReceiverCommandFromView.CommandViewTo(CMainView.UpdateMaterialListBox cmd)
        {
            UpdateMaterialListBox();
        }

        void CMainView.IReceiverCommandFromView.CommandViewTo(CMainView.GetMaterialList cmd)
        {
            var MaterialListItems = MaterialListBox.Items;

            foreach (ListBoxItem OneListItem in MaterialListItems)
            {
                cmd.MateiralNameList.Add(OneListItem.Content as string);
            }
        }


        private void UpdateMaterialListBox()
        {
            ClassStoreMaterialList FileInstance = new ClassStoreMaterialList();
            var MaterialNameList = FileInstance.GetMaterialNameList();

            MaterialListBox.Items.Clear();

            foreach (var MaterialName in MaterialNameList)
            {
                ListBoxItem listItem = new ListBoxItem();
                listItem.Content = MaterialName;
                MaterialListBox.Items.Add(listItem);
            }
        }

    }
}
