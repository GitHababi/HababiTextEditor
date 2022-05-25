using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTE.Utils;

namespace HTE.Elements
{
    /// <summary>
    /// A wrapper class used to recieve input with a single function
    /// </summary>
    public class InputElement : Element
    {
        private Action<ConsoleKeyInfo> _action;
        public InputElement(ElementSettings settings, Action<ConsoleKeyInfo> action)
            : base(settings)
        {
            this._action = action;   
        }

        public override void RecieveInput(ConsoleKeyInfo key)
        {
            _action(key);
        }
    }
}
