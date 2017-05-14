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
using NDepend.Attributes;
using Org.Edgerunner.FluentGuard.Validation;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   /// Class for validation of inputs.
   /// </summary>
   [FullCovered]
   public static class Validate
   {
      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="BooleanValidator" /> instance.</returns>
      public static BooleanValidator That(string nameOfParameter, bool parameterValue)
      {
         return new BooleanValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableBooleanValidator"/> instance.</returns>
      public static NullableBooleanValidator That(string nameOfParameter, bool? parameterValue)
      {
         return new NullableBooleanValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{Char}" /> instance.</returns>
      public static UnsignedNumericValidator<char> That(string nameOfParameter, char parameterValue)
      {
         return new UnsignedNumericValidator<char>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{Char}" /> instance.</returns>
      public static NullableUnsignedNumericValidator<char> That(string nameOfParameter, char? parameterValue)
      {
         return new NullableUnsignedNumericValidator<char>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="StringValidator" /> instance.</returns>
      public static StringValidator That(string nameOfParameter, string parameterValue)
      {
         return new StringValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Int32}" /> instance.</returns>
      public static NumericValidator<int> That(string nameOfParameter, int parameterValue)
      {
         return new NumericValidator<int>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Int32}" /> instance.</returns>
      public static NullableNumericValidator<int> That(string nameOfParameter, int? parameterValue)
      {
         return new NullableNumericValidator<int>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{UInt32}" /> instance.</returns>
      public static UnsignedNumericValidator<uint> That(string nameOfParameter, uint parameterValue)
      {
         return new UnsignedNumericValidator<uint>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{UInt32}" /> instance.</returns>
      public static NullableUnsignedNumericValidator<uint> That(string nameOfParameter, uint? parameterValue)
      {
         return new NullableUnsignedNumericValidator<uint>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Long}" /> instance.</returns>
      public static NumericValidator<long> That(string nameOfParameter, long parameterValue)
      {
         return new NumericValidator<long>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Long}" /> instance.</returns>
      public static NullableNumericValidator<long> That(string nameOfParameter, long? parameterValue)
      {
         return new NullableNumericValidator<long>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{Long}" /> instance.</returns>
      public static UnsignedNumericValidator<ulong> That(string nameOfParameter, ulong parameterValue)
      {
         return new UnsignedNumericValidator<ulong>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{Long}" /> instance.</returns>
      public static NullableUnsignedNumericValidator<ulong> That(string nameOfParameter, ulong? parameterValue)
      {
         return new NullableUnsignedNumericValidator<ulong>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Short}" /> instance.</returns>
      public static NumericValidator<short> That(string nameOfParameter, short parameterValue)
      {
         return new NumericValidator<short>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Short}" /> instance.</returns>
      public static NullableNumericValidator<short> That(string nameOfParameter, short? parameterValue)
      {
         return new NullableNumericValidator<short>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{UInt32}" /> instance.</returns>
      public static UnsignedNumericValidator<ushort> That(string nameOfParameter, ushort parameterValue)
      {
         return new UnsignedNumericValidator<ushort>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{UShort}" /> instance.</returns>
      public static NullableUnsignedNumericValidator<ushort> That(string nameOfParameter, ushort? parameterValue)
      {
         return new NullableUnsignedNumericValidator<ushort>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Decimal}" /> instance.</returns>
      public static NumericValidator<decimal> That(string nameOfParameter, decimal parameterValue)
      {
         return new NumericValidator<decimal>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Decimal}" /> instance.</returns>
      public static NullableNumericValidator<decimal> That(string nameOfParameter, decimal? parameterValue)
      {
         return new NullableNumericValidator<decimal>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Double}" /> instance.</returns>
      public static NumericValidator<double> That(string nameOfParameter, double parameterValue)
      {
         return new NumericValidator<double>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Double}" /> instance.</returns>
      public static NullableNumericValidator<double> That(string nameOfParameter, double? parameterValue)
      {
         return new NullableNumericValidator<double>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{Float}" /> instance.</returns>
      public static NumericValidator<float> That(string nameOfParameter, float parameterValue)
      {
         return new NumericValidator<float>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{Float}" /> instance.</returns>
      public static NullableNumericValidator<float> That(string nameOfParameter, float? parameterValue)
      {
         return new NullableNumericValidator<float>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="DateTimeValidator" /> instance.</returns>
      public static DateTimeValidator That(string nameOfParameter, DateTime parameterValue)
      {
         return new DateTimeValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableDateTimeValidator" /> instance.</returns>
      public static NullableDateTimeValidator That(string nameOfParameter, DateTime? parameterValue)
      {
         return new NullableDateTimeValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedNumericValidator{Byte}" /> instance.</returns>
      public static UnsignedNumericValidator<byte> That(string nameOfParameter, byte parameterValue)
      {
         return new UnsignedNumericValidator<byte>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableUnsignedNumericValidator{Byte}" /> instance.</returns>
      public static NullableUnsignedNumericValidator<byte> That(string nameOfParameter, byte? parameterValue)
      {
         return new NullableUnsignedNumericValidator<byte>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NumericValidator{SByte}" /> instance.</returns>
      public static NumericValidator<sbyte> That(string nameOfParameter, sbyte parameterValue)
      {
         return new NumericValidator<sbyte>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="NullableNumericValidator{SByte}" /> instance.</returns>
      public static NullableNumericValidator<sbyte> That(string nameOfParameter, sbyte? parameterValue)
      {
         return new NullableNumericValidator<sbyte>(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="ClassValidator{T}" /> instance.</returns>
      public static ClassValidator<T> That<T>(string nameOfParameter, T parameterValue) where T : class
      {
         return new ClassValidator<T>(nameOfParameter, parameterValue);
      }
   }
}