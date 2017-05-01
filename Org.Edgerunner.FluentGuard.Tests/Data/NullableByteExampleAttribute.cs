#region Apache License 2.0
// <copyright file="NullableByteExampleAttribute.cs" company="Edgerunner.org">
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

using System.Linq.Expressions;
using System;

namespace Org.Edgerunner.FluentGuard.Tests.Data
{
   /// <summary>
   /// Class that supplies nullable byte testing example data.
   /// </summary>
   public class NullableByteExampleAttribute : NullableExampleAttribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="T:Xbehave.NullableExampleAttribute"/> class.
      /// </summary>
      /// <param name="data">The nullable data values to pass to the scenario.</param>
      /// <seealso cref="T:Xunit.Sdk.DataAttribute"/>
      /// <seealso cref="T:Xunit.InlineDataAttribute"/>
      /// <seealso cref="T:Xunit.MemberDataAttribute"/>
      public NullableByteExampleAttribute(params object[] data)
         : base(data)
      {
         
      }

      protected override object[] ConvertData(object[] datum)
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
               else if (type == typeof(int))
                  data[i] = Expression.Constant(Convert.ToByte(item), typeof(byte)).Value;
               else
                  data[i] = Expression.Constant(item, type).Value;
            }
         }
         return data;
      }
   }
}