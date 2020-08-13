﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.ExportLicenseText
{
    class ClickedExportLicenseTextEventMessage : BaseEventMessage
    {
        public ClickedExportLicenseTextEventMessage(object sender) : base(sender)
        {

        }

        public string ExportedLicenseTextFilePath = "";
    }
}