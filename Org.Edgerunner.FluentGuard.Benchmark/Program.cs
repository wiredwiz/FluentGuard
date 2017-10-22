using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Org.Edgerunner.FluentGuard.Benchmark
{
   internal class Program
   {
      private static void Main(string[] args)
      {
         var foo = new Dictionary<string, int> { { "test", 1} };
         var watch = new Stopwatch();
         // warm up
         var validator = Validate.That(nameof(foo.Keys.Count), foo.Keys.Count);
         validator.IsGreaterThan(0).And.IsLessThan(10).OtherwiseThrowException();
         // benchmark
         watch.Start();
         validator = Validate.That("foo.Keys.Count", foo.Keys.Count);
         validator.IsGreaterThan(0).And.IsLessThan(10).OtherwiseThrowException();
         watch.Stop();
         Console.WriteLine($"Name: {validator.ParameterName}");
         Console.WriteLine($"Value: {validator.ParameterValue}");
         Console.WriteLine($"Exectuion Time: {watch.Elapsed.TotalMilliseconds * 1000000.0} nanoseconds");
         Console.WriteLine("Press any key to exit benchmark");
         Console.ReadKey();
      }
   }
}
