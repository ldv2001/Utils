using System;
using System.Dynamic;

namespace Utils.Events
{
    /// <summary>
    /// Class containing an <code>dynamic</code> field, effectively allowing anonymous types to be used as events parameters
    /// </summary>
    public class DynamicEventArgs : EventArgs
    {
        /// <summary>
        /// Field storing the parameters of the event args, defaults to an empy ExpandoObject
        /// </summary>
        public dynamic Args = new ExpandoObject();

        /// <summary>
        /// Initialises a new instance of the class <see cref="DynamicEventArgs"/>
        /// </summary>
        public DynamicEventArgs()
            : base()
        { }

    }
}
