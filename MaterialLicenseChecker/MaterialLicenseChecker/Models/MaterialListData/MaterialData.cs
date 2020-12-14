using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.Models
{
    public class MaterialData
    {
        public MaterialData(string InputMaterialName,string InputMaterialCreationName,string InputMaterialType,string InputMaterialFileAbsolutePath)
        {
            MaterialName = InputMaterialName;
            MaterialCreationSiteName = InputMaterialCreationName;
            MaterialType = InputMaterialType;
            MaterialFileAbsolutePath = InputMaterialFileAbsolutePath;

        }

        public MaterialData() : this("", "", "", "")
        {

        }

        public string MaterialName = "";
        public string MaterialCreationSiteName = "";
        public string MaterialType = "";
        public string MaterialFileAbsolutePath = "";
    }
}
