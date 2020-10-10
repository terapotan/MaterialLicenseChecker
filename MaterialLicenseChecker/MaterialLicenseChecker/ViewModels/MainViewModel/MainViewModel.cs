using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialLicenseChecker;
using System.Windows;
using MaterialLicenseChecker.Models;
using MaterialLicenseChecker.VAndVMCommons.MainViewModel;

namespace MaterialLicenseChecker.ViewModels.MainViewModel
{
    class MainViewModel : IReceiverCommandFromView
    {
        public MainViewModel()
        {
        }

        void IReceiverCommandFromView.CommandViewModelTo(DeleteMaterialDataOfFile cmd)
        {
            var FileInstance = new ClassStoreMaterialList();
            FileInstance.DeleteMaterialData(cmd.ListFromDeletedMaterialName);
        }

    }
}
