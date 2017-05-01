#region Apache License 2.0
// <copyright company="Edgerunner.org" file="NullableByteData.cs">
// Copyright (c)  2017
// </copyright>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// UnsignedNumericValidator<T>
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
   /// Class that yields up <see cref="Nullable"/> <see cref="Nullable{Byte}"/> unit test data.
   /// </summary>
   public class NullableByteData
   {
      /// <summary>
      /// An instance of the <see cref="Random"/> class.
      /// </summary>
      private static readonly Random _Random = new Random();

      /// <summary>
      /// Returns a data set of <see cref="Nullable{Byte}"/> values where the first is less than the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Nullable{Byte}"/> unit test data.</returns>
      public static IEnumerable<object[]> IsLessThan()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", (byte?)2, (byte?)5 },
                      new object[] { "foo2", (byte?)2, (byte?)3 },
                      new object[] { "foo3", (byte?)0, (byte?)2 },
                      new object[] { "foo4", null, (byte?)0 }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Nullable{Byte}"/> values where the first is less than or equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Nullable{Byte}"/> unit test data.</returns>
      public static IEnumerable<object[]> IsLessThanOrEqualTo()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", (byte?)0, (byte?)1 },
                      new object[] { "foo2", (byte?)1, (byte?)255 },
                      new object[] { "foo3", (byte?)1, (byte?)1 },
                      new object[] { "foo4", (byte?)0, (byte?)0 },
                      new object[] { "foo5", null, (byte?)0 },
                      new object[] { "foo6", null, null }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Nullable{Byte}"/> values where the first is greater than the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Nullable{Byte}"/> unit test data.</returns>
      public static IEnumerable<object[]> IsGreaterThan()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", (byte?)1, (byte?)0 },
                      new object[] { "foo2", (byte?)0, null },
                      new object[] { "foo3", (byte?)255, (byte?)1 }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Nullable{Byte}"/> values where the first is greater than or equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Nullable{Byte}"/> unit test data.</returns>
      public static IEnumerable<object[]> IsGreaterThanOrEqualTo()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", (byte?)1, (byte?)0 },
                      new object[] { "foo2", (byte?)0, null },
                      new object[] { "foo3", (byte?)255, (byte?)1 },
                      new object[] { "foo3", (byte?)0, (byte?)0 },
                      new object[] { "foo7", null, null }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Nullable{Byte}"/> values where the first is equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Nullable{Byte}"/> unit test data.</returns>
      public static IEnumerable<object[]> IsEqualTo()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", (byte?)0, (byte?)0 },
                      new object[] { "foo2", (byte?)1, (byte?)1 },
                      new object[] { "foo3", null, null }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Nullable{Byte}"/> values where the first is not equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Nullable{Byte}"/> unit test data.</returns>
      public static IEnumerable<object[]> IsNotEqualTo()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", (byte?)1, (byte?)0 },
                      new object[] { "foo2", (byte?)1, (byte?)255 },
                      new object[] { "foo3", null, (byte?)0 }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Nullable{Byte}"/> values where each is positive.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Nullable{Byte}"/> unit test data.</returns>
      public static IEnumerable<object[]> IsPositive()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", (byte?)1 },
                      new object[] { "foo2", (byte?)255 }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Nullable{Byte}"/> values where each is not positive.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Nullable{Byte}"/> unit test data.</returns>
      public static IEnumerable<object[]> IsNotPositive()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", (byte?)0 },
                      new object[] { "foo2", null }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Nullable{Byte}"/> values where they are all random.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Nullable{Byte}"/> unit test data.</returns>
      public static IEnumerable<object[]> RandomByteValues()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", GetRandomByte(0, 255) },
                      new object[] { "foo2", GetRandomByte(0, 255) },
                      new object[] { "foo3", GetRandomByte(0, 255) }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Gets a new random <see cref="Nullable{Byte}"/>.
      /// </summary>
      /// <param name="from">The lower inclusive bound.</param>
      /// <param name="to">The upper exclusive bound.</param>
      /// <returns>A <see cref="Nullable{Byte}"/>.</returns>
      private static byte? GetRandomByte(byte from, byte to)
      {
         var range = to - from;
         var randDiff = Convert.ToByte(_Random.NextDouble() * range);
         return (byte)(from + randDiff);
      }
   }
}