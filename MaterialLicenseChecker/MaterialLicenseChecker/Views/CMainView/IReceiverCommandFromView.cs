using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.Views.CMainView
{
    interface IReceiverCommandFromView
    {
        void CommandViewTo(UpdateMaterialListBox msg);
        void CommandViewTo(GetMaterialList cmd);
    }
}
