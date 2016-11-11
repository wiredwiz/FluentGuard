using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.Edgerunner.FluentGuard.Validation;

namespace Org.Edgerunner.FluentGuard.Benchmark
{
   class Program
   {
      static void Main(string[] args)
      {
         var foo = new Dictionary<string, int> { { "test", 1} };
         var validator = Validate.That(() => foo.Keys.Count);
         Console.WriteLine($"Name: {validator.ParameterName}");
         Console.WriteLine($"Value: {validator.ParameterValue}");
         Console.ReadKey();
      }
   }
}
