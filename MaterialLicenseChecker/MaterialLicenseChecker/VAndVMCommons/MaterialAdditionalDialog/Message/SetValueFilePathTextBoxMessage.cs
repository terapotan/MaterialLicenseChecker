using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MaterialAdditionalDialog
{
    class SetValueFilePathTextBoxMessage : BaseMessage
    {
        public SetValueFilePathTextBoxMessage(object sender) : base(sender)
        {

        }

        public string SetValue = "";

    }
}
