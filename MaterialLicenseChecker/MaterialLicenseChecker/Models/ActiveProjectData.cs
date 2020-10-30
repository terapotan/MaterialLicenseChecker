using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.Models
{
    public class ActiveProjectData
    {
        public MaterialSiteListFileAdapter materialSiteListFileAdapter;

        public ActiveProjectData()
        {
            materialSiteListFileAdapter = new MaterialSiteListFileAdapter();
        }
    }
}
