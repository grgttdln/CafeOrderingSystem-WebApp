using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace MP_CS107L.App.Sale
{
    public class Sale
    {
        public int MaxQuantity { get; set; }
        public int MinQuantity { get; set; }
        public float Price { get; set; }
        public string ProductItem { get; set; }
        public float TotalPrice { get; set; }
        public string ProductID { get; set; }

    }


    public class TotalSale
    {
        public float Price { get; set; }
    }
}