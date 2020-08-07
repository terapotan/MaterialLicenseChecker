using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;
using MaterialLicenseChecker.VAndVMCommons.MaterialSiteAdditionalDialog;

namespace MaterialLicenseChecker.ViewModels.MaterialSiteAdditionalDialog
{
    class MaterialSiteAdditionalDialogViewModel
    {
        ClassStoreLicenseText XMLFileInstance;
        public MaterialSiteAdditionalDialogViewModel()
        {
            MaterialSiteAdditionalDialogEventMessenger.Default.
                    RegisterAction<ClickedRegistrationButtonEventMessage>
                    (this, ClickedRegistrationButtonEvent);

            XMLFileInstance = new ClassStoreLicenseText();
        }

        private void ClickedRegistrationButtonEvent(ClickedRegistrationButtonEventMessage msg)
        {
            XMLFileInstance.AddLicenseText(msg.InputSiteName, msg.InputLicenseText);
        }
    }
}
