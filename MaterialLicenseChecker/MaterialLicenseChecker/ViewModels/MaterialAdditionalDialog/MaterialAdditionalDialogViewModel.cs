using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

using MaterialLicenseChecker.VAndVMCommons.MaterialAdditionalDialog;
using MaterialLicenseChecker.VAndVMCommons.MainViewModel;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog
{
    class MaterialAdditionalDialogViewModel : IReceiverCommandFromView
    {
       public MaterialAdditionalDialogViewModel()
        {
            MaterialAdditionalDialogEventMessenger.Default
                .RegisterAction<ClickedFileLocationButtonEventMessage>(this, ClickedFileLocationButtonEvent);
            MaterialAdditionalDialogEventMessenger.Default
                .RegisterAction<ClickedMaterialSiteButtonEventMessage>(this, ClickedMaterialButtonEvent);
            MaterialAdditionalDialogEventMessenger.Default
                .RegisterAction<ClickedRegistrationButtonEventMessage>(this,ClickedregistrationButtonEvent);
        }


        private void ClickedregistrationButtonEvent(ClickedRegistrationButtonEventMessage msg)
        {
            ClassStoreMaterialList FileInstance = new ClassStoreMaterialList();
            ClassStoreLicenseText LicenseTextInstance = new ClassStoreLicenseText();

            bool MaterialSiteExists = LicenseTextInstance.MaterialSiteExists(msg.MaterialSiteName);
            
            if (msg.MaterialName.Equals("") || msg.MaterialFilePath.Equals("") || msg.MaterialSiteName.Equals(""))
            {
                MessageBox.Show("まだ入力されていない項目があります。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!MaterialSiteExists)
            {
                MessageBox.Show("指定された素材配布サイトが見つかりません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }



            FileInstance.AddMaterialData(msg.MaterialName, msg.MaterialFilePath, msg.MaterialSiteName);
            MainViewModelMessanger.Default.ExecuteAction(this, new UpdatingMaterialListBoxMessage(this));
            MaterialAdditionalDialogMessenger.Default.ExecuteAction(this, new RegistrationProcessingCompleteMessage(this));
        }

        
        

        private void ClickedMaterialButtonEvent(ClickedMaterialSiteButtonEventMessage msg)
        {
            ClassStoreLicenseText instance = new ClassStoreLicenseText();
            var MaterialSiteNameList = instance.GetMaterialSiteList();
            string MessageDialog = "";

            foreach (var str in MaterialSiteNameList)
            {
                MessageDialog += (str + '\n');
            }

            MessageBox.Show(MessageDialog, "素材配布サイト名一覧");

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

        public void CommandViewModelTo(AddMaterialDataToFile msg)
        {
            throw new NotImplementedException();
        }
    }
}
