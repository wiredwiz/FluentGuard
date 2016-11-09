#region Apache License 2.0
// <copyright file="ValidatorFactory.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.FluentGuard.Validators
{
   /// <summary>
   /// Factory class for creating new validator instances.
   /// </summary>
   internal class ValidatorFactory : IValidatorFactory
   {
      /// <summary>
      /// Creates a new instance of <see cref="Validator{T}"/>.
      /// </summary>
      /// <typeparam name="T">The type of data to validate.</typeparam>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      /// <returns>A new <see cref="Validator{T}"/> instance.</returns>
      public Validator<T> Create<T>(string parameterName, T parameterValue)
      {
         var typeData = typeof(T);

         if (typeData == typeof(bool))
            return new BooleanValidator(parameterName, Convert.ToBoolean(parameterValue)) as Validator<T>;
         if (typeData == typeof(int))
            return new IntegerValidator(parameterName, Convert.ToInt32(parameterValue)) as Validator<T>;
         if (typeData == typeof(string))
            return new StringValidator(parameterName, parameterValue == null ? null : Convert.ToString(parameterValue)) as Validator<T>;
         if (typeData == typeof(double))
            return new DoubleValidator(parameterName, Convert.ToDouble(parameterValue)) as Validator<T>;
         if (typeData == typeof(decimal))
            return new DecimalValidator(parameterName, Convert.ToDecimal(parameterValue)) as Validator<T>;
         if (typeData == typeof(DateTime))
            return new DateTimeValidator(parameterName, Convert.ToDateTime(parameterValue)) as Validator<T>;
         if (typeData == typeof(long))
            return new LongValidator(parameterName, Convert.ToInt64(parameterValue)) as Validator<T>;
         if (typeData == typeof(short))
            return new ShortValidator(parameterName, Convert.ToInt16(parameterValue)) as Validator<T>;
         if (typeData == typeof(char))
            return new CharacterValidator(parameterName, Convert.ToChar(parameterValue)) as Validator<T>;
         if (typeData == typeof(float))
            return new FloatValidator(parameterName, Convert.ToSingle(parameterValue)) as Validator<T>;
         if (typeData == typeof(ulong))
            return new UnsignedLongValidator(parameterName, Convert.ToUInt64(parameterValue)) as Validator<T>;
         if (typeData == typeof(ushort))
            return new UnsignedShortValidator(parameterName, Convert.ToUInt16(parameterValue)) as Validator<T>;
         if (typeData == typeof(uint))
            return new UnsignedIntegerValidator(parameterName, Convert.ToUInt32(parameterValue)) as Validator<T>;
         if (typeData == typeof(byte))
            return new ByteValidator(parameterName, Convert.ToByte(parameterValue)) as Validator<T>;
         if (typeData == typeof(sbyte))
            return new SByteValidator(parameterName, Convert.ToSByte(parameterValue)) as Validator<T>;       

         return new Validator<T>(parameterName, parameterValue);
      }
   }
}