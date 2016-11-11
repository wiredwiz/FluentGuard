#region Apache License 2.0
// <copyright file="ExpressionExtensions.cs" company="Edgerunner.org">
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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

//using FluentAssertions.Equivalency;

namespace Org.Edgerunner.FluentGuard
{
   public static class ExpressionExtensions
   {
      //public static SelectedMemberInfo GetSelectedMemberInfo<T, TValue>(this Expression<Func<T, TValue>> expression)
      //{
      //    if (ReferenceEquals(expression, null))
      //    {
      //        throw new NullReferenceException("Expected an expression, but found <null>.");
      //    }

      //    MemberInfo memberInfo = AttemptToGetMemberInfoFromCastExpression(expression) ??
      //                            AttemptToGetMemberInfoFromMemberExpression(expression);

      //    if (memberInfo != null)
      //    {
      //        var propertyInfo = memberInfo as PropertyInfo;
      //        if (propertyInfo != null)
      //        {
      //            return SelectedMemberInfo.Create(propertyInfo);
      //        }

      //        var fieldInfo = memberInfo as FieldInfo;
      //        if (fieldInfo != null)
      //        {
      //            return SelectedMemberInfo.Create(fieldInfo);
      //        }
      //    }

      //    throw new ArgumentException(
      //        string.Format("Expression <{0}> cannot be used to select a member.", expression.Body));
      //}

      //public static PropertyInfo GetPropertyInfo<T, TValue>(this Expression<Func<T, TValue>> expression)
      //{
      //    if (ReferenceEquals(expression, null))
      //    {
      //        throw new NullReferenceException("Expected a property expression, but found <null>.");
      //    }

      //    var memberInfo = AttemptToGetMemberInfoFromCastExpression(expression) ??
      //                     AttemptToGetMemberInfoFromMemberExpression(expression);

      //    var propertyInfo = memberInfo as PropertyInfo;

      //    if (propertyInfo == null)
      //    {
      //        throw new ArgumentException("Cannot use <" + expression.Body + "> when a property expression is expected.");
      //    }

      //    return propertyInfo;
      //}

      //private static MemberInfo AttemptToGetMemberInfoFromMemberExpression<T, TValue>(
      //    Expression<Func<T, TValue>> expression)
      //{
      //    var memberExpression = expression.Body as MemberExpression;
      //    if (memberExpression != null)
      //    {
      //        return memberExpression.Member;
      //    }

      //    return null;
      //}

      //private static MemberInfo AttemptToGetMemberInfoFromCastExpression<T, TValue>(Expression<Func<T, TValue>> expression)
      //{
      //    var castExpression = expression.Body as UnaryExpression;
      //    if (castExpression != null)
      //    {
      //        return ((MemberExpression)castExpression.Operand).Member;
      //    }

      //    return null;
      //}

      /// <summary>
      /// Gets a dotted path of property names representing the property expression. E.g. Parent.Child.Sibling.Name.
      /// </summary>
      public static string GetMemberPath<T>(
          this Expression<Func<T>> expression)
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

               case ExpressionType.Constant:
               case ExpressionType.Parameter:
                  node = null;
                  break;

               default:
                  throw new ArgumentException(
                      string.Format("Expression <{0}> cannot be used to select a member.", expression.Body));
            }
         }

         return string.Join(".", segments.AsEnumerable().Reverse().ToArray()).Replace(".[", "[");
      }

      internal static string GetMethodName(Expression<Action> action)
      {
         return ((MethodCallExpression)action.Body).Method.Name;
      }
   }
}