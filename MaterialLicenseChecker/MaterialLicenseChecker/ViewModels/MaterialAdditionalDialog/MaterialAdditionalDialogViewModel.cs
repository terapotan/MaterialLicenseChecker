using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog
{
    class MaterialAdditionalDialogViewModel : IReceiverCommandFromView
    {
       public MaterialAdditionalDialogViewModel()
        {
            
        }

  
      

        public void CommandViewModelTo(AddMaterialDataToFile msg)
        {
            //FIXME:ここもなんだかif文が多い。
            //いや、if文があることは悪いことではないが、ここに書くべきではない気がする。
            //どこか別のところに書いたほうがいいだろう。

            ClassStoreMaterialList FileInstance = new ClassStoreMaterialList();
            MaterialSiteListFileAdapter LicenseTextInstance = new MaterialSiteListFileAdapter();

            bool MaterialSiteExists = LicenseTextInstance.MaterialSiteExists(msg.MaterialSiteName);

            if (msg.MaterialName.Equals("") || msg.MaterialFilePath.Equals("") || msg.MaterialSiteName.Equals(""))
            {
                msg.ProcessingResult = AddMaterialDataToFile.NOT_INPUT_ITEM_EXISTS;
                return;
            }

            if (!MaterialSiteExists)
            {
                msg.ProcessingResult = AddMaterialDataToFile.MATERIALSITE_NOT_FOUND;
                return;
            }

            FileInstance.AddMaterialData(msg.MaterialName, msg.MaterialFilePath, msg.MaterialSiteName);
            msg.ProcessingResult = AddMaterialDataToFile.PROCESS_SUCCESSFUL;
        }

        public void CommandViewModelTo(FetchMaterialSiteLIst msg)
        {
            MaterialSiteListFileAdapter instance = new MaterialSiteListFileAdapter();
            var MaterialSiteNameList = instance.GetMaterialSiteList();

            msg.MaterialSiteList = MaterialSiteNameList;
        }
    }
}
