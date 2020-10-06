using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PatternsAndPractices.Singleton
{
    public sealed class LazySingleton
    {
        public static readonly Lazy<LazySingleton> _lazy = new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton Instance
        {
            get { return _lazy.Value; }
        }
    }
}
