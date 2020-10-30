﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.EditingMaterialSiteSpace
{
    public class EditingMaterialSiteViewModel : IReceiverCommandFromView
    {
        public void CommandViewModelTo(GetMaterialSiteList cmd)
        {
            cmd.MaterialSiteList = ActiveProjectData.GetInstance().MaterialSiteListData.GetMaterialList();
        }
    }
}
