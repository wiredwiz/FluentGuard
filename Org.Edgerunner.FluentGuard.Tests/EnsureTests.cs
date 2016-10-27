﻿#region Apache License 2.0

// <copyright file="EnsureTests.cs" company="Edgerunner.org">
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
using FluentAssertions;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class containing Ensure unit tests.
   /// </summary>
   public class EnsureTests
   {
      /// <summary>
      ///    Scenario1s the specified parameter name.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      /// <param name="validator">The validator to test with.</param>
      [Scenario]
      [Example("foo", 2)]
      public void Scenario1(string parameterName, int parameterValue, Validator<int> validator)
      {
         "Ensuring that a given parameter and its value, results in a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Where its name matches the supplied parameter name"
            .x(() => validator.ParameterName.Should().Be(parameterName));

         "And its value matches the supplied parameter value"
            .x(() => validator.ParameterValue.Should().Be(parameterValue));
      }
   }
}