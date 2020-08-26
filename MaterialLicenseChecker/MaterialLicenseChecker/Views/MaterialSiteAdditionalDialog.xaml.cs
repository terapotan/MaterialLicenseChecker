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
using MaterialLicenseChecker.VAndVMCommons.MaterialSiteAdditionalDialog;
using MaterialLicenseChecker.ViewModels.MaterialSiteAdditionalDialog;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// MaterialSiteAdditionalScreen.xaml の相互作用ロジック
    /// </summary>
    public partial class MaterialSiteAdditionalScreen : Window
    {
        public MaterialSiteAdditionalScreen()
        {
            InitializeComponent();
            //ViewModelの生成(Viewから生成するのはどうなんだ?)
            var instance = new MaterialSiteAdditionalDialogViewModel();
        }

        private void ClickedRegistrationButton(object sender, RoutedEventArgs e)
        {
            var msg = new ClickedRegistrationButtonEventMessage(this);
            msg.InputSiteName = MaterialSiteName.Text;
            msg.InputLicenseText = LicenseText.Text;

            MaterialSiteAdditionalDialogEventMessenger.Default.CallEvent(msg);

            //FIXME:if-else文が多い気がするが……何とか削ることは出来ないか?

            //FIMXE:ユーザーのことを考えるのであれば、どの項目が未入力なのか教えてあげたほうがいいだろう。
            if (msg.ValueInputCheckResult == ClickedRegistrationButtonEventMessage.VALUE_EMPTY)
            {
                MessageBox.Show("まだ入力されていない項目があります。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show("登録が完了しました。", "登録完了", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();

        }
    }
}
