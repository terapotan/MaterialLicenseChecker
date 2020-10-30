using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.Models
{
    public class MaterialSiteListData
    {
        private MaterialSiteListFileAdapter materialSiteListFileInstance;
        public MaterialSiteListData()
        {
            materialSiteListFileInstance = new MaterialSiteListFileAdapter();
        }

        public void AddMaterialSite(string SiteName,string TeamsOfUseURL,string LicenseText,string MemoOfMaterialSite)
        {
            materialSiteListFileInstance.AddLicenseText(SiteName, TeamsOfUseURL, LicenseText, MemoOfMaterialSite);
        }
        
        public List<string> GetMaterialList()
        {
            return materialSiteListFileInstance.GetMaterialSiteList();
        }

    }
}
