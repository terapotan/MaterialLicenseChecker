using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.Models
{
    public sealed class ActiveProjectData
    {
        private static readonly ActiveProjectData _singleInstance = new ActiveProjectData();
        public MaterialSiteListData MaterialSiteList;

        public static ActiveProjectData GetInstance()
        {
            return _singleInstance;
        }

        private ActiveProjectData()
        {
        }

    }
}
