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
            //FIXME:将来的には、MaterialSiteDataを用いた追加方式に変更すること。
            materialSiteListFileInstance.AddLicenseText(SiteName, TeamsOfUseURL, LicenseText, MemoOfMaterialSite);
        }
        
        public List<string> GetMaterialList()
        {
            return materialSiteListFileInstance.GetMaterialSiteList();
        }

        public MaterialSiteData GetMaterialSite(string SearchedMaterialSiteName)
        {
            return materialSiteListFileInstance.GetMaterialSite(SearchedMaterialSiteName);
        }

        /// <summary>
        /// ReplacedMaterialSiteNameの素材配布サイトをMaterialSiteDataで置き換えます。
        /// </summary>
        /// <param name="ReplaceingMaterialSiteData"></param>
        /// <param name="MaterialSiteData"></param>
        public void UpdateMaterialSite(string ReplacedMaterialSiteName, in MaterialSiteData ReplaceingMaterialSiteData)
        {
            //FIXME:本来は削除する前に、双方のサイトの妥当性チェックを行うべきである。
            //そうしないと、削除はうまくいったが追加が上手くいかないという致命的な事態に陥る可能性がある。
            DeleteMaterialSite(ReplacedMaterialSiteName);
            AddMaterialSite(ReplaceingMaterialSiteData.MaterialSiteName,
                ReplaceingMaterialSiteData.TeamsOfURL,
                ReplaceingMaterialSiteData.LicenseText,
                ReplaceingMaterialSiteData.LicenseMemo);
        }

        public void DeleteMaterialSite(string DeletingMaterialSiteName)
        {
            materialSiteListFileInstance.DeleteMaterialSite(DeletingMaterialSiteName);
        }

        public bool MaterialSiteExists(string MaterialSiteName)
        {
            return materialSiteListFileInstance.MaterialSiteExists(MaterialSiteName);
        }


    }
}
