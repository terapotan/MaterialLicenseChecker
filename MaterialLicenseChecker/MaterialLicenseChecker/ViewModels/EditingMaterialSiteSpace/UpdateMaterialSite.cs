using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.EditingMaterialSiteSpace
{
    public class UpdateMaterialSite
    {
        public MaterialSiteData ReplaceingMaterialSite;
        public string ReplacedMaterialSiteName = "";
        public int ValueInputCheckResult = -1;

        public static readonly int ACCEPTED_VALUE = 0;
        public static readonly int VALUE_EMPTY = 1;
        public static readonly int REGISTER_EXISTS_MATERALSITE = 2;
    }
}
