#region Apache License 2.0

// <copyright company="Edgerunner.org" file="StringValidator.cs">
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

using Org.Edgerunner.FluentGuard.Exceptions;
using Org.Edgerunner.FluentGuard.Properties;

#if NDEPEND
using NDepend.Attributes;
#endif

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   ///    A ValidatorBase class for type <see cref="string" />.
   /// </summary>
   /// <seealso cref="string" />
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if NDEPEND
   [FullCovered]
#endif
   public class StringValidator : ValidatorBase<string>
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
      ///    Determines whether the parameter being validated ends with the value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must end with <paramref name="value" />.</exception>
      /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
      public virtual ValidatorLinkage<StringValidator> EndsWith(string value)
      {
         if (ShouldReturnAfterEvaluation(PerformEndsWithOperation(ParameterValue, value)))
            return new ValidatorLinkage<StringValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(string.Format(Resources.MustEndWithX, value), ParameterName);

         return new ValidatorLinkage<StringValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must be equal to <paramref name="value" />.</exception>
      public ValidatorLinkage<StringValidator> IsEqualTo(string value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<StringValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<StringValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must not be equal to <paramref name="value" />.</exception>
      public ValidatorLinkage<StringValidator> IsNotEqualTo(string value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<StringValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustNotBeEqualToX, value), ParameterName);

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
      ///    Determines whether the parameter being validated is not <c>null</c> or empty.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
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
            CurrentException = new ArgumentException(Resources.MustBeNull, ParameterName);

         return new ValidatorLinkage<StringValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated starts with the value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must start with <paramref name="value" />.</exception>
      /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
      public virtual ValidatorLinkage<StringValidator> StartsWith(string value)
      {
         if (ShouldReturnAfterEvaluation(PerformStartsWithOperation(ParameterValue, value)))
            return new ValidatorLinkage<StringValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(string.Format(Resources.MustStartWithX, value), ParameterName);

         return new ValidatorLinkage<StringValidator>(this);
      }

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
      protected virtual bool PerformEndsWithOperation(string currentValue, string referenceValue)
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
      ///    Performs the NotEmpty operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not an empty string, <c>false</c> otherwise.</returns>
      protected virtual bool PerformNotEmptyOperation(string currentValue)
      {
         return currentValue != string.Empty;
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not <c>null</c>, <c>false</c> otherwise.</returns>
      protected virtual bool PerformNotNullOperation(string currentValue)
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
      protected virtual bool PerformStartsWithOperation(string currentValue, string referenceValue)
      {
         return currentValue.StartsWith(referenceValue);
      }
   }
}