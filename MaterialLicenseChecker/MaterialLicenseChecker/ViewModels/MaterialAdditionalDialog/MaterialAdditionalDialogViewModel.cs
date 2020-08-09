using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using MaterialLicenseChecker.VAndVMCommons.MaterialAdditionalDialog;

namespace MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog
{
    class MaterialAdditionalDialogViewModel
    {
       public MaterialAdditionalDialogViewModel()
        {
            MaterialAdditionalDialogEventMessenger.Default
                .RegisterAction<ClickedFileLocationButtonEventMessage>(this, ClickedFileLocationButtonEvent);
        }

        
        private void ClickedFileLocationButtonEvent(ClickedFileLocationButtonEventMessage msg)
        {
            MessageBox.Show("テストメッセージ。表示されるか。");
        }
    }
}
