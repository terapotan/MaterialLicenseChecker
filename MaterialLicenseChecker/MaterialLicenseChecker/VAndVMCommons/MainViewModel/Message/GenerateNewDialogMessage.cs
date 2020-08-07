using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MainViewModel
{
    class GenerateNewDialogMessage : BaseMessage
    {
        public GenerateNewDialogMessage(object sender) : base(sender)
        {

        }

        public int GeneratingDialogNumber = -1;
        public const int MATERIAL_SITE_WINDOW = 0;
        public const int MATERIAL_WINDOW = 1;

    }
}
