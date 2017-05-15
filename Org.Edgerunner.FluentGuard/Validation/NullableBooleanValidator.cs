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
using System.Diagnostics.CodeAnalysis;
using NDepend.Attributes;
using Org.Edgerunner.FluentGuard.Exceptions;
using Org.Edgerunner.FluentGuard.Properties;

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   /// A Validator class for type <see cref="Nullable{T}" /> where T is <see cref="bool" />.
   /// </summary>
   /// <seealso cref="bool" />
   /// <seealso cref="Nullable"/>
   [FullCovered]
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
   public class NullableBooleanValidator : NullableValidator<bool>
   {
      /// <summary>
      /// Performs the IsTrue operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is true, <c>false</c> otherwise.</returns>
      protected virtual bool PerformIsTrueOperation(bool? currentValue)
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
      /// Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableBooleanValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must be equal to <paramref name="value"/>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsEqualTo(bool? value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="ValidatorLinkage{NullableBooleanValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must not be equal to <paramref name="value"/>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsNotEqualTo(bool? value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustNotBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is <c>false</c>.
      /// </summary>
      /// <returns>The current <see cref="ValidatorLinkage{NullableBooleanValidator}" /> instance.</returns>
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
      /// <returns>The current <see cref="ValidatorLinkage{NullableBooleanValidator}" /> instance.</returns>
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