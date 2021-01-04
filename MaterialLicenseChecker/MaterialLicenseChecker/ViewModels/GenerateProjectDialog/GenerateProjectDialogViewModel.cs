using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.GenerateProjectDialog
{
    public class GenerateProjectDialogViewModel : IReceiverCommandFromView
    {
        public void CommandViewModelTo(GenerateProjectFile cmd)
        {
            var Instance = new ProjectFileGenerator();
            Instance.GenerateProjectFiles(cmd.GeneratedProjectFileAbsolutePath,cmd.ProjectName);
        }
    }
}
