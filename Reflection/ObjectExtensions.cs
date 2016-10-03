using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Utils.Reflection
{
    /// <summary>
    /// Class containing extension methods targeting objects
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Method allowing to obtain informations about an object's property
        /// </summary>
        /// <remarks>
        /// Created by : Cameron MacFarland @ http://stackoverflow.com/a/672212/2245256
        /// </remarks>
        /// <typeparam name="TSource">The object type holding the property</typeparam>
        /// <typeparam name="TProperty">The targeted property type</typeparam>
        /// <param name="source">THe source object</param>
        /// <param name="propertyLambda">An expression describing how to get to the property from the source object</param>
        /// <returns>A <see cref="PropertyInfo"/> describing the property</returns>
        public static PropertyInfo GetPropertyInfo<TSource, TProperty>(
            this TSource source,
            Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);

            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda));

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda));

            if (type != propInfo.ReflectedType &&
                !type.IsAssignableFrom(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda,
                    type));

            return propInfo;
        }
    }
}