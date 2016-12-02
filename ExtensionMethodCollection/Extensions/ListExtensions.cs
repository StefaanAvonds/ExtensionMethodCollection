using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExtensionMethodCollection.Extensions
{
    /// <summary>
    /// Extension-methods for the List-object.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Returns an ObservableCollection of T with the result of the List.
        /// </summary>
        /// <typeparam name="T">The type of elements for the List.</typeparam>
        /// <param name="list">The List itself.</param>
        /// <returns>An ObservableCollection with all the items that are available in the List.</returns>
        public static ObservableCollection<T> ConvertToObservableCollection<T>(this List<T> list)
            where T : class
        {
            var collection = new ObservableCollection<T>();

            if (list == null || !list.Any()) return collection;

            foreach (var item in list) collection.Add(item);

            return collection;
        }

        /// <summary>
        /// Does the action for each item in the list.
        /// This can be useful if you only need to perform 1 single action per item.
        /// If multiple actions (read multiple lines of code) are needed, the conventional foreach is more readable.
        /// </summary>
        /// <typeparam name="T">The type of elements for the List.</typeparam>
        /// <param name="list">The list that contains the elements.</param>
        /// <param name="action">An action to be executed for each item.</param>
        public static void ForEach<T>(this List<T> list, Action<T> action)
        {
            if (list == null) return;

            foreach (var item in list)
            {
                action(item);
            }
        }

        /// <summary>
        /// Checks if the List contains any element.
        /// </summary>
        /// <typeparam name="T">The type of elements for the List.</typeparam>
        /// <param name="list">The list that contains the elements.</param>
        /// <returns>TRUE = the list contains no elements | FALSE = the list contains at least 1 item</returns>
        public static bool IsEmpty<T>(this List<T> list)
        {
            if (list == null) return true;

            if (!list.Any()) return true; // If the list doesn't have any element, it is empty

            // If it does contain an element (any element), the list isn't empty
            return false;
        }
    }
}
