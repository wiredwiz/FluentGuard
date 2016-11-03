#region Apache License 2.0

// <copyright file="BooleanValidatorTests.cs" company="Edgerunner.org">
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
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.FluentGuard.Validators;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   /// Class BooleanValidatorTests.
   /// </summary>
   public class BooleanValidatorTests : ValidatorTests<bool>
   {
      /// <summary>
      /// Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public override void TestParameterLessThanFails(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator, Action act)
      {
         base.TestParameterLessThanFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      /// Tests less than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>      
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      public override void TestParameterLessThanOrEqualToFails(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator, Action act)
      {
         base.TestParameterLessThanOrEqualToFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      /// Tests less than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public override void TestParameterLessThanOrEqualToPasses(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator)
      {
         base.TestParameterLessThanOrEqualToPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>      
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public override void TestParameterGreaterThanFails(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator, Action act)
      {
         base.TestParameterGreaterThanFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      /// Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>      
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      public override void TestParameterGreaterThanOrEqualToFails(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator, Action act)
      {
         base.TestParameterGreaterThanOrEqualToFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      /// Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>      
      [Scenario]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public override void TestParameterGreaterThanOrEqualToPasses(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator)
      {
         base.TestParameterGreaterThanOrEqualToPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      public override void TestParameterEqualToFails(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator, Action act)
      {
         base.TestParameterEqualToFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>      
      [Scenario]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public override void TestParameterEqualToPasses(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator)
      {
         base.TestParameterEqualToPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public override void TestParameterNotEqualToFails(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator, Action act)
      {
         base.TestParameterNotEqualToFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      public override void TestParameterNotEqualToPasses(string parameterName, bool parameterValue, bool valueToCompare, Validator<bool> validator)
      {
         base.TestParameterNotEqualToPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      [Example("foo", false)]
      public override void TestParameterNotNullPasses(string parameterName, bool parameterValue, Validator<bool> validator)
      {
         base.TestParameterNotNullPasses(parameterName, parameterValue, validator);
      }

      /// <summary>
      /// Tests IsTrue validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", false)]
      public override void TestParameterIsTrueFails(string parameterName, bool parameterValue, Validator<bool> validator, Action act)
      {
         base.TestParameterIsTrueFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      /// Tests IsTrue validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      public override void TestParameterIsTruePasses(string parameterName, bool parameterValue, Validator<bool> validator)
      {
         base.TestParameterIsTruePasses(parameterName, parameterValue, validator);
      }

      /// <summary>
      /// Tests IsFalse validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      public override void TestParameterIsFalseFails(string parameterName, bool parameterValue, Validator<bool> validator, Action act)
      {
         base.TestParameterIsFalseFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      /// Tests IsFalse validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", false)]
      public override void TestParameterIsFalsePasses(string parameterName, bool parameterValue, Validator<bool> validator)
      {
         base.TestParameterIsFalsePasses(parameterName, parameterValue, validator);
      }

      /// <summary>
      /// Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      [Example("foo", false)]
      public override void TestParameterIsPositiveFails(string parameterName, bool parameterValue, Validator<bool> validator, Action act)
      {
         base.TestParameterIsPositiveFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      /// Tests IsNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      [Example("foo", false)]
      public override void TestParameterIsNegativeFails(string parameterName, bool parameterValue, Validator<bool> validator, Action act)
      {
         base.TestParameterIsNegativeFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      /// Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      [Example("foo", false)]
      public override void TestParameterIsNotNegativeFails(string parameterName, bool parameterValue, Validator<bool> validator, Action act)
      {
         base.TestParameterIsNotNegativeFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      /// Tests IsNotPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      [Example("foo", false)]
      public override void TestParameterIsNotPositiveFails(string parameterName, bool parameterValue, Validator<bool> validator, Action act)
      {
         base.TestParameterIsNotPositiveFails(parameterName, parameterValue, validator, act);
      }
   }
}
