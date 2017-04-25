#region Apache License 2.0
// <copyright file="IPositivityValidator.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.FluentGuard.Validation
{
   public interface IPositivityValidator<TV, TT> where TV : Validator<TT>
   {
      /// <summary>
      /// Determines whether the parameter being validated is negative.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{TV, TT}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be negative.</exception>
      ValidatorLinkage<TV, TT> IsNegative();

      /// <summary>
      /// Determines whether the parameter being validated is not negative.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{TV, TT}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be negative.</exception>
      ValidatorLinkage<TV, TT> IsNotNegative();

      /// <summary>
      /// Determines whether the parameter being validated is positive.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{TV, TT}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be positive.</exception>
      ValidatorLinkage<TV, TT> IsPositive();

      /// <summary>
      /// Determines whether the parameter being validated is not positive.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{TV, TT}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be positive.</exception>
      ValidatorLinkage<TV, TT> IsNotPositive();
   }
}