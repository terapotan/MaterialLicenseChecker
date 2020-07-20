using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MaterialLicenseChecker
{
    /// <summary>
    /// コマンドを使う際のヘルパクラス。
    /// </summary>
    class DelegateCommand : ICommand
    {
        /// <summary>
        /// 実際のコマンド内容をデリゲートにて保持
        /// </summary>
        private Action<object> _Execute;

        /// <summary>
        /// コマンドが実行可能かどうか判断する処理をデリゲートにて保持
        /// </summary>
        private Func<object, bool> _CanExecute;

        //実行コマンドしか渡されていない場合、canExecuteにはnullが代入される。
        //nullが代入されると「どんな時であろうと実行可能」と見なされる。
        public DelegateCommand(Action<object> Execute) : this(Execute, null)
        {

        }

        public DelegateCommand(Action<object> Execute, Func<object, bool> CanExecute)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        //以下ICommandインタフェースの実装

        /* CanExecuteChangedイベントとは、実行コマンドの実行条件が変わった時に呼び出されるイベント。
         * このイベントを呼び出せば、現在のコマンドの実行可能・実行不可に応じてViewの状態が変わる。
         * はずである。
         */

        /// <summary>
        /// CanExecuteChangedイベントを発生させる。
        /// </summary>
        public static void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// コマンドの実行可能・実行不可判定処理を行う。
        /// 実質的には、クラス内部にあるデリゲートを呼び出しているだけ。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _CanExecute == null ? true : _CanExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }


        public void Execute(object parameter)
        {
            _Execute?.Invoke(parameter);
        }

    }
}
