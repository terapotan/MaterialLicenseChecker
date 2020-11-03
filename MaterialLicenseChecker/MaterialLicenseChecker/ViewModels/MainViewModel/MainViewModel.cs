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
   public class MainViewModel : IReceiverCommandFromView
    {
        public MainViewModel()
        {
            //FIXME:将来的には、別の画面でこれを作成し代入する。
            ActiveProjectData.GetInstance().MaterialSiteListData = new MaterialSiteListData();
            ActiveProjectData.GetInstance().MateiralListLogicalData = new MaterialListLogicalData();
        }

        public void CommandViewModelTo(GetMaterialList cmd)
        {
            ActiveProjectData.GetInstance().MateiralListLogicalData.GetMaterialList(cmd.MaterialDataList);
        }

        void IReceiverCommandFromView.CommandViewModelTo(DeleteMaterialDataOfFile cmd)
        {
            var FileInstance = new MaterialListFileAdapter();
            FileInstance.DeleteMaterialData(cmd.ListFromDeletedMaterialName);
        }

        void IReceiverCommandFromView.CommandViewModelTo(SetActiveProjectDataToViewModel cmd)
        {
            throw new NotImplementedException();
        }

    }
}
