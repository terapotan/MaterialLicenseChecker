using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialLicenseChecker.ViewModels.GenerateProjectDialog
{
    public class GenerateProjectDialogViewModel : IReceiverCommandFromView
    {
        public void CommandViewModelTo(GenerateProjectFile cmd)
        {
            MessageBox.Show(cmd.GeneratedProjectFileAbsolutePath);
        }
    }
}
