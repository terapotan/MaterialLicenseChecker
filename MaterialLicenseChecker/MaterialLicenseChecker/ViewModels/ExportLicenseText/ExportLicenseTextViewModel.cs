using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.ExportLicenseText
{
    class ExportLicenseTextViewModel : IReceiverCommandFromView
    {
        public ExportLicenseTextViewModel()
        {
        }

        public void CommandViewModelTo(ExportLicenseText cmd)
        {
            //今のところ全てのデータを一気に読み込んで処理する形としている。
            //ただ将来的にデータ量が多くなった場合、処理に限界が来る可能性がある。
            //素材名だけ読み込むようにすることで幾分か処理は低減できるが、そこまでするくらいなら
            //素直にデータベースを使ったほうがいいだろう

            ExportingLicenseText Instance = new ExportingLicenseText(cmd.ExportedLicenseTextFileAbsolutePath);
            MaterialSiteListFileAdapter MaterialSiteInstance = new MaterialSiteListFileAdapter();
            MaterialListFileAdapter MaterialInstance = new MaterialListFileAdapter();

            var AllMaterialData = new List<MaterialData>();
            var SiteNameList = new List<string>();
            MaterialInstance.GetMaterialList(AllMaterialData);

            //取り出した全素材データから、サイト名のみを取り出す。
            foreach (var FetchedMaterialData in AllMaterialData)
            {
                SiteNameList.Add(FetchedMaterialData.MaterialCreationSiteName);
            }

            //重複したサイト名を削除する(実際の削除動作は下のfor文)
            IEnumerable<string> DistinctedResult = SiteNameList.Distinct();


            var list = MaterialSiteInstance.GetLicenseTextLists(DistinctedResult);

            string strs = "";
            foreach (var str in list)
            {
                strs += (str + '\n');
            }

            Instance.WriteLicenseTextFile(cmd.HeaderText + '\n' + strs + cmd.FooterText);

        }


    }
}
