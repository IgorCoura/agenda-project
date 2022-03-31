using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Section14
{
    public static class ProductCsvFile
    {
        public static List<Product> getProducts(string originPath)
        {
            using StreamReader streamReader = File.OpenText(originPath);

            List<Product> products = new List<Product>();

            while (streamReader.EndOfStream is false)
            {
                string line = streamReader.ReadLine()!;
                string[] arrayLine = line.Split(',');
                var name = arrayLine[0];
                decimal price = decimal.TryParse(arrayLine[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal result) ? result : 0;
                int quantity = int.TryParse(arrayLine[2], out int value) ? value : 0;
                var product = new Product(name, price, quantity);
                products.Add(product);
            }

            return products;
        }

        public static void ToCsvWithOnlyNameAndTotalValue(this List<Product> products, string destinePath)
        {
            using StreamWriter streamWriter = File.CreateText(destinePath);

            foreach(Product product in products)
                streamWriter.WriteLine(product.ToStringWithOnlyNameAndTotalValue());
            
        }
    }
}
