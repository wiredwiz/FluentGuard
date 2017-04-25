#region Apache License 2.0

// <copyright file="DateTimeValidatorTests.cs" company="Edgerunner.org">
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
using Org.Edgerunner.FluentGuard.Tests.Data;
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;
using Xunit;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class DateTimeValidatorTests.
   /// </summary>
   /// <seealso cref="DateTime" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class DateTimeValidatorTests : ValidatorTests<DateTime>
   {
      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>     
      [Scenario]
      [MemberData(nameof(DateTimeData.IsGreaterThan), MemberType = typeof(DateTimeData))]
      public override void TestParameterGreaterThanPasses(string parameterName, DateTime parameterValue, DateTime valueToCompare, Validator<DateTime> validator)
      {
         base.TestParameterGreaterThanPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsNotEqualTo), MemberType = typeof(DateTimeData))]
      public override void TestParameterEqualToFails(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator,
         Action act)
      {
         base.TestParameterEqualToFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsEqualTo), MemberType = typeof(DateTimeData))]
      public override void TestParameterEqualToPasses(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator)
      {
         base.TestParameterEqualToPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      ///    Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsLessThanOrEqualTo), MemberType = typeof(DateTimeData))]
      public override void TestParameterGreaterThanFails(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator,
         Action act)
      {
         base.TestParameterGreaterThanFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      ///    Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsLessThan), MemberType = typeof(DateTimeData))]
      public override void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator,
         Action act)
      {
         base.TestParameterGreaterThanOrEqualToFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      ///    Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsGreaterThanOrEqualTo), MemberType = typeof(DateTimeData))]
      public override void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator)
      {
         base.TestParameterGreaterThanOrEqualToPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      ///    Tests IsFalse validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.RandomDateValues), MemberType = typeof(DateTimeData))]
      public override void TestParameterIsFalseFails(string parameterName, DateTime parameterValue, Validator<DateTime> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is true"
            .x(() => act = () => validator.IsTrue().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(string.Format(Resources.UnableToPerformBooleanOp)));
      }

      /// <summary>
      ///    Tests IsNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.RandomDateValues), MemberType = typeof(DateTimeData))]
      public override void TestParameterIsNegativeFails(string parameterName, DateTime parameterValue, Validator<DateTime> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsNegative().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformPosNegOp));
      }
      
      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.RandomDateValues), MemberType = typeof(DateTimeData))]
      public override void TestParameterIsNotNegativeFails(string parameterName, DateTime parameterValue, Validator<DateTime> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsNegative().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformPosNegOp));
      }
      
      /// <summary>
      ///    Tests IsNotPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.RandomDateValues), MemberType = typeof(DateTimeData))]
      public override void TestParameterIsNotPositiveFails(string parameterName, DateTime parameterValue, Validator<DateTime> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsNegative().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformPosNegOp));
      }
      
      /// <summary>
      ///    Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.RandomDateValues), MemberType = typeof(DateTimeData))]
      public override void TestParameterIsPositiveFails(string parameterName, DateTime parameterValue, Validator<DateTime> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsNegative().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformPosNegOp));
      }
      
      /// <summary>
      ///    Tests IsTrue validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.RandomDateValues), MemberType = typeof(DateTimeData))]
      public override void TestParameterIsTrueFails(string parameterName, DateTime parameterValue, Validator<DateTime> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is true"
            .x(() => act = () => validator.IsTrue().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(string.Format(Resources.UnableToPerformBooleanOp)));
      }

      /// <summary>
      ///    Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsGreaterThanOrEqualTo), MemberType = typeof(DateTimeData))]
      public override void TestParameterLessThanFails(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator,
         Action act)
      {
         base.TestParameterLessThanFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      ///    Tests less than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsGreaterThan), MemberType = typeof(DateTimeData))]
      public override void TestParameterLessThanOrEqualToFails(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator,
         Action act)
      {
         base.TestParameterLessThanOrEqualToFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      ///    Tests less than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsLessThanOrEqualTo), MemberType = typeof(DateTimeData))]
      public override void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator)
      {
         base.TestParameterLessThanOrEqualToPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      ///    Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsLessThan), MemberType = typeof(DateTimeData))]
      public override void TestParameterLessThanPasses(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator)
      {
         base.TestParameterLessThanPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsEqualTo), MemberType = typeof(DateTimeData))]
      public override void TestParameterNotEqualToFails(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator,
         Action act)
      {
         base.TestParameterNotEqualToFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.IsNotEqualTo), MemberType = typeof(DateTimeData))]
      public override void TestParameterNotEqualToPasses(
         string parameterName,
         DateTime parameterValue,
         DateTime valueToCompare,
         Validator<DateTime> validator)
      {
         base.TestParameterNotEqualToPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      ///    Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(DateTimeData.RandomDateValues), MemberType = typeof(DateTimeData))]
      public override void TestParameterNotNullPasses(string parameterName, DateTime parameterValue, Validator<DateTime> validator)
      {
         base.TestParameterNotNullPasses(parameterName, parameterValue, validator);
      }
   }
}