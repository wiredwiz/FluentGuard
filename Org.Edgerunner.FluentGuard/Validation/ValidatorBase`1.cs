#region Apache License 2.0

// <copyright company="Edgerunner.org" file="ValidatorBase`1.cs">
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
using System.Runtime.CompilerServices;

#if NDEPEND
using NDepend.Attributes;
using Org.Edgerunner.NDepend.Attributes;
#endif

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   /// Class that validates data.
   /// </summary>
   /// <typeparam name="T">The type of data to validate.</typeparam>
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "The potential string format exceptions will not occurr.")]
#if NDEPEND
   [FullCovered]
   [ExcludeFromNestingCheck]
#endif   
   // ReSharper disable once ClassTooBig
   public abstract class ValidatorBase<T> : ValidatorBase
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="ValidatorBase{T}" /> class.
      /// </summary>
      /// <param name="parameterName">The name of the parameter being validated.</param>
      /// <param name="parameterValue">The value of the parameter being validated.</param>
      protected ValidatorBase(string parameterName, T parameterValue)
      {
         ParameterName = parameterName;
         ParameterValue = parameterValue;
         Mode = CombinationMode.And;
         CurrentException = null;
      }

      #endregion

      /// <summary>
      /// Gets the name of the parameter being checked.
      /// </summary>
      /// <value>The name of the parameter.</value>
      public virtual string ParameterName { get; }

      /// <summary>
      /// Gets the parameter value being checked.
      /// </summary>
      /// <value>The parameter value.</value>
      public virtual T ParameterValue { get; }

      /// <summary>
      ///    Determines whether the current condition evaluation should return.
      /// </summary>
      /// <param name="evaluationResult">The result of a rule evaluation.</param>
      /// <returns><c>true</c> if the rule evaluation method should return, <c>false</c> otherwise.</returns>
#if Framework45
#elif Framework46
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
      // ReSharper disable once FlagArgument
      protected bool ShouldReturnAfterEvaluation(bool evaluationResult)
      {
         if (Mode == CombinationMode.And)
            if (CurrentException != null)
               return true;

         if (!evaluationResult)
            if (Mode == CombinationMode.Or
                && CurrentException == null)
               return true;
            else
               return false;

         if (Mode == CombinationMode.Or)
            CurrentException = null;

         return true;
      }

      /// <summary>
      /// Performs the less than operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is less than <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
#if NDEPEND
      [IgnoreBoxing]
#endif
      protected virtual bool PerformLessThanOperation(T currentValue, T referenceValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         // ReSharper disable once PossibleNullReferenceException
         return original.CompareTo(referenceValue) < 0;
      }

      /// <summary>
      /// Performs the less than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is less than or equal to <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
#if NDEPEND
      [IgnoreBoxing]
#endif
      protected virtual bool PerformLessThanOrEqualToOperation(T currentValue, T referenceValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         // ReSharper disable once PossibleNullReferenceException
         return original.CompareTo(referenceValue) <= 0;
      }

      /// <summary>
      /// Performs the greater than operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is greater than <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
#if NDEPEND
      [IgnoreBoxing]
#endif
      protected virtual bool PerformGreaterThanOperation(T currentValue, T referenceValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         // ReSharper disable once PossibleNullReferenceException
         return original.CompareTo(referenceValue) > 0;
      }

      /// <summary>
      /// Performs the greater than or equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is greater than or equal to <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
#if NDEPEND
      [IgnoreBoxing]
#endif
      protected virtual bool PerformGreaterThanOrEqualToOperation(T currentValue, T referenceValue)
      {
         IComparable<T> original = ParameterValue as IComparable<T>;
         // ReSharper disable once PossibleNullReferenceException
         return original.CompareTo(referenceValue) >= 0;
      }

      /// <summary>
      /// Performs the equal to operation.
      /// </summary>
      /// <param name="currentValue">The current value.</param>
      /// <param name="referenceValue">The reference value.</param>
      /// <returns><c>true</c> if <paramref name="currentValue"/> is greater than or equal to <paramref name="referenceValue"/>, <c>false</c> otherwise.</returns>
#if NDEPEND
      [IgnoreBoxing]
#endif
      protected virtual bool PerformEqualToOperation(T currentValue, T referenceValue)
      {
         IEquatable<T> original = currentValue as IEquatable<T>;
         // ReSharper disable once PossibleNullReferenceException
         return original.Equals(referenceValue);
      }
   }
}