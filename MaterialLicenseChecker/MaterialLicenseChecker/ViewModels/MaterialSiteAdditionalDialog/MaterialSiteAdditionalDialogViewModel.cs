using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;
using MaterialLicenseChecker.VAndVMCommons.MaterialSiteAdditionalDialog;

namespace MaterialLicenseChecker.ViewModels.MaterialSiteAdditionalDialog
{
    class MaterialSiteAdditionalDialogViewModel : IReceiverCommandFromView
    {
        ClassStoreLicenseText XMLFileInstance;
        public MaterialSiteAdditionalDialogViewModel()
        {
            MaterialSiteAdditionalDialogEventMessenger.Default.
                    RegisterAction<ClickedRegistrationButtonEventMessage>
                    (this, ClickedRegistrationButtonEvent);

            XMLFileInstance = new ClassStoreLicenseText();
        }

        public void CommandViewModelTo(RegisterMaterialSite cmd)
        {
            throw new NotImplementedException();
        }

        private void ClickedRegistrationButtonEvent(ClickedRegistrationButtonEventMessage msg)
        {
            //FIXME:こういう入力チェックの処理を何か画一的にまとめる方法はないものか
            if(msg.InputSiteName.Equals("") || msg.InputLicenseText.Equals(""))
            {
                msg.ValueInputCheckResult = ClickedRegistrationButtonEventMessage.VALUE_EMPTY;
                return;
            }

            var LicenseTextsInstance = new ClassStoreLicenseText();

            if (LicenseTextsInstance.MaterialSiteExists(msg.InputSiteName))
            {
                msg.ValueInputCheckResult = ClickedRegistrationButtonEventMessage.REGISTER_EXISTS_MATERALSITE;
                return;
            }

            msg.ValueInputCheckResult = ClickedRegistrationButtonEventMessage.ACCEPTED_VALUE;
            XMLFileInstance.AddLicenseText(msg.InputSiteName, msg.InputLicenseText);
        }


    }
}
