using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions.Collections
{
    public static class CollectionExtensions
    {
        private static Random _generator = null;

        /// <summary>
        /// Returns random element from collection. Creates new random number generator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"> </param>
        public static T RandomElement<T>(this ICollection<T> collection)
        {
            if (_generator == null)
                _generator = new Random();

            return RandomElement(collection, _generator);
        }

        /// <summary>
        /// Returns random element from collection with given random number generator.
        /// </summary>
        /// <param name="generator"> Random number generator.</param>
        public static T RandomElement<T>(this ICollection<T> collection, Random generator)
        {
            int index = generator.Next(0, collection.Count);
            return collection.ElementAt(index);
        }
    }
}
