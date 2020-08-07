using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MaterialSiteAdditionalDialog
{
    class ClickedRegistrationButtonEventMessage: BaseEventMessage
    {
        public ClickedRegistrationButtonEventMessage(object sender) : base(sender)
        {

        }

        public string InputSiteName = "";
        public string InputLicenseText = "";
    }
}
