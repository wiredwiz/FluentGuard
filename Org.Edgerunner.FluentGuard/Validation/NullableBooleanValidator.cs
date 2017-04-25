#region Apache License 2.0
// <copyright company="Edgerunner.org" file="NullableBooleanValidator.cs">
// Copyright (c)  2016
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
   /// A Validator class for type <see cref="Nullable{T}" /> where T is <see cref="bool" />.
   /// </summary>
   /// <seealso cref="bool" />
   /// <seealso cref="Nullable"/>
   public class NullableBooleanValidator : Validator<bool?>
   {
      /// <summary>
      /// Performs the IsTrue operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is true, <c>false</c> otherwise.</returns>
      /// <exception cref="InvalidOperationException">Unable to evalute type for true or false.</exception>
      protected override bool PerformIsTrueOperation(bool? currentValue)
      {
         return currentValue.HasValue && currentValue.Value;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="NullableBooleanValidator"/> class.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">if set to <c>true</c> [parameter value].</param>
      internal NullableBooleanValidator(string parameterName, bool? parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      /// <summary>
      ///    Performs the equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is greater than or equal to <paramref name="referenceValue" />
      ///    , <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformEqualToOperation(bool? currentValue, bool? referenceValue)
      {
         if (!currentValue.HasValue && !referenceValue.HasValue)
            return true;
         if (currentValue.HasValue != referenceValue.HasValue)
            return false;
         return currentValue.Value == referenceValue.Value;
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
      /// <exception cref="InvalidOperationException">Unable to perform a Greater Than operation on type bool?ean.</exception>
      protected override bool PerformGreaterThanOperation(bool? currentValue, bool? referenceValue)
      {
         throw new InvalidOperationException(Properties.Resources.UnableToPerformAGreaterThanOp);
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
      /// <exception cref="InvalidOperationException">Unable to perform a Greater Than Or Equal To operation on type bool?ean.</exception>
      protected override bool PerformGreaterThanOrEqualToOperation(bool? currentValue, bool? referenceValue)
      {
         throw new InvalidOperationException(Properties.Resources.UnableToPerformAGreaterThanOrEqualToOp);
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
      /// <exception cref="InvalidOperationException">Unable to perform a Less Than operation on type bool?ean.</exception>
      protected override bool PerformLessThanOperation(bool? currentValue, bool? referenceValue)
      {
         throw new InvalidOperationException(Properties.Resources.UnableToPerformALessThanOp);
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
      /// <exception cref="InvalidOperationException">Unable to perform a Less Than Or Equal To operation on type bool?ean.</exception>
      protected override bool PerformLessThanOrEqualToOperation(bool? currentValue, bool? referenceValue)
      {
         throw new InvalidOperationException(Properties.Resources.UnableToPerformALessThanOrEqualToOp);
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not <c>null</c>, <c>false</c> otherwise.</returns>
      protected override bool PerformNotNullOperation(bool? currentValue)
      {
         return currentValue.HasValue;
      }

      /// <summary>
      /// Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NullableBooleanValidator> IsEqualTo(bool? value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeEqualToX, value));

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<NullableBooleanValidator> IsNotEqualTo(bool? value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustNotBeEqualToX, value));

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is <c>false</c>.
      /// </summary>
      /// <returns>The current <see cref="ValidatorLinkage{TV, TT}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>false</c>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsFalse()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsTrueOperation(ParameterValue)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeFalse, ParameterName);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is <c>true</c>.
      /// </summary>
      /// <returns>The current <see cref="ValidatorLinkage{TV, TT}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>true</c>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsTrue()
      {
         if (ShouldReturnAfterEvaluation(PerformIsTrueOperation(ParameterValue)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeTrue, ParameterName);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must be <c>null</c>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsNull()
      {
         if (ShouldReturnAfterEvaluation(!PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustBeNull);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }
   }
}