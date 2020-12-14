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
        void CommandViewModelTo(FetchMaterialSiteLIst cmd);
        void CommandViewModelTo(FetchMaterialData cmd);
        void CommandViewModelTo(UpdateMaterialDataToFile cmd);
    }
}
