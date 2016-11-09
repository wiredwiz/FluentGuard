#region Apache License 2.0

// <copyright file="ContainerData.cs" company="Edgerunner.org">
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
using Org.Edgerunner.FluentGuard.Tests.Models;

namespace Org.Edgerunner.FluentGuard.Tests.Data
{
   /// <summary>
   ///    Class that yields up <see cref="Container" /> unit test data.
   /// </summary>
   public class ContainerData
   {
      /// <summary>
      ///    An instance of the <see cref="Random" /> class.
      /// </summary>
      private static readonly Random _Random = new Random();

      #region Static

      /// <summary>
      ///    Returns a data set of <see cref="Container" /> values where the first is equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}" /> instance containing <see cref="Container" /> unit test data.</returns>
      public static IEnumerable<object[]> IsEqualTo()
      {
         return new[]
                   {
                      new object[] { "foo", new Container { Weight = 10 }, new Container { Weight = 10 } },
                      new object[]
                         {
                            "foo",
                            new Container { Weight = 6.7, Depth = 2.4, Height = 5.251, Width = 6 },
                            new Container { Weight = 6.7, Depth = 2.4, Height = 5.251, Width = 6 }
                         }
                   };
      }

      /// <summary>
      ///    Returns a data set of <see cref="Container" /> values where the first is greater than the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}" /> instance containing <see cref="Container" /> unit test data.</returns>
      public static IEnumerable<object[]> IsGreaterThan()
      {
         return new[]
                   {
                      new object[] { "foo", new Container { Weight = 5.1 }, new Container { Weight = 5 } },
                      new object[] { "foo", new Container { Weight = 1 }, new Container { Weight = 0 } },
                      new object[] { "foo", new Container { Weight = 8 }, new Container { Weight = 4.2 } }
                   };
      }

      /// <summary>
      ///    Returns a data set of <see cref="Container" /> values where the first is greater than or equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}" /> instance containing <see cref="Container" /> unit test data.</returns>
      public static IEnumerable<object[]> IsGreaterThanOrEqualTo()
      {
         return new[]
                   {
                      new object[] { "foo", new Container { Weight = 5.1 }, new Container { Weight = 5 } },
                      new object[] { "foo", new Container { Weight = 1 }, new Container { Weight = 0 } },
                      new object[] { "foo", new Container { Weight = 8 }, new Container { Weight = 4.2 } },
                      new object[] { "foo", new Container { Weight = 10 }, new Container { Weight = 10 } }
                   };
      }

      /// <summary>
      ///    Returns a data set of <see cref="Container" /> values where the first is less than the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}" /> instance containing <see cref="Container" /> unit test data.</returns>
      public static IEnumerable<object[]> IsLessThan()
      {
         return new[]
                   {
                      new object[] { "foo", new Container { Weight = 5.0 }, new Container { Weight = 5.01 } },
                      new object[] { "foo", new Container { Weight = 0 }, new Container { Weight = 1 } },
                      new object[] { "foo", new Container { Weight = 5.0 }, new Container { Weight = 8 } }
                   };
      }

      /// <summary>
      ///    Returns a data set of <see cref="Container" /> values where the first is less than or equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}" /> instance containing <see cref="Container" /> unit test data.</returns>
      public static IEnumerable<object[]> IsLessThanOrEqualTo()
      {
         return new[]
                   {
                      new object[] { "foo", new Container { Weight = 5.0 }, new Container { Weight = 5.01 } },
                      new object[] { "foo", new Container { Weight = 0 }, new Container { Weight = 1 } },
                      new object[] { "foo", new Container { Weight = 5.0 }, new Container { Weight = 8 } },
                      new object[] { "foo", new Container { Weight = 5.0 }, new Container { Weight = 5 } }
                   };
      }

      /// <summary>
      ///    Returns a data set of <see cref="Container" /> values where the first is not equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}" /> instance containing <see cref="Container" /> unit test data.</returns>
      public static IEnumerable<object[]> IsNotEqualTo()
      {
         return new[]
                   {
                      new object[] { "foo", new Container { Weight = 10 }, new Container { Weight = 10.0001 } },
                      new object[]
                         {
                            "foo",
                            new Container { Weight = 6.7, Depth = 2.4, Height = 5.251, Width = 6.02 },
                            new Container { Weight = 6.7, Depth = 2.4, Height = 5.251, Width = 6 }
                         }
                   };
      }

      /// <summary>
      ///    Returns a data set of <see cref="Container" /> values where the first is not equal to the second.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}" /> instance containing <see cref="Container" /> unit test data.</returns>
      public static IEnumerable<object[]> IsNull()
      {
         return new[] { new object[] { "foo", null } };
      }

      /// <summary>
      ///    Returns a data set of <see cref="Container" /> values where they are all random.
      /// </summary>
      /// <returns>A new <see cref="IEnumerable{T}" /> instance containing <see cref="Container" /> unit test data.</returns>
      public static IEnumerable<object[]> RandomContainerValues()
      {
         return new[]
                   {
                      new object[]
                         {
                            "foo",
                            new Container { Weight = GetValue(), Depth = GetValue(), Height = GetValue(), Width = GetValue() }
                         },
                      new object[]
                         {
                            "foo",
                            new Container { Weight = GetValue(), Depth = GetValue(), Height = GetValue(), Width = GetValue() }
                         },
                      new object[]
                         {
                            "foo",
                            new Container { Weight = GetValue(), Depth = GetValue(), Height = GetValue(), Width = GetValue() }
                         }
                   };
      }

      /// <summary>
      ///    Gets a new random <see cref="double" /> value between 0 and the maximum double size.
      /// </summary>
      /// <returns>A new <see cref="double" />.</returns>
      private static double GetValue()
      {
         return _Random.NextDouble() * double.MaxValue;
      }

      #endregion
   }
}