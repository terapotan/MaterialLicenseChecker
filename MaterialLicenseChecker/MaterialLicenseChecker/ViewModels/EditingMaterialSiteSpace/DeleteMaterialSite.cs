using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.EditingMaterialSiteSpace
{
    public class DeleteMaterialSite
    {
        public string DeletingMaterialSiteName = "";
        public int ErrorNum = 0;//正常に終了したなら0。既にサイトが登録されている場合は-1。
    }
}
