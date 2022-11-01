﻿using System.Text.Json;

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
        public static async Task Main()
        {
            List<WeatherForecast> weatherForecast = new List<WeatherForecast>() {new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            }, new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-02"),
                TemperatureCelsius = 12,
                Summary = "Medium"
            }, new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-03"),
                TemperatureCelsius = -2,
                Summary = "Cold"
            } };

            string fileName = "WeatherForecast.json";
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, weatherForecast);
            await createStream.DisposeAsync();

            Console.WriteLine(File.ReadAllText(fileName));

            Console.WriteLine("---------DESERIALISERA LISTA---------");

            using FileStream openStream = File.OpenRead(fileName);
            List<WeatherForecast>? getWeatherForecast =
                await JsonSerializer.DeserializeAsync<List<WeatherForecast>>(openStream);

            getWeatherForecast.ForEach(forecast => Console.WriteLine($"Date: {forecast.Date}, {forecast.Summary}, {forecast.TemperatureCelsius}"));
        }
    }
}
// output:
//{"Date":"2019-08-01T00:00:00-07:00","TemperatureCelsius":25,"Summary":"Hot"}