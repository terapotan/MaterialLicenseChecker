﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels
{
    public interface ISettableActiveProjectData
    {
        void SetActiveProjectData(ref ActiveProjectData SetProjectData);
    }
}
