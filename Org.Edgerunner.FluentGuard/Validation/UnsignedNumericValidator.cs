#region Apache License 2.0

// <copyright company="Edgerunner.org" file="UnsignedNumericValidator.cs">
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
   /// Class UnsignedNumericValidator.
   /// </summary>
   /// <typeparam name="T">An unsigned numeric data type.</typeparam>
   /// <seealso cref="ValidatorBase{T}" />
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if NDEPEND
   [FullCovered]
#endif   
   public class UnsignedNumericValidator<T> : ValidatorBase<T> where T : struct
   {
      /// <summary>
      /// The static object pool instance to use with static pooling methods.
      /// </summary>
      private static readonly ObjectPool<UnsignedNumericValidator<T>> PoolInstance = CreatePool();

      /// <summary>
      /// Gets the object pool that this instance is pooled in.
      /// </summary>
      /// <value>The object pool.</value>
      private ObjectPool<UnsignedNumericValidator<T>> Pool { get; }

      #region Constructors And Finalizers

      /// <summary>
      /// Initializes a new instance of the <see cref="UnsignedNumericValidator{T}"/> class. 
      /// </summary>
      /// <param name="parameterName">
      /// The name of the parameter being validated.
      /// </param>
      /// <param name="parameterValue">
      /// The value of the parameter being validated.
      /// </param>
      public UnsignedNumericValidator(string parameterName, T parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="UnsignedNumericValidator{T}" /> class.
      /// </summary>
      /// <param name="pool">The object pool to use.</param>
      internal UnsignedNumericValidator(ObjectPool<UnsignedNumericValidator<T>> pool)
      {
         Pool = pool;
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="UnsignedNumericValidator{T}" /> class.
      /// </summary>
      internal UnsignedNumericValidator()
      {
      }

      #endregion

      #region Static

      /// <summary>
      /// Creates the object pool.
      /// </summary>
      /// <returns>The object pool.</returns>
      private static ObjectPool<UnsignedNumericValidator<T>> CreatePool()
      {
         ObjectPool<UnsignedNumericValidator<T>> pool = null;
         // ReSharper disable once AccessToModifiedClosure
         pool = new ObjectPool<UnsignedNumericValidator<T>>(() => new UnsignedNumericValidator<T>(pool), 20);
         return pool;
      }

      /// <summary>
      /// Gets a new <see cref="UnsignedNumericValidator{T}" /> instance.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      /// <returns>a <see cref="BooleanValidator" /> instance.</returns>
      /// <exception cref="OutOfMemoryException">There is not enough memory available on the system.</exception>
      public static UnsignedNumericValidator<T> GetInstance(string parameterName, T parameterValue)
      {
         if (!Validate.UsingObjectPooling)
            return new UnsignedNumericValidator<T>(parameterName, parameterValue);

         var instance = PoolInstance.Allocate();
         instance.ParameterName = parameterName;
         instance.ParameterValue = default(T);
         return instance;
      }

      #endregion

      /// <summary>
      ///    Determines whether the parameter being validated is equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{UnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentEqualityException">Must be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{UnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsGreaterThan(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeGreaterThanX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is greater than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{UnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be greater than or equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsGreaterThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformGreaterThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(
               ParameterName,
               string.Format(Resources.MustBeGreaterThanOrEqualToX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{UnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be less than <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsLessThan(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, string.Format(Resources.MustBeLessThanX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is less than or equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{UnsignedNumericValidator}" /> instance of type T.</returns>      
      /// <exception cref="ArgumentOutOfRangeException">Must be less than or equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsLessThanOrEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(PerformLessThanOrEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(
               ParameterName,
               string.Format(Resources.MustBeLessThanOrEqualToX, value));

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not equal to the specified value.
      /// </summary>
      /// <param name="value">The value to compare against.</param>
      /// <returns>A new <see cref="ValidatorLinkage{UnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentEqualityException">Must not be equal to <paramref name="value"/>.</exception>
#if NDEPEND
      [IgnoreBoxing]
#endif
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsNotEqualTo(T value)
      {
         if (ShouldReturnAfterEvaluation(!PerformEqualToOperation(ParameterValue, value)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentEqualityException(string.Format(Resources.MustNotBeEqualToX, value), ParameterName);

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not positive.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{UnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentException">Must not be positive.</exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsNotPositive()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsPositiveOperation(ParameterValue)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustNotBePositive);

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is positive.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{UnsignedNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentException">Must be positive.</exception>
      public ValidatorLinkage<UnsignedNumericValidator<T>> IsPositive()
      {
         if (ShouldReturnAfterEvaluation(PerformIsPositiveOperation(ParameterValue)))
            return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustBePositive);

         return new ValidatorLinkage<UnsignedNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Performs the IsPositive operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is positive, <c>false</c> otherwise.</returns>
#if NDEPEND
      [IgnoreBoxing]
#endif
      protected virtual bool PerformIsPositiveOperation(T currentValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         // ReSharper disable once PossibleNullReferenceException
         return original.CompareTo(default(T)) > 0;
      }

      /// <summary>
      /// Frees this instance from the pool and thus allows it to be garbage collected.
      /// </summary>
      internal override void Free()
      {
         Mode = CombinationMode.And;
         CurrentException = null;
         ParameterName = string.Empty;
         ParameterValue = default(T);
         Pool?.Free(this);
      }
   }
}