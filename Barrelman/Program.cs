using Barrelman.Domain;
using Barrelman.Infra;

namespace Barrelman {
    class Program {
        static void Main(string[] args) {
            //var x = InitializeBarrels.FakeBarrels;
            var x = IO.ReadFile("Barrels.txt");

            var box = new Algorithm<Barrel>(x);
            box.Solve();
            var result = box.Result();

            IO.PrintToTheConsole(result);
            IO.WriteFile("result.txt", result);
        }
    }
}
