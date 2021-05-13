using System;

namespace Barrelman.Common {
    public abstract class CommonComparable<T> : IComparable<T> where T : ICommon {
        protected T obj;
        protected CommonComparable() { }
        public virtual int CompareTo(T other) => obj.Id;
    }
}
