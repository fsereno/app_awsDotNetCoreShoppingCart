using System.Collections.Generic;
using Models;

namespace Utils
{
    public class BasketUtil : IBasketUtil
    {
        /// <inheritdoc/>
        public bool TryRange(int index, IList<Item> collection, out int position)
        {
            var isInRange = false;
            position = -1;
            if (index > 0 && collection?.Count > 0) {
                position = index - 1;
                isInRange = position < collection?.Count;
            }
            return isInRange;
        }

        /// <inheritdoc/>
        public List<Item> GetItems(List<Item> requestItems, List<Item> localItems)
        {
            var items = requestItems.Count > 0 ? requestItems : localItems;
            return items;
        }
    }
}