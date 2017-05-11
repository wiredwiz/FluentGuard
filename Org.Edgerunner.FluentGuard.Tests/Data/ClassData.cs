#region Apache License 2.0
// <copyright company="Edgerunner.org" file="ClassData.cs">
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

namespace Org.Edgerunner.FluentGuard.Tests.Data
{
   /// <summary>
   /// Class that generates test Person data.
   /// </summary>
   public class ClassData
   {
      /// <summary>
      /// Returns a data set of <see cref="Person"/> values.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Person"/> unit test data.</returns>
      public static IEnumerable<object[]> Persons()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", new Person("Larry", 20) },
                      new object[] { "foo2", new Person("Daryl", 28) },
                      new object[] { "foo3", new Person("Daryl", 29) }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Person"/> and <see cref="Officer"/> values.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Person"/> unit test data.</returns>
      public static IEnumerable<object[]> OfficersAndPeople()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", new Person("Larry", 20) },
                      new object[] { "foo2", new Person("Daryl", 28) },
                      new object[] { "foo3", new Officer("Steve", 29, "Seargent") }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      /// Returns a data set of <see cref="Person"/> values.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}"/> instance containing <see cref="Officer"/> unit test data.</returns>
      public static IEnumerable<object[]> Officers()
      {
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable HeapView.BoxingAllocation
         return new[]
                   {
                      new object[] { "foo1", new Officer("Larry", 20, "Private") },
                      new object[] { "foo2", new Officer("Daryl", 35, "Major") },
                      new object[] { "foo3", new Officer("Daryl", 45, "General") }
                   };
         // ReSharper restore HeapView.BoxingAllocation
         // ReSharper restore ExceptionNotDocumentedOptional
      }
   }
}