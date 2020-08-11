using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MaterialAdditionalDialog
{
    class MaterialAdditionalDialogEventMessenger : BaseEventMessenger
    {
        public static MaterialAdditionalDialogEventMessenger Default { get; } = new MaterialAdditionalDialogEventMessenger();
    }
}
