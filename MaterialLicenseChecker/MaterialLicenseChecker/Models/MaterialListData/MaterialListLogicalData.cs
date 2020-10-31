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
    }

}
