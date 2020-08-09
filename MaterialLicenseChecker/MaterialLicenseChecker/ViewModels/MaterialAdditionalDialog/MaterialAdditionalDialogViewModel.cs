using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

using MaterialLicenseChecker.VAndVMCommons.MaterialAdditionalDialog;

namespace MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog
{
    class MaterialAdditionalDialogViewModel
    {
       public MaterialAdditionalDialogViewModel()
        {
            MaterialAdditionalDialogEventMessenger.Default
                .RegisterAction<ClickedFileLocationButtonEventMessage>(this, ClickedFileLocationButtonEvent);
            MaterialAdditionalDialogEventMessenger.Default
                .RegisterAction<ClickedMaterialSiteButtonEventMessage>(this, ClickedMaterialButtonEvent);
        }


        private void ClickedMaterialButtonEvent(ClickedMaterialSiteButtonEventMessage msg)
        {
            Task.Factory.StartNew(() =>

                MessageBox.Show("モードレスダイアログ")

            );
        }

        private void ClickedFileLocationButtonEvent(ClickedFileLocationButtonEventMessage msg)
        {
            var Dialog = new OpenFileDialog();
            Dialog.Title = "素材ファイルを指定する";
            Dialog.ShowDialog();

            var message = new SetValueFilePathTextBoxMessage(this);
            message.SetValue = Dialog.FileName;

            MaterialAdditionalDialogMessenger.Default.ExecuteAction(this, message);
        }
    }
}
