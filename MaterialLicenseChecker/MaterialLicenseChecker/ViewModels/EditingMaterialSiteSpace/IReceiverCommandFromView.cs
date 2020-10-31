using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.EditingMaterialSiteSpace
{
    interface IReceiverCommandFromView
    {
        void CommandViewModelTo(GetMaterialSiteList cmd);
        void CommandViewModelTo(FetchMaterialSiteGivenSiteName cmd);
        void CommandViewModelTo(UpdateMaterialSite cmd);
        void CommandViewModelTo(DeleteMaterialSite cmd);
    }
}
