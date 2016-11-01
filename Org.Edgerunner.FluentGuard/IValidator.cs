#region Apache License 2.0

// <copyright file="IValidator.cs" company="Edgerunner.org">
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
using Org.Edgerunner.FluentGuard.Validators;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   /// Interface that defines a validator.
   /// </summary>
   /// <typeparam name="T">The type being evaluated.</typeparam>
   public interface IValidator<T>
   {
      /// <summary>
      /// Gets the name of the parameter being checked.
      /// </summary>
      /// <value>The name of the parameter.</value>
      string ParameterName { get; }

      /// <summary>
      /// Gets the parameter value being checked.
      /// </summary>
      /// <value>The parameter value.</value>
      T ParameterValue { get; }

      /// <summary>
      ///    Combines the current conditional check with a new one using 'And' logic.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      Validator<T> And();

      /// <summary>
      ///    Combines the current conditional check with a new one using 'And' logic.
      /// </summary>
      /// <param name="validator">The validator to AND against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      Validator<T> And(Validator<T> validator);

      /// <summary>
      ///    Determines whether the parameter being validated ends with the value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must end with <paramref name="value" />.</exception>
      /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
      Validator<T> EndsWith(string value);

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be equal to <paramref name="value" />.</exception>
      Validator<T> IsEqualTo(T value);

      /// <summary>
      ///    Determines whether the parameter being validated is <c>false</c>.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>false</c>.</exception>
      Validator<T> IsFalse();

      /// <summary>
      ///    Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <typeparam name="TS">The type of value to compare.</typeparam>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than <paramref name="value" />.</exception>
      Validator<T> IsGreaterThan<TS>(TS value) where TS : IComparable<T>;

      /// <summary>
      ///    Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <typeparam name="TS">The type of value to compare.</typeparam>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than or equal to <paramref name="value" />.</exception>
      Validator<T> IsGreaterThanOrEqualTo<TS>(TS value) where TS : IComparable<T>;

      /// <summary>
      ///    Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <typeparam name="TS">The type of value to compare.</typeparam>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than <paramref name="value" />.</exception>
      Validator<T> IsLessThan<TS>(TS value) where TS : IComparable<T>;

      /// <summary>
      ///    Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <typeparam name="TS">The type of value to compare.</typeparam>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than or equal to <paramref name="value" />.</exception>
      Validator<T> IsLessThanOrEqualTo<TS>(TS value) where TS : IComparable<T>;

      /// <summary>
      ///    Determines whether the parameter being validated is negative.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be negative.</exception>
      Validator<T> IsNegative();

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be equal to <paramref name="value" />.</exception>
      Validator<T> IsNotEqualTo(T value);

      /// <summary>
      ///    Determines whether the parameter being validated is not negative.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be negative.</exception>
      Validator<T> IsNotNegative();

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      Validator<T> IsNotNull();

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c> or empty.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      /// <exception cref="ArgumentException">Must not be empty.</exception>
      Validator<T> IsNotNullOrEmpty();

      /// <summary>
      ///    Determines whether the parameter being validated is not positive.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be positive.</exception>
      Validator<T> IsNotPositive();

      /// <summary>
      ///    Determines whether the parameter being validated is positive.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be positive.</exception>
      Validator<T> IsPositive();

      /// <summary>
      ///    Determines whether the parameter being validated is <c>true</c>.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>true</c>.</exception>
      Validator<T> IsTrue();

      /// <summary>
      ///    Ors the current conditional check against a new one.
      /// </summary>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      Validator<T> Or();

      /// <summary>
      ///    Ors the current conditional check against a new one.
      /// </summary>
      /// <param name="validator">The validator to OR against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      // ReSharper disable once MethodNameNotMeaningful
      Validator<T> Or(Validator<T> validator);

      /// <summary>
      ///    Throws a new exception.
      /// </summary>
      /// <typeparam name="TE">The type of exception.</typeparam>
      /// <param name="exception">The exception to throw.</param>
      void OtherwiseThrow<TE>(TE exception) where TE : Exception, new();

      /// <summary>
      ///    Throws a new exception.
      /// </summary>
      void OtherwiseThrowException();

      /// <summary>
      ///    Determines whether the parameter being validated starts with the value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must start with <paramref name="value" />.</exception>
      /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
      Validator<T> StartsWith(string value);
   }
}