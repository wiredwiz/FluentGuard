#region Apache License 2.0

// <copyright company="Edgerunner.org" file="Validator.cs">
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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Org.Edgerunner.FluentGuard.Properties;

namespace Org.Edgerunner.FluentGuard.Validators
{
   /// <summary>
   /// Class that validates data.
   /// </summary>
   /// <typeparam name="T">The type of data to validate.</typeparam>
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "The potential string format exceptions will not occurr.")]
   // ReSharper disable once ClassTooBig
   public class Validator<T>
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="Validator{T}" /> class.
      /// </summary>
      /// <param name="parameterName">The name of the parameter being validated.</param>
      /// <param name="parameterValue">The value of the parameter being validated.</param>
      internal Validator(string parameterName, T parameterValue)
      {
         ParameterName = parameterName;
         ParameterValue = parameterValue;
         Mode = CombinationMode.And;
         CurrentException = null;
      }

      #endregion

      /// <summary>
      /// Gets or sets the current exception.
      /// </summary>
      /// <value>The current exception.</value>
      internal Exception CurrentException { get; set; }

      /// <summary>
      /// Gets or sets the <see cref="CombinationMode"/> to use when combining conditions.
      /// </summary>
      /// <value>The mode.</value>
      internal CombinationMode Mode { get; set; }

      /// <summary>
      /// Gets the name of the parameter being checked.
      /// </summary>
      /// <value>The name of the parameter.</value>
      public virtual string ParameterName { get; private set; }

      /// <summary>
      /// Gets the parameter value being checked.
      /// </summary>
      /// <value>The parameter value.</value>
      public virtual T ParameterValue { get; private set; }

      /// <summary>
      ///    Combines the current conditional check with a new one using 'And' logic.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      public virtual Validator<T> And()
      {
         Mode = CombinationMode.And;
         return this;
      }

      /// <summary>
      /// Combines the current conditional check with a new one using 'And' logic.
      /// </summary>
      /// <param name="validator">The validator to AND against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      public virtual Validator<T> And(Validator<T> validator)
      {
         Validator<T> result = null;

         if (this.CurrentException != null)
            result = this;
         else if (validator.CurrentException != null)
            result = validator;

         if (result == null)
            result = this;

         result.Mode = CombinationMode.And;
         return result;
      }

      /// <summary>
      /// Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than <paramref name="value" />.</exception>
      public virtual Validator<T> IsGreaterThan(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOperation(ParameterValue, value)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanX, value));

         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than or equal to <paramref name="value" />.</exception>
      public virtual Validator<T> IsGreaterThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOrEqualToOperation(ParameterValue, value)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanOrEqualToX, value));

         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than <paramref name="value" />.</exception>
      /// <exception cref="InvalidOperationException">Unable to perform a Less Than operation on the supplied value type.</exception>
      public virtual Validator<T> IsLessThan(T value)
      {
         // ReSharper disable once EventExceptionNotDocumented
         if (ShouldReturnAfterEvaluation(PerformLessThanOperation(ParameterValue, value)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanX, value));

         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than or equal to <paramref name="value" />.</exception>
      public virtual Validator<T> IsLessThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOrEqualToOperation(ParameterValue, value)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanOrEqualToX, value));

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be equal to <paramref name="value" />.</exception>
      public virtual Validator<T> IsEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(ParameterValue.Equals(value)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeEqualToX, value));

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be equal to <paramref name="value" />.</exception>
      public virtual Validator<T> IsNotEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(!ParameterValue.Equals(value)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustNotBeEqualToX, value));

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      public virtual Validator<T> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(PerformNotNullOperation(ParameterValue)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c> or empty.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      /// <exception cref="ArgumentException">Must not be empty.</exception>
      public virtual Validator<T> IsNotNullOrEmpty()
      {
         var valueIsNull = !PerformNotNullOperation(ParameterValue);
         if (ShouldReturnAfterEvaluation(!valueIsNull && PerformNotEmptyOperation(ParameterValue)))
            return this;

         if (CurrentException == null)
            if (valueIsNull)
               CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);
            else
               CurrentException = new ArgumentException(Resources.MustNotBeEmpty, ParameterName);

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated starts with the value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must start with <paramref name="value"/>.</exception>
      /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
      public virtual Validator<T> StartsWith(string value)
      {
         if (value == null)
            throw new ArgumentNullException(Resources.ValueIsNull, nameof(value));

         var paramAsString = ParameterValue as string;
         if (ShouldReturnAfterEvaluation(paramAsString != null && paramAsString.StartsWith(value)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentException(string.Format(Resources.MustStartWithX, value), ParameterName);

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated ends with the value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must end with <paramref name="value"/>.</exception>
      /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
      public virtual Validator<T> EndsWith(string value)
      {
         if (value == null)
            throw new ArgumentNullException(Resources.ValueIsNull, nameof(value));

         var paramAsString = ParameterValue as string;
         if (ShouldReturnAfterEvaluation(paramAsString != null && paramAsString.EndsWith(value)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentException(string.Format(Resources.MustEndWithX, value), ParameterName);

         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is <c>false</c>.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>false</c>.</exception>
      public virtual Validator<T> IsFalse()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsTrueOperation(ParameterValue)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeFalse, ParameterName);

         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is <c>true</c>.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>true</c>.</exception>
      public virtual Validator<T> IsTrue()
      {
         if (ShouldReturnAfterEvaluation(PerformIsTrueOperation(ParameterValue)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeTrue, ParameterName);

         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is positive.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be positive.</exception>
      public virtual Validator<T> IsPositive()
      {
         if (ShouldReturnAfterEvaluation(PerformIsPositiveOperation(ParameterValue)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustBePositive);

         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is negative.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be negative.</exception>
      public virtual Validator<T> IsNegative()
      {
         if (ShouldReturnAfterEvaluation(PerformIsNegativeOperation(ParameterValue)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustBeNegative);

         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is not negative.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be negative.</exception>
      public virtual Validator<T> IsNotNegative()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsNegativeOperation(ParameterValue)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustNotBeNegative);

         return this;
      }

      /// <summary>
      /// Determines whether the parameter being validated is not positive.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be positive.</exception>
      public virtual Validator<T> IsNotPositive()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsPositiveOperation(ParameterValue)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustNotBePositive);

         return this;
      }

      /// <summary>
      ///    Ors the current conditional check against a new one.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      public virtual Validator<T> Or()
      {
         Mode = CombinationMode.Or;
         return this;
      }

      /// <summary>
      /// Ors the current conditional check against a new one.
      /// </summary>
      /// <param name="validator">The validator to OR against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      public virtual Validator<T> Or(Validator<T> validator)
      {
         Validator<T> result = null;

         if (this.CurrentException == null)
            result = this;
         else if (validator.CurrentException == null)
            result = validator;

         if (result == null)
            result = this;

         result.Mode = CombinationMode.Or;
         return result;
      }

      /// <summary>
      ///    Throws a new exception.
      /// </summary>
      public virtual void OtherwiseThrowException()
      {
         // ReSharper disable once ExceptionNotDocumented
         // ReSharper disable once ThrowingSystemException
         if (CurrentException != null)
            throw CurrentException;
      }

      /// <summary>
      /// Throws a new exception.
      /// </summary>
      /// <typeparam name="TE">The type of exception.</typeparam>
      /// <param name="exception">The exception to throw.</param>
      public virtual void OtherwiseThrow<TE>(TE exception) where TE : Exception, new()
      {
         // ReSharper disable once ExceptionNotDocumented
         // ReSharper disable once ThrowingSystemException
         if (CurrentException != null)
            throw exception;
      }

      /// <summary>
      ///    Determines whether the current condition evaluation should return.
      /// </summary>
      /// <param name="evaluationResult">The result of a rule evaluation.</param>
      /// <returns><c>true</c> if the rule evaluation method should return, <c>false</c> otherwise.</returns>
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      // ReSharper disable once FlagArgument
      protected bool ShouldReturnAfterEvaluation(bool evaluationResult)
      {
         if (Mode == CombinationMode.And)
            if (CurrentException != null)
               return true;

         if (!evaluationResult)
            if (Mode == CombinationMode.Or
                && CurrentException == null)
               return true;
            else
               return false;

         if (Mode == CombinationMode.Or)
            CurrentException = null;

         return true;
      }

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
         IComparable<T> original = ParameterValue as IComparable<T>;
         if (original == null)
            throw new InvalidOperationException(Resources.UnableToPerformAnEqualToOp);
         return original.CompareTo(referenceValue) == 0;
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
      protected virtual bool PerformIsTrueOperation(T currentValue)
      {
         throw new InvalidOperationException(Resources.UnableToPerformBooleanOp);
      }
   }
}