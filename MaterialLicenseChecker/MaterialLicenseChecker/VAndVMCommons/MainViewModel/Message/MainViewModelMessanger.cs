﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker;

namespace MaterialLicenseChecker.VAndVMCommons.MainViewModel
{
    class MainViewModelMessanger : BaseMessanger
    {
        public static MainViewModelMessanger Default { get; } = new MainViewModelMessanger();
    }
}
