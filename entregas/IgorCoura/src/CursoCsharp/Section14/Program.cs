using System.Globalization;
using System.Reflection;

Console.WriteLine("Init");

var defaultDirectory = Environment.CurrentDirectory + @"\files";
var fileSourcePath = defaultDirectory + @"\origin.csv";
var fileDestinationDirectory = defaultDirectory + @"\out";
var fileDestinationPath = fileDestinationDirectory + @"\summary.csv";

if(Directory.Exists(fileDestinationDirectory) is false)
{
    Directory.CreateDirectory(fileDestinationDirectory);
}

try
{
    using (StreamWriter streamWriter = File.CreateText(fileDestinationPath))
    {
        using (StreamReader streamReader = File.OpenText(fileSourcePath))
        {
            while (streamReader.EndOfStream is false)
            {
                string line = streamReader.ReadLine()!;
                string[] listLine = line.Split(',');
                var nameItem = listLine[0];
                decimal totalValueItem = decimal.Parse(listLine[1]) * decimal.Parse(listLine[2]);        
                streamWriter.WriteLine($"{nameItem},{totalValueItem}");
            }
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("Fished");
