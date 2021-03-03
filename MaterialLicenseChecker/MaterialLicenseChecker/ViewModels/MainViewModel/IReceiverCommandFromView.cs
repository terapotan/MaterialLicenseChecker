using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.MainViewModel
{
    interface IReceiverCommandFromView
    {
        void CommandViewModelTo(DeleteMaterialDataOfFile cmd);
        void CommandViewModelTo(SetActiveProjectDataToViewModel cmd);
        void CommandViewModelTo(GetMaterialList cmd);
        void CommandViewModelTo(LoadProjectFile cmd);
        void CommandViewModelTo(GetProjectName cmd);

    }
}
