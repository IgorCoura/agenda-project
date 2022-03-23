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
                string[] listLine = line.Split(',');
                var product = new Product(listLine[0], listLine[1], listLine[2]);
                products.Add(product);
            }

            return products;
        }

        public static void ToCsvWithOnlyNameAndTotalValue(this List<Product> products, string destinePath)
        {
            using StreamWriter streamWriter = File.CreateText(destinePath);

            foreach(Product product in products)
            {
                streamWriter.WriteLine(product.ToStringWithOnlyNameAndTotalValue());
            }
        }
    }
}
