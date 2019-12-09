#region Apache License 2.0

// <copyright company="Edgerunner.org" file="DateTimeValidator.cs">
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
   ///    A ValidatorBase class for type <see cref="DateTime" />.
   /// </summary>
   /// <seealso cref="DateTime" />
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if NDEPEND
   [FullCovered]
#endif
   public class DateTimeValidator : ValidatorBase<DateTime>
   {
      /// <summary>
      /// The static object pool instance to use with static pooling methods.
      /// </summary>
      private static readonly ObjectPool<DateTimeValidator> PoolInstance = CreatePool();

      /// <summary>
      /// Gets the object pool that this instance is pooled in.
      /// </summary>
      /// <value>The object pool.</value>
      private ObjectPool<DateTimeValidator> Pool { get; }

      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="DateTimeValidator" /> class.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      internal DateTimeValidator(string parameterName, DateTime parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="DateTimeValidator" /> class.
      /// </summary>
      /// <param name="pool">The object pool to use.</param>
      internal DateTimeValidator(ObjectPool<DateTimeValidator> pool)
      {
         Pool = pool;
      }

      #endregion

      #region Static

      /// <summary>
      /// Creates the object pool.
      /// </summary>
      /// <returns>The object pool.</returns>
      private static ObjectPool<DateTimeValidator> CreatePool()
      {
         ObjectPool<DateTimeValidator> pool = null;
         // ReSharper disable once AccessToModifiedClosure
         pool = new ObjectPool<DateTimeValidator>(() => new DateTimeValidator(pool), 20);
         return pool;
      }

      /// <summary>
      /// Gets a new <see cref="DateTimeValidator" /> instance.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      /// <returns>a <see cref="DateTimeValidator" /> instance.</returns>
      public static DateTimeValidator GetInstance(string parameterName, DateTime parameterValue)
      {
         if (!Validate.UsingObjectPooling)
            return new DateTimeValidator(parameterName, parameterValue);

         var instance = PoolInstance.Allocate();
         instance.ParameterName = parameterName;
         instance.ParameterValue = parameterValue;
         return instance;
      }

      #endregion

      /// <summary>
      ///    Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns>
      ///    <c>true</c> if <paramref name="currentValue" /> is greater than or equal to <paramref name="referenceValue" />
      ///    , <c>false</c> otherwise.
      /// </returns>
      protected override bool PerformEqualToOperation(DateTime currentValue, DateTime referenceValue)
      {
         return currentValue.Equals(referenceValue);
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
      protected override bool PerformGreaterThanOperation(DateTime currentValue, DateTime referenceValue)
      {
         return currentValue > referenceValue;
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
      protected override bool PerformGreaterThanOrEqualToOperation(DateTime currentValue, DateTime referenceValue)
      {
         return currentValue >= referenceValue;
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
      protected override bool PerformLessThanOperation(DateTime currentValue, DateTime referenceValue)
      {
         return currentValue < referenceValue;
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
      protected override bool PerformLessThanOrEqualToOperation(DateTime currentValue, DateTime referenceValue)
      {
         return currentValue <= referenceValue;
      }

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{DateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<DateTimeValidator> IsEqualTo(DateTime value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<DateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<DateTimeValidator>(this);
      }

      /// <summary>
      /// Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{DateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<DateTimeValidator> IsGreaterThan(DateTime value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<DateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanX, value));

         return new ValidatorLinkage<DateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{DateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than or equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<DateTimeValidator> IsGreaterThanOrEqualTo(DateTime value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<DateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanOrEqualToX, value));

         return new ValidatorLinkage<DateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{DateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<DateTimeValidator> IsLessThan(DateTime value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<DateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanX, value));

         return new ValidatorLinkage<DateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{DateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than or equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<DateTimeValidator> IsLessThanOrEqualTo(DateTime value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<DateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanOrEqualToX, value));

         return new ValidatorLinkage<DateTimeValidator>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{DateTimeValidator}" /> instance.</returns>
      /// <exception cref="ArgumentEqualityException">Must not be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<DateTimeValidator> IsNotEqualTo(DateTime value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<DateTimeValidator>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustNotBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<DateTimeValidator>(this);
      }

      /// <summary>
      /// Frees this instance from the pool and thus allows it to be garbage collected.
      /// </summary>
      internal override void Free()
      {
         Mode = CombinationMode.And;
         CurrentException = null;
         ParameterName = string.Empty;
         ParameterValue = DateTime.MinValue;
         Pool?.Free(this);
      }
   }
}