using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section14
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {   
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotalValue()
        {
            return Price * Quantity;
        }

        public string ToStringWithOnlyNameAndTotalValue()
        {
            return $"{Name},{GetTotalValue().ToString("0.00", CultureInfo.InvariantCulture)}";
        }
    }
}
