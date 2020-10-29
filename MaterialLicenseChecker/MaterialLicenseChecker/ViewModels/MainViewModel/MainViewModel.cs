using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialLicenseChecker;
using System.Windows;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.MainViewModel
{
    class MainViewModel : IReceiverCommandFromView
    {
        private ActiveProjectData activeProjectDataInstance;
        public MainViewModel()
        {
            //TODO:将来的には、プロジェクト新規作成画面で作成する。
            activeProjectDataInstance = new ActiveProjectData();
        }

        void IReceiverCommandFromView.CommandViewModelTo(DeleteMaterialDataOfFile cmd)
        {
            var FileInstance = new ClassStoreMaterialList();
            FileInstance.DeleteMaterialData(cmd.ListFromDeletedMaterialName);
        }

    }
}
