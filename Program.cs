using System.Text.Json;

namespace SerializeToFile
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            Console.WriteLine("-------SERIALISATION----------");

            string fileName = "WeatherForecast.json";                       // Skapa JSON fil
            string jsonString = JsonSerializer.Serialize(weatherForecast); //Serialisering
            File.WriteAllText(fileName, jsonString);                        //Skriv till fil

            Console.WriteLine(File.ReadAllText(fileName));

            Console.WriteLine("-------DESERIALISATION----------");

            WeatherForecast? gettingWeatherForecast =
                JsonSerializer.Deserialize<WeatherForecast>(jsonString);

            Console.WriteLine($"Date: {gettingWeatherForecast?.Date}");
            Console.WriteLine($"TemperatureCelsius: {gettingWeatherForecast?.TemperatureCelsius}");
            Console.WriteLine($"Summary: {gettingWeatherForecast?.Summary}");
        }
    }
}
// output:
//{"Date":"2019-08-01T00:00:00-07:00","TemperatureCelsius":25,"Summary":"Hot"}