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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Org.Edgerunner.FluentGuard.Properties;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   ///    Class that validates data.
   /// </summary>
   /// <typeparam name="T">The type of data to validate.</typeparam>
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
   public class Validator<T>
      where T : IEquatable<T>, IComparable<T>
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

      internal Exception CurrentException { get; set; }

      internal CombinationMode Mode { get; set; }

      internal string ParameterName { get; set; }

      internal T ParameterValue { get; set; }

      /// <summary>
      ///    Combines the current conditional check with a new one using 'And' logic.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      public Validator<T> And()
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
      public Validator<T> And(Validator<T> validator)
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
      ///    Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than <paramref name="value" />.</exception>
      public Validator<T> IsGreaterThan(T value)
      {
         if (ShouldReturnAfterEvaluation(ParameterValue.CompareTo(value) == 1))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanX, value));

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than or equal to <paramref name="value" />.</exception>
      public Validator<T> IsGreaterThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(ParameterValue.CompareTo(value) > -1))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanOrEqualToX, value));

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than <paramref name="value" />.</exception>
      public Validator<T> IsLessThan(T value)
      {
         if (ShouldReturnAfterEvaluation(ParameterValue.CompareTo(value) == -1))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanX, value));

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than or equal to <paramref name="value" />.</exception>
      public Validator<T> IsLessThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(ParameterValue.CompareTo(value) < 1))
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
      public Validator<T> IsEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(ParameterValue.Equals(value)))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeEqualToX, value));

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not null.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be null.</exception>
      public Validator<T> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(ParameterValue != null))
            return this;

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return this;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not null or empty.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be null.</exception>
      /// <exception cref="ArgumentException">Must not be empty.</exception>
      public Validator<T> IsNotNullOrEmpty()
      {
         var paramAsString = ParameterValue as string;
         var valueIsNull = ParameterValue == null;
         if (ShouldReturnAfterEvaluation(!string.IsNullOrEmpty(paramAsString)))
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
      /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
      public Validator<T> StartsWith(string value)
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
      /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
      public Validator<T> EndsWith(string value)
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
      ///    Ors the current conditional check against a new one.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      public Validator<T> Or()
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
      public Validator<T> Or(Validator<T> validator)
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
      public void OtherwiseThrowException()
      {
         // ReSharper disable once ExceptionNotDocumented
         // ReSharper disable once ThrowingSystemException
         if (CurrentException != null)
            throw CurrentException;
      }

      /// <summary>
      ///    Determines whether the current condition evaluation should return.
      /// </summary>
      /// <param name="evaluationResult">The result of a rule evaluation.</param>
      /// <returns><c>true</c> if the rule evaluation method should return, <c>false</c> otherwise.</returns>
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      private bool ShouldReturnAfterEvaluation(bool evaluationResult)
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
   }
}