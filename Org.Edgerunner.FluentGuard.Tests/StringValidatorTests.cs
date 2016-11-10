#region Apache License 2.0

// <copyright file="StringValidatorTests.cs" company="Edgerunner.org">
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
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class IntegerValidatorTests.
   /// </summary>
   /// <seealso cref="string" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class StringValidatorTests : ValidatorTests<string>
   {
      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", null)]
      public override void TestParameterNotNullFails(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         base.TestParameterNotNullFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      /// Tests not null or empty validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", null)]
      public override void TestParameterNotNullOrEmptyFailsNull(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         base.TestParameterNotNullOrEmptyFailsNull(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      /// Tests not null or empty validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", "")]
      public override void TestParameterNotNullOrEmptyFailsEmpty(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         base.TestParameterNotNullOrEmptyFailsEmpty(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      /// Tests not null or empty validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", "foobar")]
      public override void TestParameterNotNullOrEmptyPasses(string parameterName, string parameterValue, Validator<string> validator)
      {
         base.TestParameterNotNullOrEmptyPasses(parameterName, parameterValue, validator);
      }

      /// <summary>
      /// Tests StartsWith validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", "bar maid", "bah")]
      [Example("foo", "", "bah")]
      public override void TestParameterStartsWithFails(string parameterName, string parameterValue, string valueToCompare, Validator<string> validator, Action act)
      {
         base.TestParameterStartsWithFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      /// Tests StartsWith validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="nullValue">The null value.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", "Foobar Bah", null)]
      public override void TestParameterStartsWithFailsNull(string parameterName, string parameterValue, string nullValue, Validator<string> validator, Action act)
      {
         base.TestParameterStartsWithFailsNull(parameterName, parameterValue, nullValue, validator, act);
      }

      /// <summary>
      /// Tests StartsWith validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", "bar maid", "bar")]
      [Example("foo", "Big Bear", "Bi")]
      [Example("foo", "Trolley", "")]
      public override void TestParameterStartsWithPasses(string parameterName, string parameterValue, string valueToCompare, Validator<string> validator)
      {
         base.TestParameterStartsWithPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      /// Tests EndsWith validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", "bar maid", "bar")]
      [Example("foo", "", "bah")]
      public override void TestParameterEndsWithFails(string parameterName, string parameterValue, string valueToCompare, Validator<string> validator, Action act)
      {
         base.TestParameterEndsWithFails(parameterName, parameterValue, valueToCompare, validator, act);
      }

      /// <summary>
      /// Tests EndsWith validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="nullValue">The null value.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", "bar maid", null)]
      public override void TestParameterEndsWithFailsNull(string parameterName, string parameterValue, string nullValue, Validator<string> validator, Action act)
      {
         base.TestParameterEndsWithFailsNull(parameterName, parameterValue, null, validator, act);
      }

      /// <summary>
      /// Tests EndsWith validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", "bar maid", "aid")]
      [Example("foo", "Big Bear", "ear")]
      [Example("foo", "Trolley", "")]
      public override void TestParameterEndsWithPasses(string parameterName, string parameterValue, string valueToCompare, Validator<string> validator)
      {
         base.TestParameterEndsWithPasses(parameterName, parameterValue, valueToCompare, validator);
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
      [Example("foo", "foo", "bar")]
      [Example("foo", "bar", "bah")]
      [Example("foo", "", "bar")]
      public override void TestParameterEqualToFails(
         string parameterName,
         string parameterValue,
         string valueToCompare,
         Validator<string> validator,
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
      [Example("foo", "foo", "foo")]
      [Example("foo", "bar", "bar")]
      [Example("foo", "", "")]
      public override void TestParameterEqualToPasses(
         string parameterName,
         string parameterValue,
         string valueToCompare,
         Validator<string> validator)
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
      [Example("foo", "foo", "foo")]
      [Example("foo", "foo", "bar")]
      [Example("foo", "bar", "bar")]
      [Example("foo", "", "bar")]
      public override void TestParameterGreaterThanFails(
         string parameterName,
         string parameterValue,
         string valueToCompare,
         Validator<string> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsGreaterThan(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformAGreaterThanOp));
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
      [Example("foo", "foo", "foo")]
      [Example("foo", "foo", "bar")]
      [Example("foo", "bar", "bar")]
      [Example("foo", "", "bar")]
      public override void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         string parameterValue,
         string valueToCompare,
         Validator<string> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformAGreaterThanOrEqualToOp));
      }

      /// <summary>
      ///    Tests IsFalse validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", "foo")]
      [Example("foo", "bar")]
      [Example("foo", "")]
      public override void TestParameterIsFalseFails(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

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
      [Example("foo", "foo")]
      [Example("foo", "bar")]
      [Example("foo", "")]
      public override void TestParameterIsNegativeFails(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

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
      [Example("foo", "foo")]
      [Example("foo", "bar")]
      [Example("foo", "")]
      public override void TestParameterIsNotNegativeFails(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsNotNegative().OtherwiseThrowException());

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
      [Example("foo", "foo")]
      [Example("foo", "bar")]
      [Example("foo", "")]
      public override void TestParameterIsNotPositiveFails(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsNotPositive().OtherwiseThrowException());

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
      [Example("foo", "foo")]
      [Example("foo", "bar")]
      [Example("foo", "")]
      public override void TestParameterIsPositiveFails(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsPositive().OtherwiseThrowException());

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
      [Example("foo", "foo")]
      [Example("foo", "bar")]
      [Example("foo", "")]
      public override void TestParameterIsTrueFails(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

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
      [Example("foo", "foo", "foo")]
      [Example("foo", "foo", "bar")]
      [Example("foo", "bar", "bar")]
      [Example("foo", "", "bar")]
      public override void TestParameterLessThanFails(
         string parameterName,
         string parameterValue,
         string valueToCompare,
         Validator<string> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsLessThan(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformALessThanOp));
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
      [Example("foo", "foo", "foo")]
      [Example("foo", "foo", "bar")]
      [Example("foo", "bar", "bar")]
      [Example("foo", "", "bar")]
      public override void TestParameterLessThanOrEqualToFails(
         string parameterName,
         string parameterValue,
         string valueToCompare,
         Validator<string> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsLessThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformALessThanOrEqualToOp));
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
      [Example("foo", "foo", "foo")]
      [Example("foo", "bar", "bar")]
      [Example("foo", "", "")]
      public override void TestParameterNotEqualToFails(
         string parameterName,
         string parameterValue,
         string valueToCompare,
         Validator<string> validator,
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
      [Example("foo", "foo", "bar")]
      [Example("foo", "bar", "bah")]
      [Example("foo", "", "bar")]
      public override void TestParameterNotEqualToPasses(
         string parameterName,
         string parameterValue,
         string valueToCompare,
         Validator<string> validator)
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
      [Example("foo", "foo")]
      [Example("foo", "bar")]
      [Example("foo", "")]
      public override void TestParameterNotNullPasses(string parameterName, string parameterValue, Validator<string> validator)
      {
         base.TestParameterNotNullPasses(parameterName, parameterValue, validator);
      }
   }
}