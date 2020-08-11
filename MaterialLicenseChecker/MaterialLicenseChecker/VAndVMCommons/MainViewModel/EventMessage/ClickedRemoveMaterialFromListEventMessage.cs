using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MainViewModel.EventMessage
{
    class ClickedRemoveMaterialFromListEventMessage : BaseEventMessage
    {
        public ClickedRemoveMaterialFromListEventMessage(object sender) : base(sender)
        {

        }
    }
}
