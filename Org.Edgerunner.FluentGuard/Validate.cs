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
using System.Linq.Expressions;
using System.Reflection;
using Org.Edgerunner.FluentGuard.Validation;

namespace Org.Edgerunner.FluentGuard
{
   /// <summary>
   /// Class for validation of inputs.
   /// </summary>
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
      /// <returns>A new <see cref="IntegerValidator" /> instance.</returns>
      public static IntegerValidator That(string nameOfParameter, int parameterValue)
      {
         return new IntegerValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedIntegerValidator" /> instance.</returns>
      public static UnsignedIntegerValidator That(string nameOfParameter, uint parameterValue)
      {
         return new UnsignedIntegerValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="LongValidator" /> instance.</returns>
      public static LongValidator That(string nameOfParameter, long parameterValue)
      {
         return new LongValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedLongValidator" /> instance.</returns>
      public static UnsignedLongValidator That(string nameOfParameter, ulong parameterValue)
      {
         return new UnsignedLongValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="ShortValidator" /> instance.</returns>
      public static ShortValidator That(string nameOfParameter, short parameterValue)
      {
         return new ShortValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="UnsignedShortValidator" /> instance.</returns>
      public static UnsignedShortValidator That(string nameOfParameter, ushort parameterValue)
      {
         return new UnsignedShortValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="DecimalValidator" /> instance.</returns>
      public static DecimalValidator That(string nameOfParameter, decimal parameterValue)
      {
         return new DecimalValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="DoubleValidator" /> instance.</returns>
      public static DoubleValidator That(string nameOfParameter, double parameterValue)
      {
         return new DoubleValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="FloatValidator" /> instance.</returns>
      public static FloatValidator That(string nameOfParameter, float parameterValue)
      {
         return new FloatValidator(nameOfParameter, parameterValue);
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
      /// <returns>A new <see cref="ByteValidator" /> instance.</returns>
      public static ByteValidator That(string nameOfParameter, byte parameterValue)
      {
         return new ByteValidator(nameOfParameter, parameterValue);
      }

      /// <summary>
      /// Validates the specified parameter value.
      /// </summary>
      /// <param name="nameOfParameter">The name of parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <returns>A new <see cref="SByteValidator" /> instance.</returns>
      public static SByteValidator That(string nameOfParameter, sbyte parameterValue)
      {
         return new SByteValidator(nameOfParameter, parameterValue);
      }
   }
}