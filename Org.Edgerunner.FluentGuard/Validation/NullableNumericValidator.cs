﻿#region Apache License 2.0
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
namespace Org.Edgerunner.FluentGuard.Validation
{
   public class NullableNumericValidator<T> : NullableUnsignedNumericValidator<T> where T : struct
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="NullableUnsignedNumericValidator{T}"/> class. 
      /// </summary>
      /// <param name="parameterName">
      /// The name of the parameter being validated.
      /// </param>
      /// <param name="parameterValue">
      /// The value of the parameter being validated.
      /// </param>
      public NullableNumericValidator(string parameterName, T? parameterValue)
         : base(parameterName, parameterValue)
      {
      }
   }
}