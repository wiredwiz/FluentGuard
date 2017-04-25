#region Apache License 2.0

// <copyright file="NumericValidator.cs" company="Edgerunner.org">
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
   public class UnsignedNumericValidator<T> : Validator<T>
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="Validator{T}" /> class.
      /// </summary>
      /// <param name="parameterName">The name of the parameter being validated.</param>
      /// <param name="parameterValue">The value of the parameter being validated.</param>
      public UnsignedNumericValidator(string parameterName, T parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      #endregion

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeEqualToX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsGreaterThan(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsGreaterThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanOrEqualToX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsLessThan(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsLessThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanOrEqualToX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsNotEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustNotBeEqualToX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not positive.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsNotPositive()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsPositiveOperation(ParameterValue)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustNotBePositive);

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is positive.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      /// <exception cref="System.NotImplementedException"></exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsPositive()
      {
         if (ShouldReturnAfterEvaluation(PerformIsPositiveOperation(ParameterValue)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustBePositive);

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }
   }
}