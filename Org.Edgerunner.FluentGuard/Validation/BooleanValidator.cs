#region Apache License 2.0

// <copyright company="Edgerunner.org" file="BooleanValidator.cs">
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
using Org.Edgerunner.FluentGuard.Attributes;
using Org.Edgerunner.FluentGuard.Properties;

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   ///    A Validator class for type <see cref="bool" />.
   /// </summary>
   /// <seealso cref="bool" />
   [FullCovered]
   public class BooleanValidator : Validator<bool>
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="BooleanValidator" /> class.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">if set to <c>true</c> [parameter value].</param>
      internal BooleanValidator(string parameterName, bool parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      #endregion

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<BooleanValidator> IsEqualTo(bool value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<BooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeEqualToX, value));

         return new ValidatorLinkage<BooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>false</c>.
      /// </summary>
      /// <returns>The current <see cref="ValidatorLinkage{TV, TT}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>false</c>.</exception>
      public ValidatorLinkage<BooleanValidator> IsFalse()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsTrueOperation(ParameterValue)))
            return new ValidatorLinkage<BooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeFalse, ParameterName);

         return new ValidatorLinkage<BooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<BooleanValidator> IsNotEqualTo(bool value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<BooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustNotBeEqualToX, value));

         return new ValidatorLinkage<BooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>true</c>.
      /// </summary>
      /// <returns>The current <see cref="ValidatorLinkage{TV, TT}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>true</c>.</exception>
      public ValidatorLinkage<BooleanValidator> IsTrue()
      {
         if (ShouldReturnAfterEvaluation(PerformIsTrueOperation(ParameterValue)))
            return new ValidatorLinkage<BooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeTrue, ParameterName);

         return new ValidatorLinkage<BooleanValidator>(this);
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
      protected override bool PerformEqualToOperation(bool currentValue, bool referenceValue)
      {
         return currentValue == referenceValue;
      }

      /// <summary>
      ///    Performs the IsTrue operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is true, <c>false</c> otherwise.</returns>
      /// <exception cref="InvalidOperationException">Unable to evalute type for true or false.</exception>
      protected virtual bool PerformIsTrueOperation(bool currentValue)
      {
         return currentValue;
      }
   }
}