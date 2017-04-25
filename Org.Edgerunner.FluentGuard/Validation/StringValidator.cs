﻿#region Apache License 2.0

// <copyright file="StringValidator.cs" company="Edgerunner.org">
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
using Org.Edgerunner.FluentGuard.Properties;

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   ///    A Validator class for type <see cref="string" />.
   /// </summary>
   /// <seealso cref="string" />
   public class StringValidator : Validator<string>
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="StringValidator" /> class.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      internal StringValidator(string parameterName, string parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      #endregion

      /// <summary>
      ///    Performs the EndsWith operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> ends with <paramref name="referenceValue" />, <c>false</c>
      ///    otherwise.
      /// </returns>
      /// <exception cref="ArgumentNullException"><paramref name="referenceValue" /> is null.</exception>
      protected override bool PerformEndsWithOperation(string currentValue, string referenceValue)
      {
         return currentValue.EndsWith(referenceValue);
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
      protected override bool PerformEqualToOperation(string currentValue, string referenceValue)
      {
         return currentValue == referenceValue;
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
      /// <exception cref="InvalidOperationException">Unable to perform a Greater Than operation on type string.</exception>
      protected override bool PerformGreaterThanOperation(string currentValue, string referenceValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformAGreaterThanOp);
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
      /// <exception cref="InvalidOperationException">Unable to perform a Greater Than Or Equal To operation on type string.</exception>
      protected override bool PerformGreaterThanOrEqualToOperation(string currentValue, string referenceValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformAGreaterThanOrEqualToOp);
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
      /// <exception cref="InvalidOperationException">Unable to perform a Less Than operation on type string.</exception>
      protected override bool PerformLessThanOperation(string currentValue, string referenceValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformALessThanOp);
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
      /// <exception cref="InvalidOperationException">Unable to perform a Less Than Or Equal To operation on type string.</exception>
      protected override bool PerformLessThanOrEqualToOperation(string currentValue, string referenceValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformALessThanOrEqualToOp);
      }

      /// <summary>
      ///    Performs the NotEmpty operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not an empty string, <c>false</c> otherwise.</returns>
      protected override bool PerformNotEmptyOperation(string currentValue)
      {
         return currentValue != string.Empty;
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not <c>null</c>, <c>false</c> otherwise.</returns>
      protected override bool PerformNotNullOperation(string currentValue)
      {
         return currentValue != null;
      }

      /// <summary>
      ///    Performs the StartsWith operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> starts with <paramref name="referenceValue" />, <c>false</c>
      ///    otherwise.
      /// </returns>
      /// <exception cref="ArgumentNullException"><paramref name="referenceValue" /> is null.</exception>
      protected override bool PerformStartsWithOperation(string currentValue, string referenceValue)
      {
         return currentValue.StartsWith(referenceValue);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<StringValidator> IsEqualTo(string value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<StringValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeEqualToX, value));

         return new ValidatorLinkage<StringValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<StringValidator> IsNotEqualTo(string value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<StringValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustNotBeEqualToX, value));

         return new ValidatorLinkage<StringValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      public ValidatorLinkage<StringValidator> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<StringValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return new ValidatorLinkage<StringValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must be <c>null</c>.</exception>
      public ValidatorLinkage<StringValidator> IsNull()
      {
         if (ShouldReturnAfterEvaluation(!PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<StringValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustBeNull);

         return new ValidatorLinkage<StringValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c> or empty.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      /// <exception cref="ArgumentException">Must not be empty.</exception>
      public ValidatorLinkage<StringValidator> IsNotNullOrEmpty()
      {
         var valueIsNull = !PerformNotNullOperation(ParameterValue);
         if (ShouldReturnAfterEvaluation(!valueIsNull && PerformNotEmptyOperation(ParameterValue)))
            return new ValidatorLinkage<StringValidator>(this);

         if (CurrentException == null)
            if (valueIsNull)
               CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);
            else
               CurrentException = new ArgumentException(Resources.MustNotBeEmpty, ParameterName);

         return new ValidatorLinkage<StringValidator>(this);
      }
   }
}