using Barrelman.Common;

namespace Barrelman.Domain {
    public interface IBarrel : ICommon {
        int Diameter { get; set; }
        int Height { get; set; }
    }
}
