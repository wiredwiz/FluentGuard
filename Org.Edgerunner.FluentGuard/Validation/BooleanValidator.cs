#region Apache License 2.0

// <copyright company="Edgerunner.org" file="BooleanValidator.cs">
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
   ///    A ValidatorBase class for type <see cref="bool" />.
   /// </summary>
   /// <seealso cref="bool" />
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if NDEPEND
   [FullCovered]
#endif
   public class BooleanValidator : ValidatorBase<bool>
   {
      /// <summary>
      /// The static object pool instance to use with static pooling methods.
      /// </summary>
      private static readonly ObjectPool<BooleanValidator> PoolInstance = CreatePool();

      /// <summary>
      /// Gets the object pool that this instance is pooled in.
      /// </summary>
      /// <value>The object pool.</value>
      private ObjectPool<BooleanValidator> Pool { get; }

      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="BooleanValidator" /> class.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">if set to <c>true</c> [parameter value].</param>
      internal BooleanValidator(string parameterName, bool parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="BooleanValidator" /> class.
      /// </summary>
      /// <param name="pool">The object pool to use.</param>
      internal BooleanValidator(ObjectPool<BooleanValidator> pool)
      {
         Pool = pool;
      }

      #endregion

      #region Static

      /// <summary>
      /// Creates the object pool.
      /// </summary>
      /// <returns>The object pool.</returns>
      private static ObjectPool<BooleanValidator> CreatePool()
      {
         ObjectPool<BooleanValidator> pool = null;
         // ReSharper disable once AccessToModifiedClosure
         pool = new ObjectPool<BooleanValidator>(() => new BooleanValidator(pool), 20);
         return pool;
      }

      /// <summary>
      /// Gets a new <see cref="BooleanValidator" /> instance.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      /// <returns>a <see cref="BooleanValidator" /> instance.</returns>
      public static BooleanValidator GetInstance(string parameterName, bool parameterValue)
      {
         if (!Validate.UsingObjectPooling)
            return new BooleanValidator(parameterName, parameterValue);

         var instance = PoolInstance.Allocate();
         instance.ParameterName = parameterName;
         instance.ParameterValue = parameterValue;
         return instance;
      }

      #endregion

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{BooleanValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<BooleanValidator> IsEqualTo(bool value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<BooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<BooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>false</c>.
      /// </summary>
      /// <returns>The current <see cref="ValidatorLinkage{BooleanValidator}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>false</c>.</exception>
      public ValidatorLinkage<BooleanValidator> IsFalse()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsTrueOperation(ParameterValue)))
            return new ValidatorLinkage<BooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeFalse, ParameterName);

         return new ValidatorLinkage<BooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>The current <see cref="ValidatorLinkage{BooleanValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must not be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<BooleanValidator> IsNotEqualTo(bool value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<BooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustNotBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<BooleanValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>true</c>.
      /// </summary>
      /// <returns>The current <see cref="ValidatorLinkage{BooleanValidator}" /> instance.</returns>
      /// <exception cref="System.ArgumentException">Must be <c>true</c>.</exception>
      public ValidatorLinkage<BooleanValidator> IsTrue()
      {
         if (ShouldReturnAfterEvaluation(PerformIsTrueOperation(ParameterValue)))
            return new ValidatorLinkage<BooleanValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentException(Resources.MustBeTrue, ParameterName);

         return new ValidatorLinkage<BooleanValidator>(this);
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is greater than or equal to <paramref name="referenceValue" />
      ///    , <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformEqualToOperation(bool currentValue, bool referenceValue)
      {
         return currentValue == referenceValue;
      }

      /// <summary>
      ///    Performs the IsTrue operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is true, <c>false</c> otherwise.</returns>
      protected virtual bool PerformIsTrueOperation(bool currentValue)
      {
         return currentValue;
      }

      /// <summary>
      /// Frees this instance from the pool and thus allows it to be garbage collected.
      /// </summary>
      internal override void Free()
      {
         Mode = CombinationMode.And;
         CurrentException = null;
         ParameterName = string.Empty;
         ParameterValue = false;
         Pool?.Free(this);
      }
   }
}