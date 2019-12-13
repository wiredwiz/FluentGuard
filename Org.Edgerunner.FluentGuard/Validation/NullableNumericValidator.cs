#region Apache License 2.0

// <copyright company="Edgerunner.org" file="NullableNumericValidator.cs">
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

using Org.Edgerunner.FluentGuard.Properties;

#if NDEPEND
using NDepend.Attributes;
#endif

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   /// Class NullableNumericValidator.
   /// </summary>
   /// <typeparam name="T">A numeric <see cref="Nullable"/> type.</typeparam>
   /// <seealso cref="Org.Edgerunner.FluentGuard.Validation.NullableUnsignedNumericValidator{T}" />
   /// <seealso cref="Nullable"/>
   [SuppressMessage("ReSharper", "ExceptionNotThrown",
       Justification =
          "The exception generated in each method will eventually be thrown and detailing it in the method that generates it helps with later xml docs.")]
#if NDEPEND
   [FullCovered]
#endif
   public class NullableNumericValidator<T> : NullableUnsignedNumericValidator<T>
      where T : struct
   {
      /// <summary>
      /// The static object pool instance to use with static pooling methods.
      /// </summary>
      private static readonly Pooling.ObjectPool<NullableNumericValidator<T>> PoolInstance = CreatePool();

      /// <summary>
      /// Gets the object pool that this instance is pooled in.
      /// </summary>
      /// <value>The object pool.</value>
      private Pooling.ObjectPool<NullableNumericValidator<T>> Pool { get; }

      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="NullableNumericValidator{T}" /> class.
      /// </summary>
      /// <param name="parameterName">
      ///    The name of the parameter being validated.
      /// </param>
      /// <param name="parameterValue">
      ///    The value of the parameter being validated.
      /// </param>
      public NullableNumericValidator(string parameterName, T? parameterValue)
         : base(parameterName, parameterValue)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="NullableNumericValidator{T}" /> class.
      /// </summary>
      /// <param name="pool">The object pool to use.</param>
      internal NullableNumericValidator(Pooling.ObjectPool<NullableNumericValidator<T>> pool)
      {
         Pool = pool;
      }

      #endregion

      #region Static

      /// <summary>
      /// Creates the object pool.
      /// </summary>
      /// <returns>The object pool.</returns>
      private static Pooling.ObjectPool<NullableNumericValidator<T>> CreatePool()
      {
         Pooling.ObjectPool<NullableNumericValidator<T>> pool = null;
         // ReSharper disable once AccessToModifiedClosure
         pool = new Pooling.ObjectPool<NullableNumericValidator<T>>(() => new NullableNumericValidator<T>(pool), 20);
         return pool;
      }

      /// <summary>
      /// Gets a new <see cref="NullableNumericValidator{T}" /> instance.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      /// <returns>a <see cref="NullableNumericValidator{T}" /> instance.</returns>
      public static new NullableNumericValidator<T> GetInstance(string parameterName, T? parameterValue)
      {
         if (!Validate.UsingObjectPooling)
            return new NullableNumericValidator<T>(parameterName, parameterValue);

         var instance = PoolInstance.Allocate();
         instance.ParameterName = parameterName;
         instance.ParameterValue = parameterValue;
         return instance;
      }

      #endregion

      /// <summary>
      ///    Determines whether the parameter being validated is negative.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{NullableNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must be negative.</exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsNegative()
      {
         if (ShouldReturnAfterEvaluation(PerformIsNegativeOperation(ParameterValue)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustBeNegative);

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Determines whether the parameter being validated is not negative.
      /// </summary>
      /// <returns>A new <see cref="ValidatorLinkage{NullableNumericValidator}" /> instance of type T.</returns>
      /// <exception cref="ArgumentOutOfRangeException">Must not be negative.</exception>
      public ValidatorLinkage<NullableNumericValidator<T>> IsNotNegative()
      {
         if (ShouldReturnAfterEvaluation(!PerformIsNegativeOperation(ParameterValue)))
            return new ValidatorLinkage<NullableNumericValidator<T>>(this);

         if (CurrentException == null)
            CurrentException = new ArgumentOutOfRangeException(ParameterName, Resources.MustNotBeNegative);

         return new ValidatorLinkage<NullableNumericValidator<T>>(this);
      }

      /// <summary>
      ///    Performs the IsNegative operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue" /> is negative, <c>false</c> otherwise.</returns>
      protected virtual bool PerformIsNegativeOperation(T? currentValue)
      {
         if (!currentValue.HasValue)
            return false;

         return Nullable.Compare(currentValue, default(T)) < 0;
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