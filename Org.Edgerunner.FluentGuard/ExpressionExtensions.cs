#region Apache License 2.0

// <copyright file="ExpressionExtensions.cs" company="FluentAssertions Project">
// Copyright 2016 FluentAssertions Project
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

// This class was not written by me, but by the folks that work on the FluentAssertions Project.
// I take no credit for their wonderful work.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   ///    Class of Expression extension methods.
   /// </summary>
   /// <remarks>Shamelessly lifted from the great FluentAssertions library.  I take no credit for this class.</remarks>
   public static class ExpressionExtensions
   {
      /// <summary>
      ///    Gets a dotted path of property names representing the property expression. E.g. Parent.Child.Sibling.Name.
      /// </summary>
      /// <typeparam name="TDeclaringType">The type of the declaring type.</typeparam>
      /// <typeparam name="TPropertyType">The type of the property or field referenced.</typeparam>
      /// <param name="expression">The expression being evaluated.</param>
      /// <returns>A dotted path <see cref="string" /> representing the expression.</returns>
      /// <exception cref="System.NullReferenceException">Expected an expression, but found <c>null</c>.</exception>
      /// <exception cref="ArgumentException">Expression cannot be used to select a member.</exception>
      public static string GetMemberPath<TDeclaringType, TPropertyType>(this Expression<Func<TDeclaringType, TPropertyType>> expression)
      {
         var segments = new List<string>();
         Expression node = expression;

         if (node == null)
         {
            throw new NullReferenceException("Expected an expression, but found <null>.");
         }

         while (node != null)
         {
            switch (node.NodeType)
            {
               case ExpressionType.Lambda:
                  node = ((LambdaExpression)node).Body;
                  break;

               case ExpressionType.Convert:
               case ExpressionType.ConvertChecked:
                  var unaryExpression = (UnaryExpression)node;
                  node = unaryExpression.Operand;
                  break;

               case ExpressionType.MemberAccess:
                  var memberExpression = (MemberExpression)node;
                  node = memberExpression.Expression;

                  segments.Add(memberExpression.Member.Name);
                  break;

               case ExpressionType.ArrayIndex:
                  var binaryExpression = (BinaryExpression)node;
                  var constantExpression = (ConstantExpression)binaryExpression.Right;
                  node = binaryExpression.Left;

                  segments.Add("[" + constantExpression.Value + "]");
                  break;

               case ExpressionType.Parameter:
                  node = null;
                  break;

               default:
                  throw new ArgumentException($"Expression <{expression.Body}> cannot be used to select a member.");
            }
         }

         // ReSharper disable ExceptionNotDocumentedOptional
         return string.Join(".", segments.AsEnumerable().Reverse().ToArray()).Replace(".[", "[");

         // ReSharper restore ExceptionNotDocumentedOptional
      }

      /// <summary>
      ///    Gets the property information from an expression.
      /// </summary>
      /// <typeparam name="T">The type of the declaring type.</typeparam>
      /// <typeparam name="TValue">The type of the property.</typeparam>
      /// <param name="expression">The expression to evaluate.</param>
      /// <returns>The corresponding <see cref="PropertyInfo" />.</returns>
      /// <exception cref="System.NullReferenceException">Expected a property expression, but found <c>null</c>.</exception>
      /// <exception cref="System.ArgumentException">Cannot use the supplied expression when a property expression is expected.</exception>
      public static PropertyInfo GetPropertyInfo<T, TValue>(this Expression<Func<T, TValue>> expression)
      {
         if (ReferenceEquals(expression, null))
         {
            throw new NullReferenceException("Expected a property expression, but found <null>.");
         }

         var memberInfo = AttemptToGetMemberInfoFromCastExpression(expression) ?? AttemptToGetMemberInfoFromMemberExpression(expression);

         var propertyInfo = memberInfo as PropertyInfo;

         if (propertyInfo == null)
         {
            throw new ArgumentException("Cannot use <" + expression.Body + "> when a property expression is expected.");
         }

         return propertyInfo;
      }

      /// <summary>
      ///    Gets the name of the method being called from an action.
      /// </summary>
      /// <param name="action">The action to evaluate.</param>
      /// <returns>The name of the method.</returns>
      internal static string GetMethodName(Expression<Action> action)
      {
         return ((MethodCallExpression)action.Body).Method.Name;
      }

      /// <summary>
      ///    Attempts to get member information from cast expression.
      /// </summary>
      /// <typeparam name="T">The type of the declaring type.</typeparam>
      /// <typeparam name="TValue">The resulting type of the member expression.</typeparam>
      /// <param name="expression">The expression to evaluate.</param>
      /// <returns>A <see cref="MemberInfo" /> instance.</returns>
      private static MemberInfo AttemptToGetMemberInfoFromCastExpression<T, TValue>(Expression<Func<T, TValue>> expression)
      {
         var castExpression = expression.Body as UnaryExpression;
         return ((MemberExpression)castExpression?.Operand)?.Member;
      }

      /// <summary>
      ///    Attempts to get member information from member expression.
      /// </summary>
      /// <typeparam name="T">The type of the declaring type.</typeparam>
      /// <typeparam name="TValue">The resulting type of the member expression.</typeparam>
      /// <param name="expression">The expression to evaluate.</param>
      /// <returns>A <see cref="MemberInfo" /> instance.</returns>
      private static MemberInfo AttemptToGetMemberInfoFromMemberExpression<T, TValue>(Expression<Func<T, TValue>> expression)
      {
         var memberExpression = expression.Body as MemberExpression;
         return memberExpression?.Member;
      }
   }
}