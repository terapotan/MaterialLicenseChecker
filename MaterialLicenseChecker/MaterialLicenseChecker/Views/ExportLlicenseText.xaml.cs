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
            var Dialog = new OpenFileDialog();
            Dialog.Title = "ライセンス文を出力するファイルを指定";
            Dialog.ShowDialog();

            ExportedLicenseTextFilePath.Text = Dialog.FileName;

        }

        private void ExportLicenseTextButton(object sender, RoutedEventArgs e)
        {
            ExportLicenseTextEventMessenger.Default.CallEvent(new ClickedExportLicenseTextEventMessage(this));
        }
        
    }
}
