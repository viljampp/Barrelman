using System;
using System.Collections.Generic;
using System.IO;
using Barrelman.Domain;

namespace Barrelman.Infra {
    public static class IO
    {
        //TODO Teha: veakontrollid!!
        public static IEnumerable<Barrel> ReadFile(string fileName) {
            var barrels = new List<Barrel>();

            var lines = File.ReadAllLines($"{Environment.CurrentDirectory}/{fileName}");

            foreach (var line in lines) {
                var splittedLine = line.Split(' ');

                stringToInt(splittedLine[0], out var id);
                stringToInt(splittedLine[1], out var diameter);
                stringToInt(splittedLine[2], out var height);

                var barrel = new Barrel(id, diameter, height);
                barrels.Add(barrel);
            }

            return barrels;
        }

        public static void WriteFile(string fileName, IEnumerable<IEnumerable<IBarrel>> collection) {
            var path = $"{Environment.CurrentDirectory}/{fileName}";

            if (File.Exists(path)) File.Delete(path);
            using var file = File.AppendText(path);

            foreach (var list in collection) {
                foreach (var item in list) {
                    file.Write($"{item.Id} ");
                }
                file.WriteLine();
            }
            file.Close();
        }

        public static void PrintToTheConsole(IEnumerable<IEnumerable<IBarrel>> collection) {
            foreach (var list in collection) {
                foreach (var item in list) {
                    Console.Write($"{item.Id} ");
                }
                Console.WriteLine();
            }
        }
        private static void stringToInt(string value, out int x) => int.TryParse(value, out x);
    }
}
