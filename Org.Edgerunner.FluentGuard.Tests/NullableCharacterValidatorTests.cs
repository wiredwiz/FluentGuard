#region Apache License 2.0

// <copyright file="NullableCharacterValidatorTests.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class that tests the NullableCharacterVaildator.
   /// </summary>
   /// <seealso cref="char" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class NullableCharacterValidatorTests
   {
      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>     
      [Scenario]
      [NullableExample("foo1", 'a', 'A')]
      [NullableExample("foo2", 'b', 'a')]
      [NullableExample("foo3", 'A', null)]
      public void TestParameterGreaterThanPasses(string parameterName, char? parameterValue, char? valueToCompare, NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than the value to compare against"
            .x(() => validator.IsGreaterThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a', 'b', 'g')]
      [NullableExample("foo2", ' ', 'b', 'g')]
      public void TestParameterConditionAndFailsLower(
         string parameterName,
         char? parameterValue,
         char? lowerBound,
         char? upperBound,
         NullableUnsignedNumericValidator<char> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => act = () => validator.IsGreaterThanOrEqualTo(lowerBound).And.IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeGreaterThanOrEqualToX + "\r\nParameter name: {1}", lowerBound, parameterName)));
      }

      /// <summary>
      ///    Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'j', 'c', 'g')]
      [NullableExample("foo2", 'h', 'c', 'g')]     
      public void TestParameterConditionAndFailsUpper(
         string parameterName,
         char? parameterValue,
         char? lowerBound,
         char? upperBound,
         NullableUnsignedNumericValidator<char> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => act = () => validator.IsGreaterThanOrEqualTo(lowerBound).And.IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeLessThanOrEqualToX + "\r\nParameter name: {1}", upperBound, parameterName)));
      }

      /// <summary>
      ///    Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'c', 'c', 'g')]
      [NullableExample("foo2", 'd', 'c', 'g')]
      [NullableExample("foo3", 'e', 'c', 'g')]
      [NullableExample("foo4", 'f', 'c', 'g')]
      [NullableExample("foo5", 'g', 'c', 'g')]
      public void TestParameterConditionAndPasses(
         string parameterName,
         char? parameterValue,
         char? lowerBound,
         char? upperBound,
         NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => validator.IsGreaterThanOrEqualTo(lowerBound).And.IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests OR combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'd', 'c', 'g')]
      [NullableExample("foo2", 'e', 'c', 'g')]
      [NullableExample("foo3", 'f', 'c', 'g')]
      public void TestParameterConditionOrFails(
         string parameterName,
         char? parameterValue,
         char? lowerBound,
         char? upperBound,
         NullableUnsignedNumericValidator<char> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the lower bound or greater than or equal to the upper bound"
            .x(() => act = () => validator.IsLessThanOrEqualTo(lowerBound).Or.IsGreaterThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeLessThanOrEqualToX + "\r\nParameter name: {1}", lowerBound, parameterName)));
      }

      /// <summary>
      ///    Tests OR combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a', 'c', 'g')]
      [NullableExample("foo2", 'b', 'c', 'g')]
      [NullableExample("foo3", 'c', 'c', 'g')]
      [NullableExample("foo4", 'g', 'c', 'g')]
      [NullableExample("foo5", 'h', 'c', 'g')]
      [NullableExample("foo6", 'j', 'c', 'g')]
      public void TestParameterConditionOrPasses(
         string parameterName,
         char? parameterValue,
         char? lowerBound,
         char? upperBound,
         NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the lower bound or greater than or equal to the upper bound"
            .x(() => validator.IsLessThanOrEqualTo(lowerBound).Or.IsGreaterThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a', 'b')]
      [NullableExample("foo2", 'a', 'A')]
      [NullableExample("foo3", '\0', null)]
      public void TestParameterEqualToFails(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => act = () => validator.IsEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeEqualToX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a', 'a')]
      [NullableExample("foo2", 'A', 'A')]
      [NullableExample("foo3", '*', '*')]
      [NullableExample("foo4", null, null)]
      public void TestParameterEqualToPasses(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validator.IsEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'A', 'a')]
      [NullableExample("foo2", 'a', 'b')]
      [NullableExample("foo3", 'a', 'a')]
      [NullableExample("foo4", null, 'a')]
      public void TestParameterGreaterThanFails(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than the value to compare against"
            .x(() => act = () => validator.IsGreaterThan(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeGreaterThanX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      ///    Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'A', 'a')]
      [NullableExample("foo2", 'a', 'b')]
      public void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => act = () => validator.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeGreaterThanOrEqualToX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      ///    Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'b', 'C')]
      [NullableExample("foo2", 'b', 'a')]
      [NullableExample("foo3", 'a', 'a')]
      [NullableExample("foo4", 'A', null)]
      [NullableExample("foo5", null, null)]
      public void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => validator.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNotPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a')]
      [NullableExample("foo2", 'A')]
      public void TestParameterIsNotPositiveFails(string parameterName, char? parameterValue, NullableUnsignedNumericValidator<char> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validator.IsNotPositive().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustNotBePositive + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", '\0')]
      [NullableExample("foo2", null)]
      public void TestParameterIsNotPositivePasses(string parameterName, char? parameterValue, NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validator.IsNotPositive().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", '\0')]
      [NullableExample("foo2", null)]
      public void TestParameterIsPositiveFails(string parameterName, char? parameterValue, NullableUnsignedNumericValidator<char> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validator.IsPositive().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBePositive + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a')]
      [NullableExample("foo2", 'A')]
      [NullableExample("foo3", ' ')]
      public void TestParameterIsPositivePasses(string parameterName, char? parameterValue, NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validator.IsPositive().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a', '\0')]
      [NullableExample("foo2", 'a', 'A')]
      [NullableExample("foo3", 'a', 'a')]
      [NullableExample("foo4", 'b', 'a')]
      [NullableExample("foo5", 'A', null)]
      public void TestParameterLessThanFails(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsLessThan(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeLessThanX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      ///    Tests less than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a', '\0')]
      [NullableExample("foo2", 'a', 'A')]
      [NullableExample("foo3", 'b', 'a')]
      public void TestParameterLessThanOrEqualToFails(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the value to compare against"
            .x(() => act = () => validator.IsLessThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeLessThanOrEqualToX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      ///    Tests less than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", '\0', 'a')]
      [NullableExample("foo2", 'A', 'a')]
      [NullableExample("foo3", 'a', 'a')]
      [NullableExample("foo4", 'a', 'b')]
      [NullableExample("foo5", null, null)]
      public void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the value to compare against"
            .x(() => validator.IsLessThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", '\0', 'a')]
      [NullableExample("foo2", 'A', 'a')]
      [NullableExample("foo3", 'a', 'b')]
      [NullableExample("foo4", null, 'b')]
      public void TestParameterLessThanPasses(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => validator.IsLessThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a', 'a')]
      [NullableExample("foo2", 'A', 'A')]
      [NullableExample("foo3", '\0', '\0')]
      [NullableExample("foo4", null, null)]
      public void TestParameterNotEqualToFails(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => act = () => validator.IsNotEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustNotBeEqualToX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [NullableExample("foo1", 'a', 'A')]
      [NullableExample("foo2", 'A', 'a')]
      [NullableExample("foo3", 'a', 'b')]
      [NullableExample("foo4", '\0', ' ')]
      [NullableExample("foo4", '\0', null)]
      public void TestParameterNotEqualToPasses(
         string parameterName,
         char? parameterValue,
         char? valueToCompare,
         NullableUnsignedNumericValidator<char> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validator.IsNotEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }
   }
}