﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.ExportLicenseText
{
    interface IReceiverCommandFromView
    {
        void CommandViewModelTo(ExportLicenseText cmd);
        void CommandViewModelTo(GetSavedInputItems cmd);
        void CommandViewModelTo(SaveInputItems cmd);
    }
}
