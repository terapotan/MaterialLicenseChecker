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
            //MaterialAdditionalDialogEventMessenger.Default
            //    .RegisterAction<ClickedMaterialSiteButtonEventMessage>(this, ClickedMaterialButtonEvent);
            //MaterialAdditionalDialogEventMessenger.Default
            //    .RegisterAction<ClickedRegistrationButtonEventMessage>(this,ClickedregistrationButtonEvent);
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

      

        public void CommandViewModelTo(AddMaterialDataToFile msg)
        {
            //FIXME:ここもなんだかif文が多い。
            //いや、if文があることは悪いことではないが、ここに書くべきではない気がする。
            //どこか別のところに書いたほうがいいだろう。

            ClassStoreMaterialList FileInstance = new ClassStoreMaterialList();
            ClassStoreLicenseText LicenseTextInstance = new ClassStoreLicenseText();

            bool MaterialSiteExists = LicenseTextInstance.MaterialSiteExists(msg.MaterialSiteName);

            if (msg.MaterialName.Equals("") || msg.MaterialFilePath.Equals("") || msg.MaterialSiteName.Equals(""))
            {
                msg.ProcessingResult = AddMaterialDataToFile.NOT_INPUT_ITEM_EXISTS;
                return;
            }

            if (!MaterialSiteExists)
            {
                msg.ProcessingResult = AddMaterialDataToFile.MATERIALSITE_NOT_FOUND;
                return;
            }

            FileInstance.AddMaterialData(msg.MaterialName, msg.MaterialFilePath, msg.MaterialSiteName);
            msg.ProcessingResult = AddMaterialDataToFile.PROCESS_SUCCESSFUL;
            //MainViewModelMessanger.Default.ExecuteAction(this, new UpdatingMaterialListBoxMessage(this));
            //MaterialAdditionalDialogMessenger.Default.ExecuteAction(this, new RegistrationProcessingCompleteMessage(this));
        }

        public void CommandViewModelTo(FetchMaterialSiteLIst msg)
        {
            ClassStoreLicenseText instance = new ClassStoreLicenseText();
            var MaterialSiteNameList = instance.GetMaterialSiteList();

            msg.MaterialSiteList = MaterialSiteNameList;
        }
    }
}
