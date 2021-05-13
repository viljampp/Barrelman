using System.Collections.Generic;
using Barrelman.Domain;

namespace Barrelman.Infra {
    public static class InitializeBarrels {
        public static List<Barrel> FakeBarrels => new List<Barrel> {
            new Barrel(1, 31, 15),
            new Barrel(2, 29, 4),
            new Barrel(3, 22, 11),
            //new Barrel(4, 30, 14),
            //new Barrel(5, 40, 40),
            //new Barrel(6, 50, 50),
            //new Barrel(7, 100, 100),
            //new Barrel(8, 49, 52),
            //new Barrel(9, 28, 2),
            //new Barrel(10, 28, 3),
        };
    }
}
