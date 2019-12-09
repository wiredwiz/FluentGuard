#region Apache License 2.0

// <copyright file="Validate.cs" company="Edgerunner.org">
// Copyright 2016 Thaddeus Ryker
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

using Org.Edgerunner.FluentGuard.Validation;

#if NDEPEND
using NDepend.Attributes;
using Org.Edgerunner.NDepend.Attributes;
#endif

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   /// Class for validation of inputs.
   /// </summary>
#if NDEPEND
   [FullCovered]
   [MethodCountOk]
#endif
   public static class Validate
   {
      /// <summary>
      /// Gets or sets a value indicating whether to use object pooling.
      /// </summary>
      /// <value><c>true</c> if [using object pooling]; otherwise, <c>false</c>.</value>
      public static bool UsingObjectPooling { get; set; } = true;

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="BooleanValidator" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static BooleanValidator That(string nameOfParameter, bool parameterValue)
      {
         return BooleanValidator.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableBooleanValidator"/> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableBooleanValidator That(string nameOfParameter, bool? parameterValue)
      {
         return NullableBooleanValidator.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{Char}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static UnsignedNumericValidator<char> That(string nameOfParameter, char parameterValue)
      {
         return UnsignedNumericValidator<char>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{Char}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableUnsignedNumericValidator<char> That(string nameOfParameter, char? parameterValue)
      {
         return NullableUnsignedNumericValidator<char>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="StringValidator" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static StringValidator That(string nameOfParameter, string parameterValue)
      {
         return StringValidator.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Int32}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NumericValidator<int> That(string nameOfParameter, int parameterValue)
      {
         return NumericValidator<int>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Int32}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableNumericValidator<int> That(string nameOfParameter, int? parameterValue)
      {
         return NullableNumericValidator<int>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{UInt32}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static UnsignedNumericValidator<uint> That(string nameOfParameter, uint parameterValue)
      {
         return UnsignedNumericValidator<uint>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{UInt32}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableUnsignedNumericValidator<uint> That(string nameOfParameter, uint? parameterValue)
      {
         return NullableUnsignedNumericValidator<uint>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Long}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NumericValidator<long> That(string nameOfParameter, long parameterValue)
      {
         return NumericValidator<long>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Long}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableNumericValidator<long> That(string nameOfParameter, long? parameterValue)
      {
         return NullableNumericValidator<long>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{Long}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static UnsignedNumericValidator<ulong> That(string nameOfParameter, ulong parameterValue)
      {
         return UnsignedNumericValidator<ulong>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{Long}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableUnsignedNumericValidator<ulong> That(string nameOfParameter, ulong? parameterValue)
      {
         return NullableUnsignedNumericValidator<ulong>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Short}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NumericValidator<short> That(string nameOfParameter, short parameterValue)
      {
         return NumericValidator<short>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Short}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableNumericValidator<short> That(string nameOfParameter, short? parameterValue)
      {
         return NullableNumericValidator<short>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{UInt32}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static UnsignedNumericValidator<ushort> That(string nameOfParameter, ushort parameterValue)
      {
         return UnsignedNumericValidator<ushort>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{UShort}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableUnsignedNumericValidator<ushort> That(string nameOfParameter, ushort? parameterValue)
      {
         return NullableUnsignedNumericValidator<ushort>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Decimal}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NumericValidator<decimal> That(string nameOfParameter, decimal parameterValue)
      {
         return NumericValidator<decimal>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Decimal}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableNumericValidator<decimal> That(string nameOfParameter, decimal? parameterValue)
      {
         return NullableNumericValidator<decimal>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Double}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NumericValidator<double> That(string nameOfParameter, double parameterValue)
      {
         return NumericValidator<double>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Double}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableNumericValidator<double> That(string nameOfParameter, double? parameterValue)
      {
         return NullableNumericValidator<double>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Float}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NumericValidator<float> That(string nameOfParameter, float parameterValue)
      {
         return NumericValidator<float>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Float}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableNumericValidator<float> That(string nameOfParameter, float? parameterValue)
      {
         return NullableNumericValidator<float>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="DateTimeValidator" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static DateTimeValidator That(string nameOfParameter, DateTime parameterValue)
      {
         return DateTimeValidator.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableDateTimeValidator" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableDateTimeValidator That(string nameOfParameter, DateTime? parameterValue)
      {
         return NullableDateTimeValidator.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{Byte}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static UnsignedNumericValidator<byte> That(string nameOfParameter, byte parameterValue)
      {
         return UnsignedNumericValidator<byte>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{Byte}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableUnsignedNumericValidator<byte> That(string nameOfParameter, byte? parameterValue)
      {
         return NullableUnsignedNumericValidator<byte>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{SByte}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NumericValidator<sbyte> That(string nameOfParameter, sbyte parameterValue)
      {
         return NumericValidator<sbyte>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{SByte}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static NullableNumericValidator<sbyte> That(string nameOfParameter, sbyte? parameterValue)
      {
         return NullableNumericValidator<sbyte>.GetInstance(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <typeparam name="T">The type of class.</typeparam>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="ClassValidator{T}" /> instance.</returns>
#if NDEPEND
      [OverloadVerified]
#endif
      public static ClassValidator<T> That<T>(string nameOfParameter, T parameterValue) where T : class
      {
         return ClassValidator<T>.GetInstance(nameOfParameter, parameterValue);
      }
   }
}