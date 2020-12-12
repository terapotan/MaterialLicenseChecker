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
        public void AddMaterialData(in MaterialData AddedMaterialData)
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
    }

}
