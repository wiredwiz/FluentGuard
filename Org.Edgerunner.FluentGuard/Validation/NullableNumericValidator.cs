﻿#region Apache License 2.0

// <copyright file="NullableNumericValidator.cs" company="Edgerunner.org">
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
   public class NullableNumericValidator<T> : Validator<T>
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="Validator{T}" /> class.
      /// </summary>
      /// <param name="parameterName">The name of the parameter being validated.</param>
      /// <param name="parameterValue">The value of the parameter being validated.</param>
      public NullableNumericValidator(string parameterName, T parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      #endregion

      /// <summary>
      /// Performs the less than operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is less than <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
      /// <exception cref="System.InvalidOperationException">Unable to perform a Less Than operation on the supplied value type.</exception>
      protected virtual bool PerformLessThanOperation(T currentValue, T referenceValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         if (original == null)
            throw new InvalidOperationException(Resources.UnableToPerformALessThanOp);
         return original.CompareTo(referenceValue) == -1;
      }

      /// <summary>
      /// Performs the less than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is less than or equal to <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
      /// <exception cref="System.InvalidOperationException">Unable to perform a Less Than Or Equal To operation on the supplied value type.</exception>
      protected virtual bool PerformLessThanOrEqualToOperation(T currentValue, T referenceValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         if (original == null)
            throw new InvalidOperationException(Resources.UnableToPerformALessThanOrEqualToOp);
         return original.CompareTo(referenceValue) < 1;
      }

      /// <summary>
      /// Performs the greater than operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is greater than <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
      /// <exception cref="System.InvalidOperationException">Unable to perform a Greater Than operation on the supplied value type.</exception>
      protected virtual bool PerformGreaterThanOperation(T currentValue, T referenceValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         if (original == null)
            throw new InvalidOperationException(Resources.UnableToPerformAGreaterThanOp);
         return original.CompareTo(referenceValue) == 1;
      }

      /// <summary>
      /// Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is greater than or equal to <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
      /// <exception cref="System.InvalidOperationException">Unable to perform a Greater Than Or Equal To operation on the supplied value type.</exception>
      protected virtual bool PerformGreaterThanOrEqualToOperation(T currentValue, T referenceValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         if (original == null)
            throw new InvalidOperationException(Resources.UnableToPerformAGreaterThanOrEqualToOp);
         return original.CompareTo(referenceValue) > -1;
      }

      /// <summary>
      /// Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is greater than or equal to <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
      /// <exception cref="System.InvalidOperationException">Unable to perform Equal To operation on the supplied value type.</exception>
      protected virtual bool PerformEqualToOperation(T currentValue, T referenceValue)
      {
         IEquatable<T> original = ParameterValue as IEquatable<T>;
         if (original == null)
            throw new InvalidOperationException(Resources.UnableToPerformAnEqualToOp);
         return original.Equals(referenceValue);
      }

      /// <summary>
      /// Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not <c>null</c>, <c>false</c> otherwise.</returns>
      protected virtual bool PerformNotNullOperation(T currentValue)
      {
         object original = ParameterValue;
         return original != null;
      }

      /// <summary>
      /// Performs the NotEmpty operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not an empty string, <c>false</c> otherwise.</returns>
      /// <exception cref="InvalidOperationException">Only strings can be evaluated for Empty.</exception>
      protected virtual bool PerformNotEmptyOperation(T currentValue)
      {
         throw new InvalidOperationException(Resources.OnlyStringsCanBeEvaluatedForEmpty);
      }

      /// <summary>
      /// Performs the IsPositive operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is positive, <c>false</c> otherwise.</returns>
      /// <exception cref="InvalidOperationException">Unable to evaluate type for positivity or negativity.</exception>
      protected virtual bool PerformIsPositiveOperation(T currentValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformPosNegOp);
      }

      /// <summary>
      /// Performs the IsNegative operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is negative, <c>false</c> otherwise.</returns>
      /// <exception cref="InvalidOperationException">Unable to evaluate type for positivity or negativity.</exception>
      protected virtual bool PerformIsNegativeOperation(T currentValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformPosNegOp);
      }

      /// <summary>
      /// Performs the IsTrue operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is true, <c>false</c> otherwise.</returns>
      /// <exception cref="InvalidOperationException">Unable to evalute type for true or false.</exception>
      protected virtual bool PerformIsTrueOperation(T currentValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformBooleanOp);
      }

      /// <summary>
      /// Performs the StartsWith operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> starts with <paramref name="referenceValue" />, <c>false</c> otherwise.</returns>
      /// <exception cref="InvalidOperationException">Unable to perform a StartsWith operation on the supplied value type.</exception>
      protected virtual bool PerformStartsWithOperation(T currentValue, T referenceValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformAStartsWithOp);
      }

      /// <summary>
      /// Performs the EndsWith operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> ends with <paramref name="referenceValue" />, <c>false</c> otherwise.</returns>
      /// <exception cref="InvalidOperationException">Unable to perform an EndsWith operation on the supplied value type.</exception>
      protected virtual bool PerformEndsWithOperation(T currentValue, T referenceValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformAnEndsWithOp);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeEqualToX, value));

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsGreaterThan(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanX, value));

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsGreaterThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanOrEqualToX, value));

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsLessThan(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanX, value));

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsLessThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanOrEqualToX, value));

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is negative.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsNegative()
      {
         if (ShouldReturnAfterEvaluation(PerformIsNegativeOperation(ParameterValue)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustBeNegative);

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsNotEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustNotBeEqualToX, value));

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not negative.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsNotNegative()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsNegativeOperation(ParameterValue)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustNotBeNegative);

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not positive.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsNotPositive()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsPositiveOperation(ParameterValue)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustNotBePositive);

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is positive.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsPositive()
      {
         if (ShouldReturnAfterEvaluation(PerformIsPositiveOperation(ParameterValue)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustBePositive);

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="ArgumentException">Must be <c>null</c>.</exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsNull()
      {
         if (ShouldReturnAfterEvaluation(!PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustBeNull);

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }
   }
}