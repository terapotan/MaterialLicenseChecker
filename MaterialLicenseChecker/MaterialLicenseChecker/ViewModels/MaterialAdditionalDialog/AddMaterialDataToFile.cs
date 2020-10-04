using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.MaterialAdditionalDialog
{
    /// <summary>
    /// 素材名を管理するファイルに素材データを追加する
    /// </summary>
    public class AddMaterialDataToFile
    {
        public const int NOT_INPUT_ITEM_EXISTS = 1;
        public const int MATERIALSITE_NOT_FOUND = 2;
        public const int PROCESS_SUCCESSFUL = 0;
        public const int INITIAL_NUMBER = -1;




        public string MaterialName = "";
        public string MaterialSiteName = "";
        public string MaterialFilePath = "";
        public int ProcessingResult = INITIAL_NUMBER;
    }
}
