using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Utils.Events
{
    public class DynamicEventArgs : EventArgs
    {
        public readonly dynamic Args = new ExpandoObject();

        public DynamicEventArgs()
            : base()
        { }

    }
}
