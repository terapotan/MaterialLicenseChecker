using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.Views.CMainView
{
    interface IReceiverCommandFromViewToView
    {
        void CommandViewModelTo(UpdateMaterialListBox msg);
    }
}
