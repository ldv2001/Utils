using System;

namespace Utils.Events
{
    /// <summary>
    /// A class allowing to use a specific type to be used as an event arg
    /// </summary>
    /// <typeparam name="T">The type to be used as an argument</typeparam>
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// Gets or Sets the object that will act as the event parameter
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Initialises a new instance of the class <see cref="EventArgs{T}"/>
        /// </summary>
        /// <param name="value">Initial value of the <see cref="Value"/> property</param>
        public EventArgs(T value) : base()
        {
            this.Value = value;
        }

        /// <summary>
        /// Initialises a new instance of the class <see cref="EventArgs{T}"/>
        /// </summary>
        public EventArgs() : base()
        {}

    }
}
