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
using MaterialLicenseChecker.Models;
using MainViewModel = MaterialLicenseChecker.ViewModels.MainViewModel;
using EditingMaterialSiteSpace = MaterialLicenseChecker.ViewModels.EditingMaterialSiteSpace;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// MainView.xaml の相互作用ロジック
    /// </summary>
    public partial class MainView : Window, CMainView.IReceiverCommandFromView
    {
        private MainViewModel.IReceiverCommandFromView RecevierOfViewModel;
        //ここはViewsの名前空間の中であるから、IRCFVTVインタフェースにつけるのは、CMainViewだけでよい。
        public MainView()
        {
            InitializeComponent();
            RecevierOfViewModel = new MainViewModel.MainViewModel();
            UpdateMaterialListBox();
        }



        //以下イベント発生コード

        //素材配布サイト追加クリック
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EditingMaterialSite win = new EditingMaterialSite();
            win.Owner = GetWindow(this);
            win.ShowDialog();

            
        }

        //素材追加クリック
        private void ClikedMaterialAdditionalMenuItem(object sender, RoutedEventArgs e)
        {
            Window win = new MaterialAdditionalDialog();
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }
          
        //素材削除クリック
        private void ClickedRemoveMaterialFromListButton(object sender, RoutedEventArgs e)
        {
            var cmd = new MainViewModel.DeleteMaterialDataOfFile();
            
            
            //FIXME:本当はここらへん、ViewとViewModelを分離しておいたほうがいいのだろうが
            //面倒くさいのでこのままにしている。何か不都合があれば、修正すること。

            //何も選択されずに削除コマンドが実行された場合
            if(MaterialListBox.SelectedIndex == -1)
            {
                MessageBox.Show("削除する素材が選択されていません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ListBoxItem SelectedItem = (ListBoxItem)(MaterialListBox.SelectedItem);

            cmd.ListFromDeletedMaterialName = (string)(SelectedItem.Content);

            RecevierOfViewModel.CommandViewModelTo(cmd);

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
            MaterialListFileAdapter FileInstance = new MaterialListFileAdapter();
            var MaterialNameList = FileInstance.GetMaterialNameList();

            MaterialListBox.Items.Clear();

            foreach (var MaterialName in MaterialNameList)
            {
                ListBoxItem listItem = new ListBoxItem();
                listItem.Content = MaterialName;
                MaterialListBox.Items.Add(listItem);
            }
        }

        private void ClickedGenerateProject(object sender, RoutedEventArgs e)
        {
            var window = new GenerateProject();
            window.Owner = GetWindow(this);
            window.ShowDialog();
        }

        private void ClickedSettingProjectLicenseItems(object sender, RoutedEventArgs e)
        {
            var window = new SettingProjectLicenseItems();
            window.Owner = GetWindow(this);
            window.ShowDialog();
        }
    }
}
