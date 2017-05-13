#region Apache License 2.0

// <copyright company="Edgerunner.org" file="NumericValidator.cs">
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
using Org.Edgerunner.FluentGuard.Attributes;
using Org.Edgerunner.FluentGuard.Properties;

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   ///    Class NumericValidator.
   /// </summary>
   /// <typeparam name="T">A numeric type.</typeparam>
   /// <seealso cref="Org.Edgerunner.FluentGuard.Validation.Validator{T}" />
   [FullCovered]
   public class NumericValidator<T> : UnsignedNumericValidator<T> where T : struct
   {
      #region Constructors And Finalizers

      /// <summary>
      /// Initializes a new instance of the <see cref="NumericValidator{T}"/> class. 
      /// </summary>
      /// <param name="parameterName">
      /// The name of the parameter being validated.
      /// </param>
      /// <param name="parameterValue">
      /// The value of the parameter being validated.
      /// </param>
      public NumericValidator(string parameterName, T parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      #endregion

      /// <summary>
      ///    Determines whether the parameter being validated is negative.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NumericValidator<T>> IsNegative()
      {
         if (ShouldReturnAfterEvaluation(PerformIsNegativeOperation(ParameterValue)))
            return new ValidatorLinkage<NumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustBeNegative);

         return new ValidatorLinkage<NumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not negative.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NumericValidator<T>> IsNotNegative()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsNegativeOperation(ParameterValue)))
            return new ValidatorLinkage<NumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustNotBeNegative);

         return new ValidatorLinkage<NumericValidator<T>>(this);
      }

      /// <summary>
      ///    Performs the IsNegative operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is negative, <c>false</c> otherwise.</returns>
      protected virtual bool PerformIsNegativeOperation(T currentValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         // ReSharper disable once PossibleNullReferenceException
         return original.CompareTo(default(T)) < 0;
      }
   }
}