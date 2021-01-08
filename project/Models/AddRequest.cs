using System.Collections.Generic;

namespace FabioSereno.App_awsDotNetCoreShoppingCart.Models
{
    public class AddRequest
    {
        public Item Item { get; set; }
        public List<Item> Items { get; set; }
    }
}