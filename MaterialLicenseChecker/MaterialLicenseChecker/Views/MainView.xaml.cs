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
using MainViewModel = MaterialLicenseChecker.ViewModels.MainViewModel;
using EditingMaterialSiteSpace = MaterialLicenseChecker.ViewModels.EditingMaterialSiteSpace;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using System.Data;

namespace MaterialLicenseChecker.Views
{
    public class MaterialDataGrid
    {
        //!!!!:データバインドしたいものは「プロパティ」でなければならない。
        //要するにgetとsetを付ければいい。そうでないと、いくらがんばってもバインディングされない!!
        public string MaterialType { get; set; }
        public string MaterialName { get; set; }
        public string MaterialSiteName { get; set; }

        public MaterialDataGrid(string MaterialType,string MaterialName,string MaterialSiteName)
        {
            this.MaterialName = MaterialName;
            this.MaterialType = MaterialType;
            this.MaterialSiteName = MaterialSiteName;
        }
    }

    public class SelectedContact
    {
        public string MaterialType { get; set; }
        public string MaterialName { get; set; }
        public string MaterialSiteName { get; set; }
    }

    /// <summary>
    /// MainView.xaml の相互作用ロジック
    /// </summary>
    public partial class MainView : Window, CMainView.IReceiverCommandFromView
    {
        private MainViewModel.IReceiverCommandFromView RecevierOfViewModel;
        //ここはViewsの名前空間の中であるから、IRCFVTVインタフェースにつけるのは、CMainViewだけでよい。

        public ObservableCollection<MaterialDataGrid> MaterialItemSource { get; set; }
        public ObservableCollection<SelectedContact> SelectedMaterialItem { get; set; }



        public MainView()
        {
            InitializeComponent();
            RecevierOfViewModel = new MainViewModel.MainViewModel();
            MaterialItemSource = new ObservableCollection<MaterialDataGrid>();
            this.DataContext = RecevierOfViewModel;


            //行番号表示
            this.MaterialListTable.LoadingRow += ((s, e) =>
            {
                e.Row.Header = (e.Row.GetIndex()+1).ToString();
            });

            UpdateMaterialDataGrid();
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
            
            //何も選択されずに削除コマンドが実行された場合
            if(MaterialListTable.SelectedIndex == -1)
            {
                MessageBox.Show("削除する素材が選択されていません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var cellInfo = MaterialListTable.SelectedCells[0];
            var content = cellInfo.Column.GetCellContent(cellInfo.Item);
            MaterialDataGrid SelectedData = (MaterialDataGrid)content.DataContext;
            MessageBox.Show(SelectedData.MaterialName);

            MaterialItemSource.Remove(SelectedData);
            MaterialListTable.ItemsSource = MaterialItemSource;
            return;
            /*
            ListBoxItem SelectedItem = (ListBoxItem)(MaterialListTable.SelectedItem);

            cmd.ListFromDeletedMaterialName = (string)(SelectedItem.Content);

            RecevierOfViewModel.CommandViewModelTo(cmd);

            MaterialListTable.Items.Remove(SelectedItem);

            MessageBox.Show("削除が完了しました。", "削除完了", MessageBoxButton.OK, MessageBoxImage.Information);
            */
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
            UpdateMaterialDataGrid();
        }

        void CMainView.IReceiverCommandFromView.CommandViewTo(CMainView.GetMaterialList cmd)
        {
            var MaterialListItems = MaterialListTable.Items;

            foreach (ListBoxItem OneListItem in MaterialListItems)
            {
                cmd.MateiralNameList.Add(OneListItem.Content as string);
            }
        }


        public void UpdateMaterialDataGrid()
        {
            var MaterialNameList = new List<MaterialLicenseChecker.Models.MaterialData>();

            var cmd = new MainViewModel.GetMaterialList();

            cmd.MaterialDataList = MaterialNameList;

            RecevierOfViewModel.CommandViewModelTo(cmd);

            //DataGridの値を全てクリア
            MaterialListTable.ItemsSource = null;

            //もし、管理対象の素材が一件もない場合は、
            //ここで離脱。
            if (cmd.MaterialDataList.Count == 0)
            {
                return;
            }

            MaterialItemSource = new ObservableCollection<MaterialDataGrid>();

            foreach (var MaterialData in cmd.MaterialDataList)
            {
                //CMainView.MaterialDataGrid Row = new CMainView.MaterialDataGrid();
                MaterialItemSource.Add(new MaterialDataGrid(MaterialData.MaterialType,MaterialData.MaterialName, MaterialData.MaterialCreationSiteName ));
            }

            //前述のif文によってInitialMaterialItemSourceがNullにならないことは保障されている。
            MaterialListTable.ItemsSource = MaterialItemSource;
            //MaterialListTable.Items.Refresh();

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
