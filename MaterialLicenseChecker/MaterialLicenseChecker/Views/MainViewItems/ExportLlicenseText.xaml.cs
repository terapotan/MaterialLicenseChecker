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

using MaterialLicenseChecker.ViewModels.ExportLicenseText;
using CMainView = MaterialLicenseChecker.Views.CMainView;
using Microsoft.Win32;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// ExportLlicenseText.xaml の相互作用ロジック
    /// </summary>
    public partial class ExportLicenseText : Window
    {
        private IReceiverCommandFromView RecevierOfViewModel;
        
        public ExportLicenseText()
        {
            InitializeComponent();
            RecevierOfViewModel = new ExportLicenseTextViewModel();
            SetValueOfInputItemsIntoForm();
        }

        private void SetValueOfInputItemsIntoForm()
        {
            MaterialLicenseChecker.Models.LicenseTextInputsItemsData FetchedInputItems = new MaterialLicenseChecker.Models.LicenseTextInputsItemsData();
            GetSavedInputItems cmd = new GetSavedInputItems();
            cmd.FetchedInputItemsData = FetchedInputItems;
            RecevierOfViewModel.CommandViewModelTo(cmd);

            ExportedLicenseTextFilePath.Text = cmd.FetchedInputItemsData.ExportingDirectory;
            ExportedLicenseTextFileName.Text = cmd.FetchedInputItemsData.FileName;
            FooterText.Text= cmd.FetchedInputItemsData.FooterText;
            HeaderText.Text = cmd.FetchedInputItemsData.HeaderText;
        }

        private void SaveValueOfInputItemsIntoFile()
        {
            Models.LicenseTextInputsItemsData SetInputItems = new Models.LicenseTextInputsItemsData();
            SetInputItems.ExportingDirectory = ExportedLicenseTextFilePath.Text;
            SetInputItems.FileName = ExportedLicenseTextFileName.Text;
            SetInputItems.FooterText = FooterText.Text;
            SetInputItems.HeaderText = HeaderText.Text;

            SaveInputItems cmd = new SaveInputItems();
            cmd.SavedInputItemsData = SetInputItems;
            RecevierOfViewModel.CommandViewModelTo(cmd);
        }

        private void InputPathButton(object sender, RoutedEventArgs e)
        {
            var Dialog = new System.Windows.Forms.FolderBrowserDialog();
            Dialog.Description = "ライセンス表示を出力するディレクトリを指定";
            if(Dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }



            ExportedLicenseTextFilePath.Text = Dialog.SelectedPath;

        }
    

        private void ExportLicenseTextButton(object sender, RoutedEventArgs e)
        {
            //FIXME:こういうエラー処理関連はここに任せるのではなく、
            //Model側に任せた方がいいと思う。が、どちらにせよ次のリリースでの修正となるだろう。

            if (ExportedLicenseTextFileName.Text.Equals(""))
            {
                MessageBox.Show("ファイル名が入力されていません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //FIXME:不正な文字列が入力されたとき(\とか)は、エラーを吐くようにしたい。
            var cmd = new ViewModels.ExportLicenseText.ExportLicenseText();
            cmd.ExportedLicenseTextFileAbsolutePath = ExportedLicenseTextFilePath.Text + '\\' + ExportedLicenseTextFileName.Text;
            cmd.FooterText = FooterText.Text;
            cmd.HeaderText = HeaderText.Text;
            RecevierOfViewModel.CommandViewModelTo(cmd);


             
            MessageBox.Show("出力が完了しました。", "出力完了",MessageBoxButton.OK,MessageBoxImage.Information); ;
            SaveValueOfInputItemsIntoFile();
            Close();
        }

        private void ClickedCancelButton(object sender, RoutedEventArgs e)
        {
            SaveValueOfInputItemsIntoFile();
            Close();
        }
    }

}
