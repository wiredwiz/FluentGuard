#region Apache License 2.0

// <copyright company="Edgerunner.org" file="NullableDateTimeValidator.cs">
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
   /// Class for validating nullable DateTime values.
   /// </summary>
   /// <seealso cref="DateTime" />
   /// <seealso cref="Nullable"/>
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if NDEPEND
   [FullCovered]
#endif
   public class NullableDateTimeValidator : NullableValidatorBase<DateTime>
   {
      /// <summary>
      /// The static object pool instance to use with static pooling methods.
      /// </summary>
      private static readonly ObjectPool<NullableDateTimeValidator> PoolInstance = CreatePool();

      /// <summary>
      /// Gets the object pool that this instance is pooled in.
      /// </summary>
      /// <value>The object pool.</value>
      private ObjectPool<NullableDateTimeValidator> Pool { get; }

      #region Constructors And Finalizers

      /// <summary>
      /// Initializes a new instance of the <see cref="NullableDateTimeValidator"/> class. 
      /// </summary>
      /// <param name="parameterName">
      /// The name of the parameter being validated.
      /// </param>
      /// <param name="parameterValue">
      /// The value of the parameter being validated.
      /// </param>
      public NullableDateTimeValidator(string parameterName, DateTime? parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="NullableDateTimeValidator" /> class.
      /// </summary>
      /// <param name="pool">The object pool to use.</param>
      internal NullableDateTimeValidator(ObjectPool<NullableDateTimeValidator> pool)
      {
         Pool = pool;
      }

      #endregion

      #region Static

      /// <summary>
      /// Creates the object pool.
      /// </summary>
      /// <returns>The object pool.</returns>
      private static ObjectPool<NullableDateTimeValidator> CreatePool()
      {
         ObjectPool<NullableDateTimeValidator> pool = null;
         // ReSharper disable once AccessToModifiedClosure
         pool = new ObjectPool<NullableDateTimeValidator>(() => new NullableDateTimeValidator(pool), 20);
         return pool;
      }

      /// <summary>
      /// Gets a new <see cref="NullableDateTimeValidator" /> instance.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      /// <returns>a <see cref="NullableDateTimeValidator" /> instance.</returns>
      public static NullableDateTimeValidator GetInstance(string parameterName, DateTime? parameterValue)
      {
         if (!Validate.UsingObjectPooling)
            return new NullableDateTimeValidator(parameterName, parameterValue);

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
      /// <returns>A new <see cref="ValidatorLinkage{NullableDateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableDateTimeValidator> IsEqualTo(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableDateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableDateTimeValidator> IsGreaterThan(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableDateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than or equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableDateTimeValidator> IsGreaterThanOrEqualTo(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(
               ParameterName,
               string.Format(Resources.MustBeGreaterThanOrEqualToX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableDateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableDateTimeValidator> IsLessThan(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableDateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than or equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableDateTimeValidator> IsLessThanOrEqualTo(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(
               ParameterName,
               string.Format(Resources.MustBeLessThanOrEqualToX, value));

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{NullableDateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must not be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<NullableDateTimeValidator> IsNotEqualTo(DateTime? value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustNotBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentNullException">Must not be <c>null</c>.</exception>
      public ValidatorLinkage<NullableDateTimeValidator> IsNotNull()
      {
         if (ShouldReturnAfterEvaluation(PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustNotBeNull);

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is <c>null</c>.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{StringValidator}" /> instance.</returns>
      /// <exception cref="ArgumentException">Must be <c>null</c>.</exception>
      public ValidatorLinkage<NullableDateTimeValidator> IsNull()
      {
         if (ShouldReturnAfterEvaluation(!PerformNotNullOperation(ParameterValue)))
            return new ValidatorLinkage<NullableDateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentNullException(ParameterName, Resources.MustBeNull);

         return new ValidatorLinkage<NullableDateTimeValidator>(this);
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
      protected override bool PerformEqualToOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Equals(currentValue, referenceValue);
      }

      /// <summary>
      ///    Performs the greater than operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is greater than <paramref name="referenceValue" />,
      ///    <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformGreaterThanOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Compare(currentValue, referenceValue) > 0;
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
      protected override bool PerformGreaterThanOrEqualToOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Compare(currentValue, referenceValue) >= 0;
      }

      /// <summary>
      ///    Performs the less than operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is less than <paramref name="referenceValue" />, <c>false</c>
      ///    otherwise.
      /// </returns>
      protected override bool PerformLessThanOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Compare(currentValue, referenceValue) < 0;
      }

      /// <summary>
      ///    Performs the less than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is less than or equal to <paramref name="referenceValue" />,
      ///    <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformLessThanOrEqualToOperation(DateTime? currentValue, DateTime? referenceValue)
      {
         return Nullable.Compare(currentValue, referenceValue) <= 0;
      }

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is not <c>null</c>, <c>false</c> otherwise.</returns>
      protected override bool PerformNotNullOperation(DateTime? currentValue)
      {
         return currentValue.HasValue;
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