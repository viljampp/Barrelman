using Barrelman.Common;

namespace Barrelman.Domain {
    public abstract class ComparableBarrel<T> : CommonComparable<T> where T : IBarrel, new() {
        protected ComparableBarrel() { }
        protected ComparableBarrel(int id, int diameter, int height) {
            obj = new T { Id = id, Diameter = diameter, Height = height };
        }

        public override int CompareTo(T o) => area(o) - thisArea;
        private int area(T o) => o.Diameter * o.Height;
        private int thisArea => obj.Diameter * obj.Height;
    }
}
