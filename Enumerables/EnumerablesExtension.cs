using System.Collections.Generic;
using System.Linq;

namespace Utils.Enumerables
{
    /// <summary>
    /// CLass holding extension methods targeted at <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerablesExtension
    {
        /// <summary>
        /// Extension Method allowing to check if an element is part of a collection
        /// </summary>
        /// <typeparam name="T">The type of the element to check the presence of</typeparam>
        /// <param name="source">The element to check the presence in the collection</param>
        /// <param name="arguments">The collection to check the presence of the item in</param>
        /// <returns><code>true</code> if the element is poresent in the collection</returns>
        public static bool In<T>(this T source, IEnumerable<T> arguments)
        {
            return arguments.Any(a => a.Equals(source));
        }

        /// <summary>
        /// Extension Method allowing to check if an element is part of a collection
        /// </summary>
        /// <typeparam name="T">The type of the element to check the presence of</typeparam>
        /// <param name="source">The element to check the presence in the collection</param>
        /// <param name="arguments">The elements to check against</param>
        /// <returns><code>true</code> if the element is poresent in the collection</returns>
        public static bool In<T>(this T source, params T[] arguments)
        {
            return source.In((IEnumerable<T>)arguments);
        }
    }
}