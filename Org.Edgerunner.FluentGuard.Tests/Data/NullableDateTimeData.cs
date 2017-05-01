#region Apache License 2.0
// <copyright file="NullableDateTimeData.cs" company="Edgerunner.org">
// Copyright 2016 Thaddeus Ryker
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

namespace Org.Edgerunner.FluentGuard.Tests.Data
{
   /// <summary>
   /// Class that yields up <see cref="Nullable"/> <see cref="DateTime"/> unit test data.
   /// </summary>
   public class NullableDateTimeData
   {
      /// <summary>
      /// An instance of the <see cref="Random"/> class.
      /// </summary>
      private static readonly Random _Random = new Random();

      /// <summary>
      /// Returns a data set of <see cref="DateTime"/> values where the first is less than the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="DateTime"/> unit test data.</returns>
      public static IEnumerable<object[]> IsLessThan()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", new DateTime(2016, 1, 1), new DateTime(2016, 1, 2) },
                      new object[] { "foo2", new DateTime(2016, 1, 1), new DateTime(2016, 2, 1) },
                      new object[] { "foo3", new DateTime(2016, 1, 1, 12, 0, 0), new DateTime(2016, 1, 1, 12, 0, 1) },
                      new object[] { "foo4", null, new DateTime(2016, 1, 1, 12, 0, 1) }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="DateTime"/> values where the first is less than or equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="DateTime"/> unit test data.</returns>
      public static IEnumerable<object[]> IsLessThanOrEqualTo()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", new DateTime(2016, 1, 1), new DateTime(2016, 1, 2) },
                      new object[] { "foo2", new DateTime(2016, 1, 1), new DateTime(2016, 2, 1) },
                      new object[] { "foo3", new DateTime(2016, 1, 1), new DateTime(2016, 1, 1) },
                      new object[] { "foo4", new DateTime(2016, 1, 1, 12, 0, 0), new DateTime(2016, 1, 1, 12, 0, 1) },
                      new object[] { "foo5", new DateTime(2016, 1, 1, 12, 0, 0), new DateTime(2016, 1, 1, 12, 0, 0) },
                      new object[] { "foo6", null, new DateTime(2016, 1, 1, 12, 0, 1) },
                      new object[] { "foo7", null, null }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="DateTime"/> values where the first is greater than the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="DateTime"/> unit test data.</returns>
      public static IEnumerable<object[]> IsGreaterThan()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", new DateTime(2016, 1, 2), new DateTime(2016, 1, 1) },
                      new object[] { "foo2", new DateTime(2016, 2, 1), new DateTime(2016, 1, 1) },
                      new object[] { "foo3", new DateTime(2016, 1, 1, 12, 0, 1), new DateTime(2016, 1, 1, 12, 0, 0) },
                      new object[] { "foo4", new DateTime(2016, 1, 1, 12, 0, 1), null }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="DateTime"/> values where the first is greater than or equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="DateTime"/> unit test data.</returns>
      public static IEnumerable<object[]> IsGreaterThanOrEqualTo()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", new DateTime(2016, 1, 2), new DateTime(2016, 1, 1) },
                      new object[] { "foo2", new DateTime(2016, 2, 1), new DateTime(2016, 1, 1) },
                      new object[] { "foo3", new DateTime(2016, 1, 1), new DateTime(2016, 1, 1) },
                      new object[] { "foo4", new DateTime(2016, 1, 1, 12, 0, 1), new DateTime(2016, 1, 1, 12, 0, 0) },
                      new object[] { "foo5", new DateTime(2016, 1, 1, 12, 0, 0), new DateTime(2016, 1, 1, 12, 0, 0) },
                      new object[] { "foo6", new DateTime(2016, 1, 1, 12, 0, 1), null },
                      new object[] { "foo7", null, null }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="DateTime"/> values where the first is equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="DateTime"/> unit test data.</returns>
      public static IEnumerable<object[]> IsEqualTo()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", new DateTime(2016, 1, 1), new DateTime(2016, 1, 1) },
                      new object[] { "foo2", new DateTime(2016, 1, 1, 12, 0, 0), new DateTime(2016, 1, 1, 12, 0, 0) },
                      new object[] { "foo3", null, null }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="DateTime"/> values where the first is not equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="DateTime"/> unit test data.</returns>
      public static IEnumerable<object[]> IsNotEqualTo()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", new DateTime(2016, 1, 1), new DateTime(2016, 1, 2) },
                      new object[] { "foo2", new DateTime(2016, 1, 1, 12, 0, 0), new DateTime(2016, 1, 1, 12, 0, 1) },
                      new object[] { "foo3", new DateTime(2016, 1, 1, 12, 0, 0), new DateTime(2016, 1, 1, 12, 1, 0) },
                      new object[] { "foo4", new DateTime(2016, 1, 1, 12, 0, 1), null },
                      new object[] { "foo5", null, new DateTime(2016, 1, 1, 12, 0, 1) }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }
      
      /// <summary>
      /// Returns a data set of <see cref="DateTime"/> values where they are all random.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="DateTime"/> unit test data.</returns>
      public static IEnumerable<object[]> RandomDateValues()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", GetRandomDate(new DateTime(1900, 1, 1), new DateTime(2020, 12, 31)) },
                      new object[] { "foo2", GetRandomDate(new DateTime(1900, 1, 1), new DateTime(2020, 12, 31)) },
                      new object[] { "foo3", GetRandomDate(new DateTime(1900, 1, 1), new DateTime(2020, 12, 31)) }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Gets a new random <see cref="DateTime"/>.
      /// </summary>
      /// <param name="from">The lower inclusive bound.</param>
      /// <param name="to">The upper exclusive bound.</param>
      /// <returns>A <see cref="DateTime"/>.</returns>
      private static DateTime GetRandomDate(DateTime from, DateTime to)
      {
         var range = to - from;
         var randTimeSpan = new TimeSpan((long)(_Random.NextDouble() * range.Ticks));
         return from + randTimeSpan;
      }
   }
}