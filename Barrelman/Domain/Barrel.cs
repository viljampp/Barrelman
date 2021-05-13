namespace Barrelman.Domain
{
    public sealed class Barrel : ComparableBarrel<Barrel>, IBarrel {
        public Barrel() { }
        public Barrel(int id, int diameter, int height) : base(id, diameter, height) {
            Id = id;
            Diameter = diameter;
            Height = height;
        }

        public int Id { get; set; }
        public int Diameter { get; set; }
        public int Height { get; set; }
    }
}
