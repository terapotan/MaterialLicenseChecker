using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.EditingMaterialSiteSpace
{
    public class EditingMaterialSiteViewModel : IReceiverCommandFromView
    {
        public void CommandViewModelTo(GetMaterialSiteList cmd)
        {
            cmd.MaterialSiteList = ActiveProjectData.GetInstance().MaterialSiteListData.GetMaterialList();
        }
        public void CommandViewModelTo(FetchMaterialSiteGivenSiteName cmd)
        {
            cmd.FetchedMaterialSiteData = ActiveProjectData.GetInstance().MaterialSiteListData.GetMaterialSite(cmd.SearchedMaterialSiteName);
        }

        public void CommandViewModelTo(UpdateMaterialSite cmd)
        {
            try
            {
                ActiveProjectData.GetInstance().MaterialSiteListData.UpdateMaterialSite(cmd.ReplacedMaterialSiteName, in cmd.ReplaceingMaterialSite);
            }
            catch (ArgumentException e)
            {
                cmd.ValueInputCheckResult = int.Parse(e.Message);
            }
        }

        public void CommandViewModelTo(DeleteMaterialSite cmd)
        {
            ActiveProjectData.GetInstance().MaterialSiteListData.DeleteMaterialSite(cmd.DeletingMaterialSiteName);
        }
    }
}
