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
using MaterialLicenseChecker.VAndVMCommons.ExportLicenseText;
using Microsoft.Win32;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// ExportLlicenseText.xaml の相互作用ロジック
    /// </summary>
    public partial class ExportLlicenseText : Window
    {
        public ExportLlicenseText()
        {
            InitializeComponent();
            _ = new ExportLicenseTextViewModel();
        }

        private void InputPathButton(object sender, RoutedEventArgs e)
        {
            //FIMXE?:サイトを追加するときには、ここはVMとVでちゃんと分離していたが、
            //ここではそういう処理を一切行っていない。面倒くさいからこうしたわけだが、
            //果たしてこれでよかったのだろうか……
            var Dialog = new SaveFileDialog();
            Dialog.Title = "ライセンス表示を出力するファイルを指定";
            Dialog.DefaultExt = ".txt";
            Dialog.ShowDialog();

            ExportedLicenseTextFilePath.Text = Dialog.FileName;

        }

        private void ExportLicenseTextButton(object sender, RoutedEventArgs e)
        {
            var msg = new ClickedExportLicenseTextEventMessage(this);
            msg.ExportedLicenseTextFilePath = ExportedLicenseTextFilePath.Text;
            ExportLicenseTextEventMessenger.Default.CallEvent(msg);
            MessageBox.Show("出力が完了しました。", "出力完了",MessageBoxButton.OK,MessageBoxImage.Information); ;
            Close();
        }
        
    }
}
