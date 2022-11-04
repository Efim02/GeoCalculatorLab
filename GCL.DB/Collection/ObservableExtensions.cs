namespace GCL.DB.Collection
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class ObservableExtensions
    {
        /// <summary>
        /// Добавить в список элементы.
        /// </summary>
        /// <typeparam name="T"> Тип элемента. </typeparam>
        /// <param name="collection"> Список. </param>
        /// <param name="enumerable"> Элементы. </param>
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> enumerable)
        {
            foreach (var element in enumerable)
            {
                collection.Add(element);
            }
        }
    }
}