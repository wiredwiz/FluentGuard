#region Apache License 2.0
// <copyright file="NullableExampleAttribute.cs" company="Edgerunner.org">
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
using System.Linq.Expressions;
using System.Reflection;
using Xunit.Sdk;

namespace Org.Edgerunner.FluentGuard.Tests.Data
{
   /// <summary>
   /// Class that supplies nullable testing example data.
   /// </summary>
   /// <seealso cref="Xunit.Sdk.DataAttribute" />
   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
   public class NullableExampleAttribute : DataAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="NullableExampleAttribute" /> class.
      /// </summary>
      /// <param name="data">The nullable data values to pass to the scenario.</param>
      /// <seealso cref="T:Xunit.Sdk.DataAttribute" />
      /// <seealso cref="T:Xunit.InlineDataAttribute" />
      /// <seealso cref="T:Xunit.MemberDataAttribute" />
      public NullableExampleAttribute(params object[] data)
      {
         data = ConvertData(data);
         _Data = data;
      }

      /// <summary>
      /// The unit test example data
      /// </summary>
      private readonly object[] _Data;

      /// <summary>
      /// Returns the data to be used to test the theory.
      /// </summary>
      /// <param name="testMethod">The method that is being tested</param>
      /// <returns>One or more sets of theory data. Each invocation of the test method
      /// is represented by a single object array.</returns>
      public override IEnumerable<object[]> GetData(MethodInfo testMethod)
      {         
         // This is called by the WPA81 version as it does not have access to attribute ctor params
         return new[] { _Data };
      }

      /// <summary>
      /// Converts the unit test data into the appropriate nullable type data when needed.
      /// </summary>
      /// <param name="datum">The datum.</param>
      /// <returns>An object array of unit test data.</returns>
      protected virtual object[] ConvertData(object[] datum)
      {
         var data = new object[datum.Length];
         for (int i = 0; i < data.Length; i++)
         {
            var item = datum[i];
            if (item == null)
               data[i] = null;
            else
            {
               var type = item.GetType();
               if (!type.IsValueType)
                  data[i] = item;
               else
                  data[i] = Expression.Constant(item, type).Value;
            }
         }
         return data;
      }
   }
}