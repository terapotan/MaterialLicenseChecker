﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MaterialAdditionalDialog
{
    class MaterialAdditionalDialogMessenger : BaseMessanger
    {
        public static MaterialAdditionalDialogMessenger Default { get; } = new MaterialAdditionalDialogMessenger();

    }
}