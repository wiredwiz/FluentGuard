#region Apache License 2.0
// <copyright file="ValidatorFactory.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.FluentGuard.Validators
{
   /// <summary>
   /// Factory class for creating new validator instances.
   /// </summary>
   internal static class ValidatorFactory
   {
      /// <summary>
      /// Creates a new instance of <see cref="IValidator{T}"/>.
      /// </summary>
      /// <typeparam name="T">The type of data to validate.</typeparam>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      /// <returns>A new <see cref="IValidator{T}"/> instance.</returns>
      public static IValidator<T> Create<T>(string parameterName, T parameterValue)
      {
         return new Validator<T>(parameterName, parameterValue);
      }
   }
}