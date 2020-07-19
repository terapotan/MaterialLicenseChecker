using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialLicenseChecker;
using System.Windows;


namespace MaterialLicenseChecker.ViewModels
{
    class MainViewModel
    {
        //以下のコードは「getはpublicにしたいが、setはprivateとしたい」目的で書かれている。
        private DelegateCommand _ShowDialogCommand;

        public DelegateCommand ShowDialogCommand
        {
            get
            {
                //Privateな変数に代入することをを忘れないように!!!
                //Publicな変数に対して動作を行うと……何も表示されなくなる
                if(_ShowDialogCommand == null)
                {
                    _ShowDialogCommand = new DelegateCommand(
                        _ => MessageBox.Show("fff"));
                }

                return _ShowDialogCommand;
            }
        }

    }
}
