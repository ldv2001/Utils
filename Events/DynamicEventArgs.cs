using System;
using System.Dynamic;

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
