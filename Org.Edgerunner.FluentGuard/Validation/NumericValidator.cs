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
using System.Diagnostics.CodeAnalysis;
using NDepend.Attributes;
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.NDepend.Attributes;

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   ///    Class NumericValidator.
   /// </summary>
   /// <typeparam name="T">A numeric type.</typeparam>
   /// <seealso cref="ValidatorBase{T}" />
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if DEBUG
   [FullCovered]
#endif
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
      /// <returns>A new <see cref="ValidatorLinkage{NumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentException">Must be negative.</exception>
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
      /// <returns>A new <see cref="ValidatorLinkage{NumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentException">Must not be negative.</exception>
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
#if DEBUG
      [IgnoreBoxing]
#endif
      protected virtual bool PerformIsNegativeOperation(T currentValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         // ReSharper disable once PossibleNullReferenceException
         return original.CompareTo(default(T)) < 0;
      }
   }
}