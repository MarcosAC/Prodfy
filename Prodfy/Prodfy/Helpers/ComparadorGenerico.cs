using System;
using System.Collections.Generic;

namespace Prodfy.Helpers
{
    public class ComparadorGenerico<T> : IEqualityComparer<T>
    {
        public Func<T, T, bool> MetodoEquals { get; }
        public Func<T, int> MetodoGetHashCode { get; }

        public ComparadorGenerico()
        {
        }

        public ComparadorGenerico(Func<T, T, bool> metodoEquals, Func<T, int> metodoGetHashCode)
        {
            MetodoEquals = metodoEquals;
            MetodoGetHashCode = metodoGetHashCode;
        }       

        public static ComparadorGenerico<T> Criar(Func<T, T, bool> metodoEquals, Func<T, int> metodoGetHashCode)
            => new ComparadorGenerico<T>(metodoEquals, metodoGetHashCode);

        public bool Equals(T x, T y) => MetodoEquals(x, y);

        public int GetHashCode(T obj) => MetodoGetHashCode(obj);
    }
}
