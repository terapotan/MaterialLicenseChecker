using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.Models
{
    /// <summary>
    /// 素材配布サイトのひとかたまりのデータを表すデータクラス。
    /// XMLで言うと、materialSite要素の内容を言う。
    /// </summary>
    public class MaterialSiteData
    {
        public string MaterialSiteName = "";
        public string LicenseText = "";
        public string TeamsOfURL = "";
        public string LicenseMemo = "";
    }
}
