﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.MaterialSiteAdditionalDialog
{
    class MaterialSiteAdditionalDialogViewModel : IReceiverCommandFromView
    {
        MaterialSiteListData MaterialSiteDataAInstance;
        public MaterialSiteAdditionalDialogViewModel()
        {
            MaterialSiteDataAInstance = new MaterialSiteListData();
        }

        public void CommandViewModelTo(RegisterMaterialSite cmd)
        {
            cmd.ValueInputCheckResult = RegisterMaterialSite.ACCEPTED_VALUE;
            try
            {
                MaterialSiteDataAInstance.AddMaterialSite(cmd.InputSiteName,cmd.InputTeamsOfUseURL,cmd.InputLicenseText,cmd.InputMemoOfMaterialSite);
            }
            catch (ArgumentException e)
            {
                cmd.ValueInputCheckResult = ConvertAddLicenseTextFuncFromMsgViewToMsg(int.Parse(e.Message));
            }
        }

        private int ConvertAddLicenseTextFuncFromMsgViewToMsg(int AddLicenseTextFuncFromMsg)
        {
            return AddLicenseTextFuncFromMsg;
        }

    }
}
