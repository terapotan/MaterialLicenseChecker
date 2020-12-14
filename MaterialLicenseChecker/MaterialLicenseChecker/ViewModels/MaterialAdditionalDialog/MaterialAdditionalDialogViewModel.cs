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


            //MaterialListFileAdapter FileInstance = new MaterialListFileAdapter();
            //MaterialSiteListFileAdapter LicenseTextInstance = new MaterialSiteListFileAdapter();

            //bool MaterialSiteExists = LicenseTextInstance.MaterialSiteExists(msg.MaterialSiteName);

            //if (msg.MaterialName.Equals("") || msg.MaterialFilePath.Equals("") || msg.MaterialSiteName.Equals(""))
            //{
            //    msg.ProcessingResult = AddMaterialDataToFile.NOT_INPUT_ITEM_EXISTS;
            //    return;
            //}

            //FIXME:将来的に例外処理も実装すること。
            //現状は、コンポボックスで素材配布サイトを指定しており、この例外が発生する可能性は少ないと
            //見られるため処理の実装を省略する。
            /*
            if (!MaterialSiteExists)
            {
                msg.ProcessingResult = AddMaterialDataToFile.MATERIALSITE_NOT_FOUND;
                return;
            }
            */

            ActiveProjectData.GetInstance().MateiralListLogicalData.AddMaterialData(msg.AddedMaterialData);

            //msg.ProcessingResult = AddMaterialDataToFile.PROCESS_SUCCESSFUL;
        }

        //TODO:ここに、素材リストを取得するコマンドを追加する。
        
        public void CommandViewModelTo(FetchMaterialSiteLIst msg)
        {
            MaterialSiteListFileAdapter instance = new MaterialSiteListFileAdapter();
            var MaterialSiteNameList = instance.GetMaterialSiteList();

            msg.MaterialSiteList = MaterialSiteNameList;
        }

        public void CommandViewModelTo(FetchMaterialData cmd)
        {
            MaterialListLogicalData instance = new MaterialListLogicalData();
            var FetchedMaterialData = instance.FetchMaterialData(cmd.SearchMaterialName);
            cmd.FetchedMaterialData = FetchedMaterialData;
            //MessageBox.Show(FetchedMaterialData.MaterialCreationSiteName);
        }

        public void CommandViewModelTo(UpdateMaterialDataToFile cmd)
        {
            ActiveProjectData.GetInstance().MateiralListLogicalData.UpdateMaterialData(cmd.ReplacedMaterialName, cmd.ReplacedMaterialData);
        }
    }
}
