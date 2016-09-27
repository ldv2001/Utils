using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Events
{
    public class EventArgs<T> : EventArgs
    {
        public T Value { get; set; }

        public EventArgs(T value) : base()
        {
            this.Value = value;
        }

        public EventArgs() : base()
        {}

    }
}
