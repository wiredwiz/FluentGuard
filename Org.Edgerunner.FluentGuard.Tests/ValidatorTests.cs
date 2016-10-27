#region Apache License 2.0

// <copyright file="ValidatorTests.cs" company="Edgerunner.org">
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
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class that tests the validator methods.
   /// </summary>
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]
   public class ValidatorTests
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
      [Example("foo", 5, 2)]
      [Example("foo", 2, 2)]
      [Example("foo", 3, 2)]
      public void TestParameterLessThanFails(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsLessThan(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Properties.Resources.MustBeLessThanX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      /// Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 5)]
      [Example("foo", 2, 3)]
      [Example("foo", 0, 2)]
      public void TestParameterLessThanPasses(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => validator.IsLessThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
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
      [Example("foo", 5, 2)]
      [Example("foo", 3, 2)]
      [Example("foo", 1, 0)]
      public void TestParameterLessThanOrEqualToFails(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the value to compare against"
            .x(() => act = () => validator.IsLessThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Properties.Resources.MustBeLessThanOrEqualToX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      /// Tests less than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 5)]
      [Example("foo", 2, 3)]
      [Example("foo", 1, 1)]
      [Example("foo", 0, 1)]
      public void TestParameterLessThanOrEqualToPasses(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the value to compare against"
            .x(() => validator.IsLessThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
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
      [Example("foo", 2, 4)]
      [Example("foo", 2, 2)]
      [Example("foo", 0, 1)]
      public void TestParameterGreaterThanFails(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than the value to compare against"
            .x(() => act = () => validator.IsGreaterThan(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Properties.Resources.MustBeGreaterThanX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 9, 2)]
      [Example("foo", 4, 2)]
      [Example("foo", 1, 0)]
      public void TestParameterGreaterThanPasses(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than the value to compare against"
            .x(() => validator.IsGreaterThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
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
      [Example("foo", 2, 6)]
      [Example("foo", 1, 2)]
      [Example("foo", 2, 4)]
      public void TestParameterGreaterThanOrEqualToFails(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => act = () => validator.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Properties.Resources.MustBeGreaterThanOrEqualToX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      /// Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 4, 2)]
      [Example("foo", 3, 2)]
      [Example("foo", 1, 1)]
      [Example("foo", 1, 0)]
      public void TestParameterGreaterThanOrEqualToPasses(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => validator.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
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
      [Example("foo", 2, 6)]
      [Example("foo", 1, 2)]
      [Example("foo", 2, 1)]
      [Example("foo", 4, 2)]
      public void TestParameterEqualToFails(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => act = () => validator.IsEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Properties.Resources.MustBeEqualToX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 0, 0)]
      [Example("foo", 1, 1)]
      [Example("foo", -1, -1)]
      public void TestParameterEqualToPasses(string parameterName, int parameterValue, int valueToCompare, Validator<int> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validator.IsEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", null)]
      public void TestParameterNotNullFails(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter is not null"
            .x(() => act = () => validator.IsNotNull().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Properties.Resources.MustNotBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", "bar")]
      [Example("foo", "")]
      public void TestParameterNotNullPasses(string parameterName, string parameterValue, Validator<string> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter is not null"
            .x(() => validator.IsNotNull().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
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
      public void TestParameterNotNullOrEmptyFailsNull(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter is not null or empty"
            .x(() => act = () => validator.IsNotNullOrEmpty().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Properties.Resources.MustNotBeNullOrEmpty + "\r\nParameter name: {0}", parameterName)));
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
      public void TestParameterNotNullOrEmptyFailsEmpty(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter is not null or empty"
            .x(() => act = () => validator.IsNotNullOrEmpty().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Properties.Resources.MustNotBeNullOrEmpty + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests not null or empty validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", "bar")]
      public void TestParameterNotNullOrEmptyPasses(string parameterName, string parameterValue, Validator<string> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter is not null or empty"
            .x(() => validator.IsNotNullOrEmpty().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
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
      [Example("foo", null, "bah")]
      [Example("foo", "", "bah")]
      public void TestParameterStartsWithFails(string parameterName, string parameterValue, string valueToCompare, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter starts with a given string"
            .x(() => act = () => validator.StartsWith(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Properties.Resources.MustStartWithX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      /// Tests StartsWith validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", "bar maid")]
      public void TestParameterStartsWithFailsNull(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter starts with a null string"
            .x(() => act = () => validator.StartsWith(null).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>());
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
      public void TestParameterStartsWithPasses(string parameterName, string parameterValue, string valueToCompare, Validator<string> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter starts with a given string"
            .x(() => validator.StartsWith(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
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
      [Example("foo", "bar maid", "bah")]
      [Example("foo", null, "bah")]
      [Example("foo", "", "bah")]
      public void TestParameterEndsWithFails(string parameterName, string parameterValue, string valueToCompare, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter ends with a given string"
            .x(() => act = () => validator.EndsWith(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Properties.Resources.MustEndWithX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      /// Tests EndsWith validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", "bar maid")]
      public void TestParameterEndsWithFailsNull(string parameterName, string parameterValue, Validator<string> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter ends with a null string"
            .x(() => act = () => validator.EndsWith(null).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>());
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
      public void TestParameterEndsWithPasses(string parameterName, string parameterValue, string valueToCompare, Validator<string> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter ends with a given string"
            .x(() => validator.EndsWith(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 1, 2, 5)]
      public void TestParameterConditionAndFailsLower(string parameterName, int parameterValue, int lowerBound, int upperBound, Validator<int> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => act = () => validator.IsGreaterThanOrEqualTo(lowerBound).And().IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Properties.Resources.MustBeGreaterThanOrEqualToX + "\r\nParameter name: {1}", lowerBound, parameterName)));
      }

      /// <summary>
      /// Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 8, 2, 5)]
      public void TestParameterConditionAndFailsUpper(string parameterName, int parameterValue, int lowerBound, int upperBound, Validator<int> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => act = () => validator.IsGreaterThanOrEqualTo(lowerBound).And().IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Properties.Resources.MustBeLessThanOrEqualToX + "\r\nParameter name: {1}", upperBound, parameterName)));
      }

      /// <summary>
      /// Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 2, 5)]
      [Example("foo", 4, 2, 5)]
      [Example("foo", 5, 2, 5)]
      public void TestParameterConditionAndPasses(string parameterName, int parameterValue, int lowerBound, int upperBound, Validator<int> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => validator.IsGreaterThanOrEqualTo(lowerBound).And().IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests OR combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 3, 2, 6)]
      [Example("foo", 4, 2, 6)]
      [Example("foo", 5, 2, 6)]
      public void TestParameterConditionOrFails(string parameterName, int parameterValue, int lowerBound, int upperBound, Validator<int> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the lower bound or greater than or equal to the upper bound"
            .x(() => act = () => validator.IsLessThanOrEqualTo(lowerBound).Or().IsGreaterThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Properties.Resources.MustBeLessThanOrEqualToX + "\r\nParameter name: {1}", lowerBound, parameterName)));
      }
      
      /// <summary>
      /// Tests OR combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 2, 5)]
      [Example("foo", 1, 2, 5)]
      [Example("foo", 0, 2, 5)]
      [Example("foo", 5, 2, 5)]
      [Example("foo", 6, 2, 5)]
      [Example("foo", 9, 2, 5)]
      public void TestParameterConditionOrPasses(string parameterName, int parameterValue, int lowerBound, int upperBound, Validator<int> validator)
      {
         "Given a new validator"
            .x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the lower bound or greater than or equal to the upper bound"
            .x(() => validator.IsLessThanOrEqualTo(lowerBound).Or().IsGreaterThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }
   }
}