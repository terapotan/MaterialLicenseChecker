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

using MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog;
using MaterialLicenseChecker.VAndVMCommons.MaterialAdditionalDialog;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// MaterialAdditionalDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class MaterialAdditionalDialog : Window
    {
        public MaterialAdditionalDialog()
        {
            InitializeComponent();
            MaterialAdditionalDialogViewModel instance = new MaterialAdditionalDialogViewModel();

            MaterialAdditionalDialogMessenger.Default.RegisterAction<SetValueFilePathTextBoxMessage>(this, SetValueFilePathTextBoxEvent);
        }

        private void SetValueFilePathTextBoxEvent(SetValueFilePathTextBoxMessage msg)
        {
            MaterialFilePath.Text = msg.SetValue;
        }










        //以下イベント発生処理
        private void ClickedFileLocationButton(object sender, RoutedEventArgs e)
        {
            MaterialAdditionalDialogEventMessenger.Default.CallEvent(new ClickedFileLocationButtonEventMessage(this));
        }

        private void ClickedMaterialSiteButton(object sender, RoutedEventArgs e)
        {
            MaterialAdditionalDialogEventMessenger.Default.CallEvent(new ClickedMaterialSiteButtonEventMessage(this));
        }

        private void ClickedRegistrationButton(object sender, RoutedEventArgs e)
        {
            var Message = new ClickedRegistrationButtonEventMessage(this);

            Message.MaterialName = MaterialName.Text;
            Message.MaterialFilePath = MaterialFilePath.Text;
            Message.MaterialSiteName = MaterialSiteName.Text;

            MaterialAdditionalDialogEventMessenger.Default.CallEvent(Message);
        }
    }
}
