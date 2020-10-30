﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.MaterialSiteAdditionalDialog
{
    public class RegisterMaterialSite
    {
        public string InputSiteName = "";
        public string InputLicenseText = "";
        public string InputTeamsOfUseURL = "";
        public string InputMemoOfMaterialSite = "";

        /// <summary>
        /// 入力として与えられた値が、有効な値であるかどうか。
        /// この値がfalseであった場合、処理を中断しなければならない。
        /// </summary>
        public int ValueInputCheckResult = -1;

        public static readonly int ACCEPTED_VALUE = 0;
        public static readonly int VALUE_EMPTY = 1;
        public static readonly int REGISTER_EXISTS_MATERALSITE = 2;
    }
}
