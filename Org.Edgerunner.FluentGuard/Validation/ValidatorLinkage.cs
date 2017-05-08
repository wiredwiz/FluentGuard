#region Apache License 2.0

// <copyright company="Edgerunner.org" file="ValidatorLinkage.cs">
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
using NDepend.Attributes;

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   ///    Structure used to join validators.
   /// </summary>
   /// <typeparam name="T">A type of Validator.</typeparam>
   [FullCovered]
   public struct ValidatorLinkage<T>
      where T : Validator
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="ValidatorLinkage{T}" /> structure.
      /// </summary>
      /// <param name="parent">A <see cref="Validator" /> instance.</param>
      public ValidatorLinkage(T parent)
      {
         Parent = parent;
      }

      #endregion

      /// <summary>
      ///    Gets the <see cref="Validator" /> being joined by an And constraint.
      /// </summary>
      /// <value>The validator.</value>
      public T And
      {
         get
         {
            Parent.Mode = CombinationMode.And;
            return Parent;
         }
      }

      /// <summary>
      ///    Gets the <see cref="Validator" /> being joined by an Or constraint.
      /// </summary>
      /// <value>The validator.</value>
      public T Or
      {
         get
         {
            Parent.Mode = CombinationMode.Or;
            return Parent;
         }
      }

      /// <summary>
      ///    Gets or sets the parent.
      /// </summary>
      /// <value>The parent.</value>
      private T Parent { get; set; }

      /// <summary>
      ///    Throws a new exception.
      /// </summary>
      /// <typeparam name="TE">The type of exception.</typeparam>
      /// <param name="exception">The exception to throw.</param>
      public void OtherwiseThrow<TE>(TE exception) where TE : Exception, new()
      {
         // ReSharper disable once ExceptionNotDocumented
         // ReSharper disable once ThrowingSystemException
         if (Parent.CurrentException != null)
            throw exception;
      }

      /// <summary>
      ///    Throws a new exception.
      /// </summary>
      public void OtherwiseThrowException()
      {
         // ReSharper disable once ExceptionNotDocumented
         // ReSharper disable once ThrowingSystemException
         if (Parent.CurrentException != null)
            throw Parent.CurrentException;
      }
   }
}