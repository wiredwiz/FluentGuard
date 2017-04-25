﻿#region Apache License 2.0
// <copyright company="Edgerunner.org" file="BooleanValidator.cs">
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

namespace Org.Edgerunner.FluentGuard.Validators
{
   /// <summary>
   /// A Validator class for type <see cref="bool" />.
   /// </summary>
   /// <seealso cref="bool" />
   public class BooleanValidator : Validator<bool>
   {
      /// <summary>
      /// Performs the IsTrue operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is true, <c>false</c> otherwise.</returns>
      /// <exception cref="InvalidOperationException">Unable to evalute type for true or false.</exception>
      protected override bool PerformIsTrueOperation(bool currentValue)
      {
         return currentValue;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BooleanValidator"/> class.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">if set to <c>true</c> [parameter value].</param>
      internal BooleanValidator(string parameterName, bool parameterValue)
         : base(parameterName, parameterValue)
      {
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
      ///    Performs the greater than operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is greater than <paramref name="referenceValue" />,
      ///    <c>false</c> otherwise.
      /// </returns>
      /// <exception cref="InvalidOperationException">Unable to perform a Greater Than operation on type boolean.</exception>
      protected override bool PerformGreaterThanOperation(bool currentValue, bool referenceValue)
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
      /// <exception cref="InvalidOperationException">Unable to perform a Greater Than Or Equal To operation on type boolean.</exception>
      protected override bool PerformGreaterThanOrEqualToOperation(bool currentValue, bool referenceValue)
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
      /// <exception cref="InvalidOperationException">Unable to perform a Less Than operation on type boolean.</exception>
      protected override bool PerformLessThanOperation(bool currentValue, bool referenceValue)
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
      /// <exception cref="InvalidOperationException">Unable to perform a Less Than Or Equal To operation on type boolean.</exception>
      protected override bool PerformLessThanOrEqualToOperation(bool currentValue, bool referenceValue)
      {
         throw new InvalidOperationException(Properties.Resources.UnableToPerformALessThanOrEqualToOp);
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not <c>null</c>, <c>false</c> otherwise.</returns>
      protected override bool PerformNotNullOperation(bool currentValue)
      {
         return true;
      }
   }
}