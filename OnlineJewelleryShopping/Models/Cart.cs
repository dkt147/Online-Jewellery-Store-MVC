﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJewelleryShopping.Models
{
    public class Cart
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int price { get; set; }

        public int qty { get; set; }

        public int bill { get; set; }
    }
}