#region Apache License 2.0

// <copyright company="Edgerunner.org" file="NullableDateTimeValidator.cs">
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
using NDepend.Attributes;
using Org.Edgerunner.FluentGuard.Properties;
// ReSharper disable ExceptionNotThrown

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   /// Class for validating nullable DateTime values.
   /// </summary>
   /// <seealso cref="DateTime" />
   /// <seealso cref="Nullable"/>
   [FullCovered]
   public class NullableDateTimeValidator : NullableValidator<DateTime>
   {
      #region Constructors And Finalizers

      /// <summary>
      /// Initializes a new instance of the <see cref="NullableDateTimeValidator"/> class. 
      /// </summary>
      /// <param name="parameterName">
      /// The name of the parameter being validated.
      /// </param>
      /// <param name="parameterValue">
      /// The value of the parameter being validated.
      /// </param>
      public NullableDateTimeValidator(string parameterName, DateTime? parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      #endregion

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NullableDateTimeValidator> IsEqualTo(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeEqualToX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NullableDateTimeValidator> IsGreaterThan(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NullableDateTimeValidator> IsGreaterThanOrEqualTo(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(
               ParameterName,
               string.Format(Resources.MustBeGreaterThanOrEqualToX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NullableDateTimeValidator> IsLessThan(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NullableDateTimeValidator> IsLessThanOrEqualTo(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(
               ParameterName,
               string.Format(Resources.MustBeLessThanOrEqualToX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NullableDateTimeValidator> IsNotEqualTo(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustNotBeEqualToX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      public ValidatorLinkage<NullableDateTimeValidator> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must be <c>null</c>.</exception>
      public ValidatorLinkage<NullableDateTimeValidator> IsNull()
      {
         if (ShouldReturnAfterEvaluation(!PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustBeNull);

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is greater than or equal to <paramref name="referenceValue" />
      ///    , <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformEqualToOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Equals(currentValue, referenceValue);
      }

      /// <summary>
      ///    Performs the greater than operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is greater than <paramref name="referenceValue" />,
      ///    <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformGreaterThanOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Compare(currentValue, referenceValue) > 0;
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is greater than or equal to <paramref name="referenceValue" />
      ///    , <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformGreaterThanOrEqualToOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Compare(currentValue, referenceValue) >= 0;
      }

      /// <summary>
      ///    Performs the less than operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is less than <paramref name="referenceValue" />, <c>false</c>
      ///    otherwise.
      /// </returns>
      protected override bool PerformLessThanOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Compare(currentValue, referenceValue) < 0;
      }

      /// <summary>
      ///    Performs the less than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is less than or equal to <paramref name="referenceValue" />,
      ///    <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformLessThanOrEqualToOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Compare(currentValue, referenceValue) <= 0;
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not <c>null</c>, <c>false</c> otherwise.</returns>
      protected override bool PerformNotNullOperation(DateTime? currentValue)
      {
         return currentValue.HasValue;
      }
   }
}