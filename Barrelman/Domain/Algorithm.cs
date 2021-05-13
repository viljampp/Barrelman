using System;
using System.Collections.Generic;
using System.Linq;

namespace Barrelman.Domain {
    public class Algorithm<T> where T : IBarrel, new() {
        private T[] barrels;
        private static IEnumerable<T> inputBarrels = new List<T>();

        protected internal Algorithm(IEnumerable<T> x) => inputBarrels = x;

        public void Solve() {
            barrels = new T[inputBarrels.Count() * 2];

            for (var i = 0; i < inputBarrels.Count(); i++) {
                var barrel = inputBarrels.ElementAt(i);
                barrels[i * 2] = createInstance(barrel.Id, barrel.Height, barrel.Diameter);
                barrels[i * 2 + 1] = createInstance(barrel.Id, barrel.Diameter, barrel.Height);
            }

            removeDuplicates();
            Array.Sort(barrels);
        }

        //TODO Läbuks läks meetod.. -> refaktoorida!
        public IEnumerable<IEnumerable<IBarrel>> Result() {
            var lines = new List<IEnumerable<IBarrel>>();
            var line = new List<IBarrel>();

            for (var i = 0; i < barrels.Count(); i++) {
                var barrel = barrels.ElementAt(i);

                if (barrel.Id != barrels.Last().Id) {
                    var secondBarrel = barrels.ElementAt(i + 1);

                    if (isSmaller(barrel, secondBarrel)) {
                        line.Add(barrel);
                    }
                    else {

                        line.Add(barrel);
                        lines.Add(line);
                        line = new List<IBarrel>();
                    }
                }
                else {
                    line.Add(barrel);
                    lines.Add(line);
                }
            }

            return lines;
        }

        private static T createInstance(params object[] args) => (T)Activator.CreateInstance(typeof(T), args);

        private void removeDuplicates() {
            var groupedBarrels = barrels.GroupBy(x => x.Id).Select(x => x.First()).ToArray();
            barrels = groupedBarrels;
        }

        private bool isSmaller(T o1, T o2) =>
            o1.Height > o2.Height && o1.Diameter > o2.Diameter ||
            o1.Height > o2.Diameter && o1.Diameter > o2.Height;
    }
}
