﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.MainViewModel
{
    interface IReceiverCommandFromView
    {
        void CommandViewModelTo(DeleteMaterialDataOfFile cmd);
    }
}
