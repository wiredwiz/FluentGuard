#region Apache License 2.0

// <copyright company="Edgerunner.org" file="ClassValidator.cs">
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
using Org.Edgerunner.FluentGuard.Properties;

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   ///    A Validator class for classes.
   /// </summary>
   /// <typeparam name="T">A type of class.</typeparam>
   /// <seealso cref="Org.Edgerunner.FluentGuard.Validation.Validator{T}" />
   [FullCovered]
   public class ClassValidator<T> : Validator<T>
      where T : class
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="ClassValidator{T}" /> class.
      /// </summary>
      /// <param name="parameterName">
      ///    The name of the parameter being validated.
      /// </param>
      /// <param name="parameterValue">
      ///    The value of the parameter being validated.
      /// </param>
      public ClassValidator(string parameterName, T parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      #endregion

      /// <summary>
      /// Determines whether the parameter being validated implements a specified interface.
      /// </summary>
      /// <param name="type">The type to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<ClassValidator<T>> ImplementsInterface(Type type)
      {
         if (ShouldReturnAfterEvaluation(PerformImplementsInterfaceOperation(ParameterValue, type)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(string.Format(Resources.MustImplementInterface, type.Name), ParameterName);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated inherits from a specified type.
      /// </summary>
      /// <param name="type">The type to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<ClassValidator<T>> InheritsType(Type type)
      {
         if (ShouldReturnAfterEvaluation(PerformInheritsOperation(ParameterValue, type)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(string.Format(Resources.MustInheritType, type.Name), ParameterName);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<ClassValidator<T>> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<ClassValidator<T>> IsNull()
      {
         if (ShouldReturnAfterEvaluation(!PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustBeNull);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is of a specified type.
      /// </summary>
      /// <param name="type">The type to compare against.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<ClassValidator<T>> IsOfType(Type type)
      {
         if (ShouldReturnAfterEvaluation(PerformIsOfTypeOperation(ParameterValue, type)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(string.Format(Resources.MustBeOfType, type.Name), ParameterName);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is the same instance as the one being compared against.
      /// </summary>
      /// <param name="instance">The instance to compare to.</param>
      /// <returns>A new <see cref="T:Org.Edgerunner.FluentGuard.Validation.ValidatorLinkage`2" /> instance.</returns>
      public ValidatorLinkage<ClassValidator<T>> IsSameAs(T instance)
      {
         if (ShouldReturnAfterEvaluation(PerformSameAsOperation(ParameterValue, instance)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeSameAs, ParameterName);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      ///    Performs the ImplementsInterface operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="type">The interface to compare against.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> implements <paramref name="type" />, <c>false</c> otherwise.</returns>
      /// <exception cref="ArgumentException"><paramref name="type" /> must be an interface.</exception>
      /// <exception cref="ArgumentNullException">Thrown when arguments are <see langword="null"/></exception>
      protected virtual bool PerformImplementsInterfaceOperation(T currentValue, Type type)
      {
         if (currentValue == null)
            throw new ArgumentNullException(ParameterName, Resources.MustNotBeNull);
         if (type == null)
            throw new ArgumentNullException(nameof(type));

         if (!type.IsInterface)
            throw new ArgumentException(Resources.MustBeInterface, nameof(type));

         return type.IsInstanceOfType(currentValue);
      }

      /// <summary>
      ///    Performs the Inherits operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="type">The type to compare against.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> inherits type <paramref name="type" />, <c>false</c>
      ///    otherwise.
      /// </returns>
      /// <exception cref="ArgumentNullException">Thrown when the arguments are <see langword="null"/></exception>
      protected virtual bool PerformInheritsOperation(T currentValue, Type type)
      {
         if (currentValue == null)
            throw new ArgumentNullException(ParameterName, Resources.MustNotBeNull);
         if (type == null)
            throw new ArgumentNullException(nameof(type));

         return currentValue.GetType().IsSubclassOf(type);
      }

      /// <summary>
      ///    Performs the IsOfType operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="type">The type to compare against.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is of type <paramref name="type" />, <c>false</c> otherwise.</returns>
      /// <exception cref="ArgumentNullException">Thrown when the arguments are <see langword="null"/></exception>
      protected virtual bool PerformIsOfTypeOperation(T currentValue, Type type)
      {
         if (currentValue == null)
            throw new ArgumentNullException(ParameterName, Resources.MustNotBeNull);
         if (type == null)
            throw new ArgumentNullException(nameof(type));
         return currentValue.GetType() == type;
      }

      /// <summary>
      ///    Performs the not null operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not <c>null</c>, <c>false</c> otherwise.</returns>
      protected virtual bool PerformNotNullOperation(T currentValue)
      {
         return currentValue != null;
      }

      /// <summary>
      /// Performs the Same As operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is the same as <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
      protected virtual bool PerformSameAsOperation(T currentValue, T referenceValue)
      {
         return ReferenceEquals(currentValue, referenceValue);
      }
   }
}