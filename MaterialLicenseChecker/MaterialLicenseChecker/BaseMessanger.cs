using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialLicenseChecker
{
    //本クラスを使用する際には、該当のクラスへ継承した後次のコードを挿入すること。
    //public static Messenger Default { get; } = new Messenger();
    //Messengerは、該当のクラス名に置き換えること。

    public class BaseMessanger
    {
        private List<ActionInfo> RegisteredActionList = new List<ActionInfo>();


        public void RegisterAction<MessageType>(FrameworkElement recipient,Action<MessageType> action)
        {
            RegisteredActionList.Add(new ActionInfo
            {
                MessageType = typeof(MessageType),
                sender = recipient.DataContext,
                action = action
            });
        }

        public void ExecuteAction<MessageType>(object sender,MessageType message)
        {
            //与えられた送り主とメッセージの型が一致しているデリゲートのみをLINQを用いて
            //取り出す。

            var query = RegisteredActionList.Where(o =>
            o.MessageType == message.GetType())
            .Select(o => o.action as Action<MessageType>);

            //FIXME:BaseEventMessangerクラスで多重起動のバグが発生した。
            //応急処置でとりあえず治ったが、同様の仕組みを採用しているこのクラスでも
            //同様のバグが発生する可能性が高い。BaseMessangerクラスと同様、このクラスも
            //Dictを用いたイベント登録システムに変更したほうがいいだろう。
            //そうすれば、原理的に一つの関数しか呼び出すことが出来なくなる。

            //取り出したデリゲートの実行

            int i = 0;

            foreach (var action in query)
            {
                if (i == 1)
                {
                    break;
                }

                action(message);
                i = 1;
            }
        }
    

        private class ActionInfo 
        {
            public Type MessageType { get; set; }
            public object sender { get; set; }
            public Delegate action { get; set; }
        }
    }
}
