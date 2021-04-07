using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.Models
{
    public class MaterialListLogicalData
    {
        private MaterialListFileAdapter materialListFileAdapter;
        public MaterialListLogicalData()
        {
            materialListFileAdapter = new MaterialListFileAdapter();
        }
        public void AddMaterialData(MaterialData AddedMaterialData)
        {
            materialListFileAdapter.AddMaterialData(AddedMaterialData);
        }

        public void GetMaterialList(List<MaterialData> OutputMaterialData)
        {
            materialListFileAdapter.GetMaterialList(OutputMaterialData);
        }

        public void DeleteMaterialData(string MaterialName)
        {
            materialListFileAdapter.DeleteMaterialData(MaterialName);
        }

        public MaterialData FetchMaterialData(string MaterialName)
        {
            return materialListFileAdapter.FetchMaterialData(MaterialName);
        }

        public void UpdateMaterialData(string ReplacedMaterialName,MaterialData ReplacedMaterialData)
        {
            materialListFileAdapter.DeleteMaterialData(ReplacedMaterialName);
            materialListFileAdapter.AddMaterialData(ReplacedMaterialData);
        }
        /// <summary>
        /// 既に登録されている素材リストの中で、指定されたサイトが登録されていないかチェックする。
        /// あったらtrue、なかったらfalse。
        /// </summary>
        /// <param name="MaterialCreationName"></param>
        /// <returns></returns>
        public bool SiteInMaterialListExists(string MaterialCreationName)
        {
            var AllMaterialData = new List<MaterialData>();
            var SiteNameList = new List<string>();
            GetMaterialList(AllMaterialData);

            //取り出した全素材データから、サイト名のみを取り出す。
            foreach (var FetchedMaterialData in AllMaterialData)
            {
                SiteNameList.Add(FetchedMaterialData.MaterialCreationSiteName);
            }

            if(SiteNameList.Exists(str => str == MaterialCreationName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
