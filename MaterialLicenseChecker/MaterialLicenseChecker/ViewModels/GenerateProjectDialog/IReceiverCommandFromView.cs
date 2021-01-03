using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.GenerateProjectDialog
{
    interface IReceiverCommandFromView
    {
        void CommandViewModelTo(GenerateProjectFile cmd);
    }
}
