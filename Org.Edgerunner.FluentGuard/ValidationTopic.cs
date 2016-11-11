#region Apache License 2.0

// <copyright file="ValidationTopic.cs" company="Edgerunner.org">
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

using Org.Edgerunner.FluentGuard.Validation;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   ///    Class representing a validation topic.
   /// </summary>
   /// <typeparam name="T">The type of data to validate</typeparam>
   public class ValidationTopic<T>
   {
      /// <summary>
      ///    Gets or sets the name.
      /// </summary>
      /// <value>The topic name.</value>
      public string Name { get; set; }

      /// <summary>
      ///    Gets or sets the value.
      /// </summary>
      /// <value>The topic value.</value>
      public T Value { get; set; }

      /// <summary>
      /// Constructs a new validator to use.
      /// </summary>
      /// <typeparam name="TV">The type of the validator to construct.</typeparam>
      /// <returns>A new <see cref="Validator{T}"/> instance.</returns>
      public TV Using<TV>() where TV : Validator<T>, new()
      {
         return new TV { ParameterName = Name, ParameterValue = Value };
      }

      /// <summary>
      /// Constructs a new generic validator to use.
      /// </summary>
      /// <returns>A new <see cref="Validator{T}" /> instance.</returns>
      public Validator<T> UsingDefaultValidator()
      {
         return new Validator<T>(Name, Value);
      }
   }
}