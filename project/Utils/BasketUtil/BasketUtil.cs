using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using FabioSereno.App_awsDotNetCoreShoppingCart.Models;
using FabioSereno.App_awsDotNetCoreShoppingCart.Interfaces;

namespace FabioSereno.App_awsDotNetCoreShoppingCart.Utils
{
    public class BasketUtil : IBasketUtil
    {
        private readonly ILogger<BasketUtil> _logger;

        public BasketUtil(ILogger<BasketUtil> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public bool TryRange(int index, IList<Item> collection, out int position)
        {

            _logger.LogInformation("Started checking index is in range");

            var isInRange = false;
            position = -1;
            if (index > 0 && collection?.Count > 0) {
                position = index - 1;
                isInRange = position < collection?.Count;
            }

            _logger.LogInformation("Finished checking index is in range");

            return isInRange;
        }

        /// <inheritdoc/>
        public List<Item> GetItems(List<Item> requestItems, List<Item> localItems)
        {
            _logger.LogInformation("Started getting itmes");

            var items = requestItems.Count > 0 ? requestItems : localItems;

            _logger.LogInformation("Finished getting itmes");

            return items;
        }
    }
}