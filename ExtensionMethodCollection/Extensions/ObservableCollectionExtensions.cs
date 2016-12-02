using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExtensionMethodCollection.Extensions
{
    /// <summary>
    /// Extension-methods for the ObservableCollection-object.
    /// </summary>
    public static class ObservableCollectionExtensions
    {
        /// <summary>
        /// Returns a List of T with the result of the List.
        /// </summary>
        /// <typeparam name="T">The type of elements for the List.</typeparam>
        /// <param name="collection">The ObservableCollection itself.</param>
        /// <returns>A List with all the items that are available in the ObservableCollection.</returns>
        public static List<T> ConvertToList<T>(this ObservableCollection<T> collection)
        {
            var list = new List<T>();

            if (collection == null || !collection.Any()) return list;

            foreach (var item in collection) list.Add(item);

            return list;
        }

        /// <summary>
        /// Order the ObservableCollection.
        /// The normal OrderBy-method returns an IOrderedEnumerable.
        /// This method converts the IOrderedEnumerable back to an ObservableCollection.
        /// </summary>
        /// <typeparam name="T">The type of elements for the List.</typeparam>
        /// <param name="collection">The ObservableCollection itself.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <returns>The sorted ObservableCollection.</returns>
        public static ObservableCollection<T> OrderByAndConvert<T>(this ObservableCollection<T> collection, Func<T, string> keySelector)
        {
            var newCollection = collection.OrderBy(keySelector);
            return new ObservableCollection<T>(newCollection);
        }

        /// <summary>
        /// Order the ObservableCollection by descending.
        /// </summary>
        /// <typeparam name="T">The type of elements for the List.</typeparam>
        /// <param name="collection">The ObservableCollection itself.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <returns>The sorted ObservableCollection.</returns>
        public static ObservableCollection<T> OrderByDescendingAndConvert<T>(this ObservableCollection<T> collection, Func<T, string> keySelector)
        {
            var newCollection = collection.OrderByDescending(keySelector);
            return new ObservableCollection<T>(newCollection);
        }
    }
}
