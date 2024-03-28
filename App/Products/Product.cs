using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_CS107L.App.Product
{
    // Product Structure
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public bool IsAvailable { get; set; }

    }


}