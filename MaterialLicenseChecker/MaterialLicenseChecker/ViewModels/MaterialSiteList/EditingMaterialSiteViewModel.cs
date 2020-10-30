using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.MaterialSiteList
{
    public class EditingMaterialSiteViewModel
    {
        private ActiveProjectData activeProjectData;

        public void SetActiveProjectData(ref ActiveProjectData PassedActiveProjectData )
        {
            activeProjectData = PassedActiveProjectData;
        }

    }
}
