#region Apache License 2.0

// <copyright file="Ensure.cs" company="Edgerunner.org">
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
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.FluentGuard.Validators;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   /// Class for validation of inputs.
   /// </summary>
   public static class Ensure
   {
      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <typeparam name="T">The type of data being validated.</typeparam>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="Validator{T}"/> instance.</returns>
      public static Validator<T> That<T>(string nameOfParameter, T parameterValue)
      {
         return ValidatorFactory.Create<T>(nameOfParameter, parameterValue);
      }

      ///// <summary>
      ///// Validates the specified member value.
      ///// </summary>
      ///// <typeparam name="T">The type of object being inspected.</typeparam>
      ///// <typeparam name="TValue">The type of data being validated.</typeparam>
      ///// <param name="expression">The member expression.</param>
      ///// <returns>A new <see cref="Validator{TValue}" /> instance.</returns>
      ///// <exception cref="ArgumentException">Not a member access expression.</exception>
      ///// <exception cref="NotSupportedException">A field is marked literal, but the field does not have one of the accepted literal types.</exception>
      //public static Validator<TValue> That<TValue>(Expression<Func<TValue>> expression)
      //{
      //   MemberExpression memberExpression = null;

      //   if (expression.Body.NodeType == ExpressionType.Convert)
      //   {
      //      var body = (UnaryExpression)expression.Body;
      //      memberExpression = body.Operand as MemberExpression;
      //   }
      //   else if (expression.Body.NodeType == ExpressionType.MemberAccess)
      //      memberExpression = expression.Body as MemberExpression;

      //   if (memberExpression == null)
      //      throw new ArgumentException(Resources.NotAMemberAccess, nameof(expression));

      //   var propertyInfo = memberExpression.Member as PropertyInfo;
      //   if (propertyInfo != null)
      //      return new Validator<TValue>(expression.GetMemberPath(), (TValue)propertyInfo.GetValue(memberExpression));

      //   var fieldInfo = memberExpression.Member as FieldInfo;
      //   if (fieldInfo != null)
      //      // ReSharper disable once ExceptionNotDocumented
      //      return new Validator<TValue>(expression.GetMemberPath(), (TValue)fieldInfo.GetValue(memberExpression));

      //   // ReSharper disable once ExceptionNotDocumentedOptional
      //   throw new ArgumentException(string.Format(Resources.UnableToAccess, expression), nameof(expression));
      //}
   }
}