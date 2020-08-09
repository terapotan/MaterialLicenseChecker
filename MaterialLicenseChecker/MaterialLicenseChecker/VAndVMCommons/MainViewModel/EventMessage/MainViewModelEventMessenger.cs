using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MainViewModel
{
    class MainViewModelEventMessenger : BaseEventMessenger
    {
        public static MainViewModelEventMessenger Default { get; } = new MainViewModelEventMessenger();

    }
}
