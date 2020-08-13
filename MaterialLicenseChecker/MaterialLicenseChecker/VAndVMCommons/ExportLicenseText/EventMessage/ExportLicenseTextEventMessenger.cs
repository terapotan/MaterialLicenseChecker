using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.ExportLicenseText
{
    class ExportLicenseTextEventMessenger : BaseEventMessenger
    {
        public static ExportLicenseTextEventMessenger Default { get; } = new ExportLicenseTextEventMessenger();

    }
}
