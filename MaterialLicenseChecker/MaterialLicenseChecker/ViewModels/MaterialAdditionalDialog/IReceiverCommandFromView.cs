using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog
{
    interface IReceiverCommandFromView
    {
        void CommandViewModelTo(AddMaterialDataToFile msg);
        void CommandViewModelTo(FetchMaterialSiteLIst msg);
    }
}
