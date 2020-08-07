using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MaterialSiteAdditionalDialog
{
    class MaterialSiteAdditionalDialogEventMessenger : BaseEventMessenger
    {
        public static MaterialSiteAdditionalDialogEventMessenger Default { get; } = new MaterialSiteAdditionalDialogEventMessenger();

    }
}
