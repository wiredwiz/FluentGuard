#region Apache License 2.0
// <copyright company="Edgerunner.org" file="TypeHelper.cs">
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
using System.Linq.Expressions;
using Org.Edgerunner.FluentGuard.Properties;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   /// Class containing some internal type helper methods.
   /// </summary>
   internal class TypeHelper
   {
      /// <summary>
      ///    Gets the member expression.
      /// </summary>
      /// <typeparam name="TModel">The type of the model.</typeparam>
      /// <typeparam name="T">The member.</typeparam>
      /// <param name="expression">The expression.</param>
      /// <returns>A member expression.</returns>
      /// <exception cref="ArgumentException">Not a member access expression.</exception>
      internal static MemberExpression GetMemberExpression<TModel, T>(Expression<Func<TModel, T>> expression)
      {
         // This method was taken from CsvHelper which was taken from FluentNHibernate.Utils.ReflectionHelper.cs and modified.
         // http://joshclose.github.io/CsvHelper/
         // http://fluentnhibernate.org/
         MemberExpression memberExpression = null;
         if (expression.Body.NodeType == ExpressionType.Convert)
         {
            var body = (UnaryExpression)expression.Body;
            memberExpression = body.Operand as MemberExpression;
         }
         else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            memberExpression = expression.Body as MemberExpression;

         if (memberExpression == null)
            throw new ArgumentException(Resources.NotAMemberAccess, nameof(expression));

         return memberExpression;
      }
   }
}