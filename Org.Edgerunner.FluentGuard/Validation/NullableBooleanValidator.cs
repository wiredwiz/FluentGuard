#region Apache License 2.0
// <copyright company="Edgerunner.org" file="NullableBooleanValidator.cs">
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
using System.Diagnostics.CodeAnalysis;

using Org.Edgerunner.FluentGuard.Exceptions;
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.Pooling;

#if NDEPEND
using NDepend.Attributes;
using Org.Edgerunner.NDepend.Attributes;
#endif

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   /// A ValidatorBase class for type <see cref="Nullable{T}" /> where T is <see cref="bool" />.
   /// </summary>
   /// <seealso cref="bool" />
   /// <seealso cref="Nullable"/>
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if NDEPEND
   [FullCovered]
#endif
   public class NullableBooleanValidator : NullableValidatorBase<bool>
   {
      /// <summary>
      /// The static object pool instance to use with static pooling methods.
      /// </summary>
      private static readonly ObjectPool<NullableBooleanValidator> PoolInstance = CreatePool();

      /// <summary>
      /// Gets the object pool that this instance is pooled in.
      /// </summary>
      /// <value>The object pool.</value>
      private ObjectPool<NullableBooleanValidator> Pool { get; }

      #region Constructors And Finalizers

      /// <summary>
      /// Initializes a new instance of the <see cref="NullableBooleanValidator"/> class.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">if set to <c>true</c> [parameter value].</param>
      internal NullableBooleanValidator(string parameterName, bool? parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="NullableBooleanValidator" /> class.
      /// </summary>
      /// <param name="pool">The object pool to use.</param>
      internal NullableBooleanValidator(ObjectPool<NullableBooleanValidator> pool)
      {
         Pool = pool;
      }

      #endregion

      #region Static

      /// <summary>
      /// Creates the object pool.
      /// </summary>
      /// <returns>The object pool.</returns>
      private static ObjectPool<NullableBooleanValidator> CreatePool()
      {
         ObjectPool<NullableBooleanValidator> pool = null;
         // ReSharper disable once AccessToModifiedClosure
         pool = new ObjectPool<NullableBooleanValidator>(() => new NullableBooleanValidator(pool), 20);
         return pool;
      }

      /// <summary>
      /// Gets a new <see cref="NullableBooleanValidator" /> instance.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      /// <returns>a <see cref="NullableBooleanValidator" /> instance.</returns>
      /// <exception cref="OutOfMemoryException">There is not enough memory available on the system.</exception>
      public static NullableBooleanValidator GetInstance(string parameterName, bool? parameterValue)
      {
         if (!Validate.UsingObjectPooling)
            return new NullableBooleanValidator(parameterName, parameterValue);

         var instance = PoolInstance.Allocate();
         instance.ParameterName = parameterName;
         instance.ParameterValue = parameterValue;
         return instance;
      }

      #endregion

      /// <summary>
      /// Performs the IsTrue operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is true, <c>false</c> otherwise.</returns>
      protected virtual bool PerformIsTrueOperation(bool? currentValue)
      {
         return currentValue.HasValue && currentValue.Value;
      }

      /// <summary>
      /// Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableBooleanValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableBooleanValidator> IsEqualTo(bool? value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="ValidatorLinkage{NullableBooleanValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must not be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableBooleanValidator> IsNotEqualTo(bool? value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustNotBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is <c>false</c>.
      /// </summary>
      /// <returns>The current <see cref="ValidatorLinkage{NullableBooleanValidator}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>false</c>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsFalse()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsTrueOperation(ParameterValue)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeFalse, ParameterName);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is <c>true</c>.
      /// </summary>
      /// <returns>The current <see cref="ValidatorLinkage{NullableBooleanValidator}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>true</c>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsTrue()
      {
         if (ShouldReturnAfterEvaluation(PerformIsTrueOperation(ParameterValue)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeTrue, ParameterName);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must be <c>null</c>.</exception>
      public ValidatorLinkage<NullableBooleanValidator> IsNull()
      {
         if (ShouldReturnAfterEvaluation(!PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableBooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustBeNull);

         return new ValidatorLinkage<NullableBooleanValidator>(this);
      }

      /// <summary>
      /// Frees this instance from the pool and thus allows it to be garbage collected.
      /// </summary>
      internal override void Free()
      {
         Mode = CombinationMode.And;
         CurrentException = null;
         ParameterName = string.Empty;
         ParameterValue = null;
         Pool?.Free(this);
      }
   }
}