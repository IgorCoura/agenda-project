using System.Globalization;
using System.Reflection;
using Section14;

Console.WriteLine("Init");

var defaultDirectory = Environment.CurrentDirectory + @"\files";
var fileSourcePath = defaultDirectory + @"\origin.csv";
var fileDestinationDirectory = defaultDirectory + @"\out";
var fileDestinationPath = fileDestinationDirectory + @"\summary.csv";

Directory.CreateDirectory(fileDestinationDirectory);

try
{
    var products = ProductCsvFile.getProducts(fileSourcePath);
    products.ToCsvWithOnlyNameAndTotalValue(fileDestinationPath);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("Fished");
