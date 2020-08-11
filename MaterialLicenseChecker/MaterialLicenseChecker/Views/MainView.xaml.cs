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
using MaterialLicenseChecker.Views;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// MainView.xaml の相互作用ロジック
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            MainViewModelMessanger.Default.RegisterAction<MainVewModelMessage>(this, ShowMaterilalSiteDialog);
            MainViewModelMessanger.Default.RegisterAction<GenerateNewDialogMessage>(this, GenerateNewDialog);
            MainViewModelMessanger.Default.RegisterAction<UpdatingMaterialListBoxMessage>(this, UpdatingMaterialListBoxMessage);
            UpdatingMaterialListBox();
        }


        private void UpdatingMaterialListBoxMessage(UpdatingMaterialListBoxMessage msg)
        {
            UpdatingMaterialListBox();
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

        }










        //以下それ以外の関数
        private void UpdatingMaterialListBox()
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

        /// <summary>
        /// 素材リストの右クリックを有効にしてよい状態なら、True
        /// そうでないならFalseを返す。
        /// </summary>
        /// <returns></returns>
        private bool IsEnabledMaterialListBoxContextMenu()
        {
            if (MaterialListBox.Items.Count > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }


    }
}
