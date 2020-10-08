using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.MaterialSiteAdditionalDialog
{
    class MaterialSiteAdditionalDialogViewModel : IReceiverCommandFromView
    {
        ClassStoreLicenseText XMLFileInstance;
        public MaterialSiteAdditionalDialogViewModel()
        {
            XMLFileInstance = new ClassStoreLicenseText();
        }

        public void CommandViewModelTo(RegisterMaterialSite cmd)
        {
            cmd.ValueInputCheckResult = RegisterMaterialSite.ACCEPTED_VALUE;
            try
            {
                XMLFileInstance.AddLicenseText(cmd.InputSiteName, cmd.InputLicenseText);
            }
            catch (ArgumentException e)
            {
                cmd.ValueInputCheckResult = ConvertAddLicenseTextFuncFromMsgViewToMsg(int.Parse(e.Message));
            }
        }

        private int ConvertAddLicenseTextFuncFromMsgViewToMsg(int AddLicenseTextFuncFromMsg)
        {
            return AddLicenseTextFuncFromMsg;
        }

    }
}
