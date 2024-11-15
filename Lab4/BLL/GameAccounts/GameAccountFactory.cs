using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.GameAccounts
{
    public static class GameAccountFactory
    {
        public static BaseGameAccount GetAccount(AccountType type, params object?[]? args)
        {
            Type? t = type.GetAttributeType();
            if (t == null)
            {
                throw new ArgumentException($"Type {type} is unknown", nameof(type));
            }
            if (!t.IsSubclassOf(typeof(BaseGameAccount)))
            {
                throw new ArgumentException($"{type} is not subclass of {nameof(BaseGameAccount)}", nameof(type));
            }
            return (BaseGameAccount)Activator.CreateInstance(t, args)!;
        }
    }
}
