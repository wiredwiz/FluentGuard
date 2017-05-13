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
using System.Collections.Generic;
using Org.Edgerunner.FluentGuard.Attributes;

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   ///    Structure used to join validators.
   /// </summary>
   /// <typeparam name="T">A type of Validator.</typeparam>
   [FullCovered]
   [Immutable]
   public struct ValidatorLinkage<T> : IEquatable<ValidatorLinkage<T>>
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
      ///    Gets the parent.
      /// </summary>
      /// <value>The parent.</value>
      private T Parent { get; }

      #region Operators

      /// <summary>
      /// Implements the == operator.
      /// </summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator ==(ValidatorLinkage<T> left, ValidatorLinkage<T> right)
      {
         return left.Equals(right);
      }

      /// <summary>
      /// Implements the != operator.
      /// </summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator !=(ValidatorLinkage<T> left, ValidatorLinkage<T> right)
      {
         return !left.Equals(right);
      }

      #endregion

      #region Core Methods

      /// <summary>Indicates whether this instance and a specified object are equal.</summary>
      /// <returns>
      ///    true if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise,
      ///    false.
      /// </returns>
      /// <param name="obj">The object to compare with the current instance. </param>
      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         return obj is ValidatorLinkage<T> && Equals((ValidatorLinkage<T>)obj);
      }

      /// <summary>Returns the hash code for this instance.</summary>
      /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
      public override int GetHashCode()
      {
         return EqualityComparer<T>.Default.GetHashCode(Parent);
      }

      #endregion

      #region IEquatable<ValidatorLinkage<T>> Members

      /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
      /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
      /// <param name="other">An object to compare with this object.</param>
      public bool Equals(ValidatorLinkage<T> other)
      {
         return EqualityComparer<T>.Default.Equals(Parent, other.Parent);
      }

      #endregion

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