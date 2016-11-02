﻿#region Apache License 2.0

// <copyright company="Edgerunner.org" file="FloatValidator.cs">
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

namespace Org.Edgerunner.FluentGuard.Validators
{
   /// <summary>
   ///    A Validator class for type <see cref="float" />.
   /// </summary>
   /// <seealso cref="float" />
   public class FloatValidator : Validator<float>
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="FloatValidator" /> class.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      internal FloatValidator(string parameterName, float parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      #endregion

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is greater than or equal to <paramref name="referenceValue" />
      ///    , <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformEqualToOperation(float currentValue, float referenceValue)
      {
         return currentValue.CompareTo(referenceValue) == 0;
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
      protected override bool PerformGreaterThanOperation(float currentValue, float referenceValue)
      {
         return currentValue > referenceValue;
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
      protected override bool PerformGreaterThanOrEqualToOperation(float currentValue, float referenceValue)
      {
         return currentValue >= referenceValue;
      }

      /// <summary>
      ///    Performs the IsNegative operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is negative, <c>false</c> otherwise.</returns>
      protected override bool PerformIsNegativeOperation(float currentValue)
      {
         return currentValue < 0;
      }

      /// <summary>
      ///    Performs the IsPositive operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is positive, <c>false</c> otherwise.</returns>
      protected override bool PerformIsPositiveOperation(float currentValue)
      {
         return currentValue > 0;
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
      protected override bool PerformLessThanOperation(float currentValue, float referenceValue)
      {
         return currentValue < referenceValue;
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
      protected override bool PerformLessThanOrEqualToOperation(float currentValue, float referenceValue)
      {
         return currentValue <= referenceValue;
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not <c>null</c>, <c>false</c> otherwise.</returns>
      protected override bool PerformNotNullOperation(float currentValue)
      {
         return true;
      }
   }
}