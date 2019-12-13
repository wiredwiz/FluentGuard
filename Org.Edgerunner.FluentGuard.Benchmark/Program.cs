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
using System.Collections;
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
         double withinBoundsCheckFluent = 0;
         double withinBoundsCheckStatic = 0;
         double notNullCheckFluent = 0;
         double notNullCheckStatic = 0;

         // warm up
         watch.Start();
         var validator = Validate.That(nameof(foo.Keys.Count), foo.Keys.Count);
         validator.IsGreaterThan(0).And.IsLessThan(10).OtherwiseThrowException();
         watch.Stop();
         var firstRun = watch.Elapsed.TotalMilliseconds * 1000000.0;
         var validator2 = Validate.That(nameof(foo), foo);
         validator2.IsNotNull().OtherwiseThrowException();
         Guard.IsNotNull(nameof(foo), foo);
         Guard.IsWithinExclusiveBound(nameof(foo.Keys.Count), foo.Keys.Count, 0, 10);

         // not null benchmark                 
         for (int i = 0; i < 1000000; i++)
         {            
            watch.Restart();
            validator2 = Validate.That(nameof(foo), foo);
            validator2.IsNotNull().OtherwiseThrowException();            
            watch.Stop();
            notNullCheckFluent += watch.Elapsed.TotalMilliseconds;
         }                                    
         for (int i = 0; i < 1000000; i++)
         {
            watch.Restart();
            Guard.IsNotNull(nameof(foo), foo);
            watch.Stop();
            notNullCheckStatic += watch.Elapsed.TotalMilliseconds;
         }                  
         Console.WriteLine($"First benchmark guard check: Validation that a dictionary instance is not null.");
         Console.WriteLine($"Average execution time for guard using fluent: {notNullCheckFluent} nanoseconds");
         Console.WriteLine($"Average execution time for guard using static: {notNullCheckStatic} nanoseconds");
         Console.WriteLine();

         // compound bound check benchmark
         for (int i = 0; i < 1000000; i++)
         {
            watch.Restart();
            validator = Validate.That("foo.Keys.Count", foo.Keys.Count);
            validator.IsGreaterThan(0).And.IsLessThan(10).OtherwiseThrowException();
            watch.Stop();
            withinBoundsCheckFluent += watch.Elapsed.TotalMilliseconds;
         }
         for (int i = 0; i < 1000000; i++)
         {
            watch.Restart();
            Guard.IsWithinExclusiveBound(nameof(foo.Keys.Count), foo.Keys.Count, 0, 10);
            watch.Stop();
            withinBoundsCheckStatic += watch.Elapsed.TotalMilliseconds;
         }

         Console.WriteLine($"Second benchmark guard check: Validation that dictionary instance key count is greater than 0 and less than 10.");
         Console.WriteLine($"Key count: {foo.Keys.Count}");
         Console.WriteLine($"Cold fluent execution time: {firstRun} nanoseconds");
         Console.WriteLine($"Average fluent warm execution time: {withinBoundsCheckFluent} nanoseconds");
         Console.WriteLine($"Average static warm execution time: {withinBoundsCheckStatic} nanoseconds");
         Console.WriteLine("Press any key to exit benchmark");
         Console.ReadKey();
      }
   }
}
