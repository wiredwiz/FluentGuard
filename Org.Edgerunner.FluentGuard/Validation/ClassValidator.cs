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
using System.Diagnostics.CodeAnalysis;
using NDepend.Attributes;
using Org.Edgerunner.FluentGuard.Exceptions;
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.NDepend.Attributes;

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   ///    A ValidatorBase class for classes.
   /// </summary>
   /// <typeparam name="T">A type of class.</typeparam>
   /// <seealso cref="ValidatorBase{T}" />
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if DEBUG
   [FullCovered]
#endif
   public class ClassValidator<T> : ValidatorBase<T>
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
      /// <returns>A new <see cref="ValidatorLinkage{ClassValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentNullException">Thrown when arguments are <see langword="null"/></exception>
      /// <exception cref="ArgumentTypeException">Must implement interface <paramref name="type"/>.</exception>
      public ValidatorLinkage<ClassValidator<T>> ImplementsInterface(Type type)
      {
         if (ShouldReturnAfterEvaluation(PerformImplementsInterfaceOperation(ParameterValue, type)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentTypeException(string.Format(Resources.MustImplementInterface, type.Name), ParameterName);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated inherits from a specified type.
      /// </summary>
      /// <param name="type">The type to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{ClassValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentNullException">Thrown when the arguments are <see langword="null"/></exception>
      /// <exception cref="ArgumentTypeException">Must inherit from <paramref name="type"/>.</exception>
      public ValidatorLinkage<ClassValidator<T>> InheritsType(Type type)
      {
         if (ShouldReturnAfterEvaluation(PerformInheritsOperation(ParameterValue, type)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentTypeException(string.Format(Resources.MustInheritType, type.Name), ParameterName);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{ClassValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
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
      /// <returns>A new <see cref="ValidatorLinkage{ClassValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentException">Parameter must be <c>null</c>.</exception>
      public ValidatorLinkage<ClassValidator<T>> IsNull()
      {
         if (ShouldReturnAfterEvaluation(!PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeNull, ParameterName);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is of a specified type.
      /// </summary>
      /// <param name="type">The type to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{ClassValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentTypeException">Must be of type <paramref name="type"/>.</exception>
      /// <exception cref="ArgumentNullException">Thrown when the arguments are <see langword="null"/></exception>
      public ValidatorLinkage<ClassValidator<T>> IsOfType(Type type)
      {
         if (ShouldReturnAfterEvaluation(PerformIsOfTypeOperation(ParameterValue, type)))
            return new ValidatorLinkage<ClassValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentTypeException(string.Format(Resources.MustBeOfType, type.Name), ParameterName);

         return new ValidatorLinkage<ClassValidator<T>>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is the same instance as the one being compared against.
      /// </summary>
      /// <param name="instance">The instance to compare to.</param>
      /// <returns>A new <see cref="ValidatorLinkage{ClassValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentException">Must be the same instance as <paramref name="instance"/>.</exception>
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
      /// <exception cref="ArgumentTypeException"><paramref name="currentValue" /> must implement interface <paramref name="type"/>.</exception>
      /// <exception cref="ArgumentNullException">Thrown when arguments are <see langword="null"/></exception>
#if DEBUG
      [IgnoreBoxing]
#endif
      protected virtual bool PerformImplementsInterfaceOperation(T currentValue, Type type)
      {
         if (currentValue == null)
            throw new ArgumentNullException(ParameterName, Resources.MustNotBeNull);
         if (type == null)
            throw new ArgumentNullException(nameof(type));

         if (!type.IsInterface)
            throw new ArgumentTypeException(Resources.MustBeInterface, nameof(type));

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
#if DEBUG
      [IgnoreBoxing]
#endif
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
#if DEBUG
      [IgnoreBoxing]
#endif
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
#if DEBUG
      [IgnoreBoxing]
#endif
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
#if DEBUG
      [IgnoreBoxing]
#endif
      protected virtual bool PerformSameAsOperation(T currentValue, T referenceValue)
      {
         return ReferenceEquals(currentValue, referenceValue);
      }
   }
}