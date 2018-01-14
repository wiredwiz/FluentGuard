#region Apache License 2.0

// <copyright file="NullableUnsignedNumericValidator.cs" company="Edgerunner.org">
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

using Org.Edgerunner.FluentGuard.Exceptions;
using Org.Edgerunner.FluentGuard.Properties;

#if NDEPEND
using NDepend.Attributes;
using Org.Edgerunner.NDepend.Attributes;
#endif

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   /// Class NullableNumericValidator.
   /// </summary>
   /// <typeparam name="T">A nullable numeric type.</typeparam>
   /// <seealso cref="Org.Edgerunner.FluentGuard.Validation.NumericValidator{T}" />
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if NDEPEND
   [FullCovered]
#endif
   public class NullableUnsignedNumericValidator<T> : NullableValidatorBase<T> where T : struct
   {
      #region Constructors And Finalizers

      /// <summary>
      /// Initializes a new instance of the <see cref="NullableUnsignedNumericValidator{T}"/> class. 
      /// </summary>
      /// <param name="parameterName">
      /// The name of the parameter being validated.
      /// </param>
      /// <param name="parameterValue">
      /// The value of the parameter being validated.
      /// </param>
      public NullableUnsignedNumericValidator(string parameterName, T? parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      #endregion

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentEqualityException">Must be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsEqualTo(T? value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsGreaterThan(T? value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanX, value));

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than or equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsGreaterThanOrEqualTo(T? value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(
               ParameterName,
               string.Format(Resources.MustBeGreaterThanOrEqualToX, value));

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsLessThan(T? value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanX, value));

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>    
      /// <exception cref="ArgumentOutOfRangeException">Must be less than or equal to <paramref name="value"/>.</exception>  
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsLessThanOrEqualTo(T? value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(
               ParameterName,
               string.Format(Resources.MustBeLessThanOrEqualToX, value));

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentEqualityException">Must not be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsNotEqualTo(T? value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustNotBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not positive.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be positive.</exception>
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsNotPositive()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsPositiveOperation(ParameterValue)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustNotBePositive);

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is positive.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be positive.</exception>
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsPositive()
      {
         if (ShouldReturnAfterEvaluation(PerformIsPositiveOperation(ParameterValue)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustBePositive);

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{NullableUnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentException">Must be <c>null</c>.</exception>
      public ValidatorLinkage<NullableUnsignedNumericValidator<T>> IsNull()
      {
         if (ShouldReturnAfterEvaluation(!PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeNull, ParameterName);

         return new ValidatorLinkage<NullableUnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      /// Performs the IsPositive operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is positive, <c>false</c> otherwise.</returns>
      protected virtual bool PerformIsPositiveOperation(T? currentValue)
      {
         if (!currentValue.HasValue)
            return false;

         return Nullable.Compare(currentValue, default(T)) > 0;
      }
   }
}