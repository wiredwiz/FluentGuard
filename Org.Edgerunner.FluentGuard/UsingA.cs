#region Apache License 2.0

// <copyright file="UsingA.cs" company="Edgerunner.org">
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
using System.Linq.Expressions;
using System.Reflection;
using Org.Edgerunner.FluentGuard.Validation;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   /// Class for validation of inputs.
   /// </summary>
   public static class UsingA<TV, T> where TV : Validator<T>
   {
      /// <summary>
      /// Gets or sets the factory to use for generating new validators.
      /// </summary>
      /// <value>An <see cref="IValidatorFactory"/> instance.</value>
      public static IValidatorFactory Factory { get; set; } = new ValidatorFactory();

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="Validator{T}" /> instance.</returns>
      public static TV ValidateThat(string nameOfParameter, T parameterValue)
      {
         return Factory.Create(nameOfParameter, parameterValue) as TV;
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="variableExpression">The variable expression to validate.</param>
      /// <returns>A new <see cref="Validator{T}" /> instance.</returns>
      /// <exception cref="TargetException"><paramref name="variableExpression" /> is null.</exception>
      public static TV ValidateThat(Expression<Func<T>> variableExpression)
      {
         var body = (MemberExpression)variableExpression.Body;
         var nameOfParameter = body.Member.Name;
         // ReSharper disable ExceptionNotDocumentedOptional
         // ReSharper disable ExceptionNotDocumented
         var parameterValue = (T)((FieldInfo)body.Member).GetValue(((ConstantExpression)body.Expression).Value);
         // ReSharper restore ExceptionNotDocumented
         // ReSharper restore ExceptionNotDocumentedOptional
         return Factory.Create(nameOfParameter, parameterValue) as TV;
      }
   }
}