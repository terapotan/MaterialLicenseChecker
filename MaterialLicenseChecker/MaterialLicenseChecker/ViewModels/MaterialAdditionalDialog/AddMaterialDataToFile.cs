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
        public static readonly int NOT_INPUT_ITEM_EXISTS = 1;
        public static readonly int MATERIALSITE_NOT_FOUND = 2;
        public static readonly int PROCESS_SUCCESSFUL = 0;
        public static readonly int INITIAL_NUMBER = -1;




        public string MaterialName = "";
        public string MaterialSiteName = "";
        public string MaterialFilePath = "";
        public int ProcessingResult = INITIAL_NUMBER;
    }
}
