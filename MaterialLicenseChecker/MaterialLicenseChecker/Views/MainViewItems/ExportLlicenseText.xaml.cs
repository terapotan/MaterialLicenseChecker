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
    public partial class ExportLlicenseText : Window
    {
        private IReceiverCommandFromView RecevierOfViewModel;
        
        public ExportLlicenseText()
        {
            InitializeComponent();
            RecevierOfViewModel = new ExportLicenseTextViewModel();
        }

        
        private void InputPathButton(object sender, RoutedEventArgs e)
        {
            //FIMXE?:サイトを追加するときには、ここはVMとVでちゃんと分離していたが、
            //ここではそういう処理を一切行っていない。面倒くさいからこうしたわけだが、
            //果たしてこれでよかったのだろうか……
            var Dialog = new System.Windows.Forms.FolderBrowserDialog();
            Dialog.Description = "ライセンス表示を出力するディレクトリを指定";
            if(Dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }



            ExportedLicenseTextFilePath.Text = Dialog.SelectedPath;

        }
        /*

        private void ExportLicenseTextButton(object sender, RoutedEventArgs e)
        {
            //FIXME:こういうエラー処理関連はここに任せるのではなく、
            //Model側に任せた方がいいと思う。が、どちらにせよ次のリリースでの修正となるだろう。

            if (ExportedLicenseTextFilePath.Text.Equals(""))
            {
                MessageBox.Show("ファイル名が入力されていません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var cmd = new ExportLicenseText();

            CMainView.IReceiverCommandFromView ReceiverOfMainView = (MainView)(Owner);
            CMainView.GetMaterialList MaterialList = new CMainView.GetMaterialList();
            ReceiverOfMainView.CommandViewTo(MaterialList);

            cmd.MateiralNameList = MaterialList.MateiralNameList;
            cmd.ExportedLicenseTextFilePath = ExportedLicenseTextFilePath.Text;
            RecevierOfViewModel.CommandViewModelTo(cmd);


             
            MessageBox.Show("出力が完了しました。", "出力完了",MessageBoxButton.OK,MessageBoxImage.Information); ;
            Close();
        }

    */
    }

}
