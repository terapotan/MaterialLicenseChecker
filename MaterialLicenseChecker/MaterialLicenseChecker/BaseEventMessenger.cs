using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker
{
    class BaseEventMessenger
    {
        //本クラスを使用する際には、該当のクラスへ継承した後次のコードを挿入すること。
        //public static Messenger Default { get; } = new Messenger();
        //Messengerは、該当のクラス名に置き換えること。

            private List<ActionInfo> RegisteredActionList = new List<ActionInfo>();


            public void RegisterAction<MessageType>(object sender, Action<MessageType> action)
            {
                RegisteredActionList.Add(new ActionInfo
                {
                    MessageType = typeof(MessageType),
                    sender = sender,
                    action = action
                });
            }

            public void CallEvent<MessageType>(MessageType message)
            {
                //与えられたメッセージの型が一致しているデリゲートのみをLINQを用いて
                //取り出す。

                var query = RegisteredActionList.Where(o =>
                o.MessageType == message.GetType())
                .Select(o => o.action as Action<MessageType>);

            //取り出したデリゲートの実行


            //FIXME:なぜか多重起動するためこうしているが、
            //何か根本的な欠陥がある気がする。将来的には、ListではなくDictの構造にして
            //一度に一回しかイベントが呼び出されないようにするべきである。

            int i = 0;
                
                foreach (var action in query)
                {
                    if(i == 1)
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

