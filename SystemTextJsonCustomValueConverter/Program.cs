using System;
using System.IO;
using System.Text.Json;
using SystemTextJsonCustomValueConverter.Models;

namespace SystemTextJsonCustomValueConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample.json"));

            var person = JsonSerializer.Deserialize<PositionPlayer>(json);

            Console.WriteLine($"{person.Name} plays as {person.Position}");

            var json2 = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nested_sample.json"));

            var dexterityPlayer = JsonSerializer.Deserialize<DexterityPlayer>(json2);

            Console.WriteLine($"{dexterityPlayer.Name} bats {dexterityPlayer.BatSide}.");
        }
    }
}
