using System.Collections.Generic;

namespace FabioSereno.App_awsDotNetCoreShoppingCart.Models
{
    public class UpdateRequest
    {
        public int Index { get; set; }
        public Item Item { get; set; }
        public List<Item> Items { get; set; }
    }
}