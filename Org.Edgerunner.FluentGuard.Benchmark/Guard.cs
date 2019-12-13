using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Edgerunner.FluentGuard.Benchmark
{
   public static class Guard
   {
      public static void isOfType<T>(string name, object instance)
      {
         if (instance.GetType() != typeof(T))
            throw new ArgumentException(string.Format("must be of type {0}", typeof(T)), name);
      }

      public static void IsNotNull(string name, object instance)
      {
         if (instance == null)
            throw new ArgumentNullException(name, string.Format("{0} must not be null", name));
      }

      public static void IsWithinExclusiveBound(string name, int value, int floor, int ceiling)
      {
         if (value <= floor || value >= ceiling)
            throw new ArgumentException(string.Format("{0} must be greater than {1} and less than {2}", name, floor, ceiling), name);
      }
   }
}
