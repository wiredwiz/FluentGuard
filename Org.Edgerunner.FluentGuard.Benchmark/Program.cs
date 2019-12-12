#region Apache License 2.0

// <copyright company="Edgerunner.org" file="Program.cs">
// Copyright (c)  2017
// </copyright>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Org.Edgerunner.FluentGuard.Benchmark
{
   /// <summary>
   /// Program class used to run benchmark.
   /// </summary>
   internal class Program
   {
      private static void Main(string[] args)
      {
         var foo = new Dictionary<string, int> { { "test", 1 } };
         var watch = new Stopwatch();
         double totalRun = 0;
         int numberOfRuns = 1000000;

         // warm up
         watch.Start();
         var validator = Validate.That(nameof(foo.Keys.Count), foo.Keys.Count);
         validator.IsGreaterThan(0).And.IsLessThan(10).OtherwiseThrowException();
         watch.Stop();
         var firstRun = watch.Elapsed.TotalMilliseconds * 1000000.0;

         // benchmark
         for (int i = 0; i < numberOfRuns; i++)
         {
            watch.Start();
            validator = Validate.That("foo.Keys.Count", foo.Keys.Count);
            validator.IsGreaterThan(0).And.IsLessThan(10).OtherwiseThrowException();
            watch.Stop();
            totalRun = watch.Elapsed.TotalMilliseconds * 1000000.0;
         }
         
         Console.WriteLine($"Guard statement: Validate.That(nameof(foo.Keys.Count), foo.Keys.Count).IsGreaterThan(0).And.IsLessThan(10).OtherwiseThrowException();");
         Console.WriteLine($"Value: {foo.Keys.Count}");
         Console.WriteLine($"Cold execution time: {firstRun} nanoseconds");
         Console.WriteLine($"Average warm execution time over {numberOfRuns} runs: {totalRun / numberOfRuns} nanoseconds");
         Console.WriteLine("Press any key to exit benchmark");
         Console.ReadKey();
      }
   }
}
