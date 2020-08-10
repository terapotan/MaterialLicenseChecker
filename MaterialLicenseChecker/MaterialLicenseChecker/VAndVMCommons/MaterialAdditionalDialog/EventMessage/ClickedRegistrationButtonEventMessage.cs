using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MaterialAdditionalDialog
{
    class ClickedRegistrationButtonEventMessage : BaseEventMessage
    {
        public ClickedRegistrationButtonEventMessage(object sender) : base(sender)
        {

        }

        public string MaterialName = "";
        public string MaterialSiteName = "";
        public string MaterialFilePath = "";

    }
}
