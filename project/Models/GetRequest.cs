﻿using System.Collections.Generic;

namespace FabioSereno.App_awsDotNetCoreShoppingCart.Models
{
    public class GetRequest
    {
        public GetRequest()
        {
            this.Index = 0;
        }
        public int Index { get; set; }
        public List<Item> Items { get; set; }
    }
}