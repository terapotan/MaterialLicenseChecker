﻿using System;
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

            //取り出したデリゲートの実行

            foreach (var action in query)
            {
                action(message);
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