using System.Collections.Generic;
using Models;

namespace Utils
{
    public interface IBasketUtil
    {
        /// <summary>
        /// Tests if the passed in non-zero index is in range of the collection and if so returns a zero based index position
        /// </summary>
        /// <param name="index">A non-zero based index to test with</param>
        /// <param name="collection">The collection to test against</param>
        /// <param name="position">The out parameter converting the passed zero based index converted</param>
        /// <returns>Returns boolean, if is successful of not</returns>
        bool TryRange(int index, IList<Item> collection, out int position);

        /// <summary>
        /// Decides whether to use the passed in collection or the locally defined collection
        /// </summary>
        /// <param name="requestItems">Request List of Items</param>
        /// <param name="localItems">Local List of Items</param>
        /// <returns>Returns List of Items, requestItems takes priority if they exist</returns>
        List<Item> GetItems(List<Item> requestItems, List<Item> localItems);
    }
}
