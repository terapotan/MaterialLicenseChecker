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
using MaterialSiteAdditional = MaterialLicenseChecker.ViewModels.MaterialSiteAdditionalDialog;
using System.Text.RegularExpressions;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// EditingMaterialSite.xaml の相互作用ロジック
    /// </summary>
    public partial class EditingMaterialSite : Window
    {
        private EditingMaterialSiteSpace.EditingMaterialSiteViewModel ReceiverOfViewModel;
        public EditingMaterialSite()
        {
            ReceiverOfViewModel = new EditingMaterialSiteSpace.EditingMaterialSiteViewModel();
            InitializeComponent();
            UpdateMaterialSiteListBox();
        }

        private void ClickedEditingAMaterialSite(object sender, RoutedEventArgs e)
        {
            //何の項目も選択されていない場合
            if (MaterialSiteListBox.SelectedIndex == -1)
            {
                MessageBox.Show("編集したい項目を選択してください。", "項目の未選択", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var SelectedListBoxItem = (ListBoxItem)MaterialSiteListBox.ItemContainerGenerator.ContainerFromItem(MaterialSiteListBox.SelectedItem);

            Window win = new EditingAMaterialSite((string)SelectedListBoxItem.Content);
            win.Owner = GetWindow(this);
            win.ShowDialog();
            UpdateMaterialSiteListBox();
        }

        private void ClickedMaterialSiteAdditional(object sender, RoutedEventArgs e)
        {
            Window win = new MaterialSiteAdditionalScreen();
            win.Owner = GetWindow(this);
            win.ShowDialog();
            UpdateMaterialSiteListBox();
        }

        private void ClickedDeletingMaterialSiteButton(object sender, RoutedEventArgs e)
        {
            //何の項目も選択されていない場合
            if (MaterialSiteListBox.SelectedIndex == -1)
            {
                MessageBox.Show("削除したい項目を選択してください。", "項目の未選択", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var SelectedListBoxItem = (ListBoxItem)MaterialSiteListBox.ItemContainerGenerator.ContainerFromItem(MaterialSiteListBox.SelectedItem);
            EditingMaterialSiteSpace.DeleteMaterialSite cmd = new EditingMaterialSiteSpace.DeleteMaterialSite();
            cmd.DeletingMaterialSiteName = (string)SelectedListBoxItem.Content;

            var UserInput = MessageBox.Show("素材配布サイト「" + cmd.DeletingMaterialSiteName + "」に関するデータは完全に削除されます。\n本当に削除しますか?", "素材配布サイトの削除", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (UserInput == MessageBoxResult.No)
            {
                return;
            }

            ReceiverOfViewModel.CommandViewModelTo(cmd);

            if(cmd.ErrorNum == -1)
            {
                MessageBox.Show("素材配布サイト「" + cmd.DeletingMaterialSiteName + "」が登録されている素材が存在します。\n先にその素材を削除してください。", "登録済み", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            UpdateMaterialSiteListBox();
        }

        private void UpdateMaterialSiteListBox()
        {
            List<string> MaterialSiteNameList;
            EditingMaterialSiteSpace.GetMaterialSiteList cmd = new EditingMaterialSiteSpace.GetMaterialSiteList();
            ReceiverOfViewModel.CommandViewModelTo(cmd);

            MaterialSiteNameList = cmd.MaterialSiteList;

            MaterialSiteListBox.Items.Clear();

            foreach (var MaterialSiteName in MaterialSiteNameList)
            {
                ListBoxItem listItem = new ListBoxItem();
                listItem.Content = MaterialSiteName;
                MaterialSiteListBox.Items.Add(listItem);
            }
        }

        private void MaterialSiteListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // 選択中のアイテムの ListBoxItem を取得
            var SelectedListBoxItem = (ListBoxItem)MaterialSiteListBox.ItemContainerGenerator.ContainerFromItem(MaterialSiteListBox.SelectedItem);
            // アイテム上でダブルクリックされた場合
            if (SelectedListBoxItem?.InputHitTest(e.GetPosition(SelectedListBoxItem)) != null)
            {
                Window win = new EditingAMaterialSite((string)SelectedListBoxItem.Content);
                win.Owner = GetWindow(this);
                win.ShowDialog();
                UpdateMaterialSiteListBox();
            }
        }

        private void ClickedTeamsOfUse(object sender, RoutedEventArgs e)
        {
            //何の項目も選択されていない場合
            if (MaterialSiteListBox.SelectedIndex == -1)
            {
                MessageBox.Show("利用規約を表示したい項目を選択してください。", "項目の未選択", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var SelectedListBoxItem = (ListBoxItem)MaterialSiteListBox.ItemContainerGenerator.ContainerFromItem(MaterialSiteListBox.SelectedItem);
            var MaterialSite = new MaterialLicenseChecker.Models.MaterialSiteData();

            EditingMaterialSiteSpace.FetchMaterialSiteGivenSiteName cmd = new EditingMaterialSiteSpace.FetchMaterialSiteGivenSiteName();
            cmd.SearchedMaterialSiteName = (string)SelectedListBoxItem.Content;
            cmd.FetchedMaterialSiteData = MaterialSite;

            ReceiverOfViewModel.CommandViewModelTo(cmd);

            //利用規約に入っている文字列が、空白文字もしくは空文字列以外で、なおかつ有効なURL形式であった場合
            if (!string.IsNullOrWhiteSpace(cmd.FetchedMaterialSiteData.TeamsOfURL) && Regex.IsMatch(cmd.FetchedMaterialSiteData.TeamsOfURL, @"^s?https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+$"))
            {
                System.Diagnostics.Process.Start(cmd.FetchedMaterialSiteData.TeamsOfURL);
            } else
            {
                MessageBox.Show("利用規約URLには、httpもしくはhttpsから始まるURLを入力してください。", "不正な形式", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
    }
}
