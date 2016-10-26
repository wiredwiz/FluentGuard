#region Apache License 2.0

// <copyright file="Validator.cs" company="Edgerunner.org">
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
using System.Diagnostics.CodeAnalysis;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   ///    Class that validates data.
   /// </summary>
   /// <typeparam name="T">The type of data to validate.</typeparam>
   [SuppressMessage("ReSharper", "ExceptionNotThrown", Justification = "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
   public class Validator<T> where T : IEquatable<T>, IComparable<T>
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Validator{T}"/> class.
      /// </summary>
      /// <param name="parameterName">The name of the parameter being validated.</param>
      /// <param name="parameterValue">The value of the parameter being validated.</param>
      internal Validator(string parameterName, T parameterValue)
      {
         ParameterName = parameterName;
         ParameterValue = parameterValue;
         Mode = CombinationMode.Or;
         CurrentException = null;
      }

      public string ParameterName { get; set; }

      public T ParameterValue { get; set; }

      public CombinationMode Mode { get; set; }

      public Exception CurrentException { get; set; }

      /// <summary>
      /// Ors the current conditional check against a new one.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}"/> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      public Validator<T> Or()
      {
         Mode = CombinationMode.Or;
         return this;
      }

      /// <summary>
      /// Combines the current conditional check with a new one using 'And' logic.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}"/> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      public Validator<T> And()
      {
         Mode = CombinationMode.And;
         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}"/> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be <paramref name="value"/>.</exception>
      public Validator<T> IsLessThan(T value)
      {
         if (ParameterValue.CompareTo(value) > -1)
            return this;

         if (Mode == CombinationMode.Or)
         {
            if (CurrentException == null)
               CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format("Must greater than or equal to {0}", value));
         }
         else if (Mode == CombinationMode.And)
            if ()
               if (CurrentException == null || !Mode)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format("Must greater than or equal to {0}", value));
         return this;
      }

      /// <summary>
      /// Throws a new exception.
      /// </summary>
      public void ThrowException()
      {
         // ReSharper disable once ExceptionNotDocumented
         // ReSharper disable once ThrowingSystemException
         throw CurrentException;
      }
   }
}