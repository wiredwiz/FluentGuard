#region Apache License 2.0

// <copyright file="CharacterValidatorTests.cs" company="Edgerunner.org">
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
using Org.Edgerunner.FluentGuard.Exceptions;
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class that tests the CharacterVaildator.
   /// </summary>
   /// <seealso cref="char" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class CharacterValidatorTests
   {
      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>     
      [Scenario]
      [Example("foo", 'a', 'A')]
      [Example("foo", 'b', 'a')]
      public void TestParameterGreaterThanPasses(string parameterName, char parameterValue, char valueToCompare, UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than the value to compare against"
            .x(() => validatorBase.IsGreaterThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a', 'b', 'g')]
      [Example("foo", ' ', 'b', 'g')]
      public void TestParameterConditionAndFailsLower(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         UnsignedNumericValidator<char> validatorBase,
         Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => act = () => validatorBase.IsGreaterThanOrEqualTo(lowerBound).And.IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

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
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'j', 'c', 'g')]
      [Example("foo", 'h', 'c', 'g')]     
      public void TestParameterConditionAndFailsUpper(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         UnsignedNumericValidator<char> validatorBase,
         Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => act = () => validatorBase.IsGreaterThanOrEqualTo(lowerBound).And.IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

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
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [Example("foo", 'c', 'c', 'g')]
      [Example("foo", 'd', 'c', 'g')]
      [Example("foo", 'e', 'c', 'g')]
      [Example("foo", 'f', 'c', 'g')]
      [Example("foo", 'g', 'c', 'g')]
      public void TestParameterConditionAndPasses(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => validatorBase.IsGreaterThanOrEqualTo(lowerBound).And.IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests OR combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'd', 'c', 'g')]
      [Example("foo", 'e', 'c', 'g')]
      [Example("foo", 'f', 'c', 'g')]
      public void TestParameterConditionOrFails(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         UnsignedNumericValidator<char> validatorBase,
         Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the lower bound or greater than or equal to the upper bound"
            .x(() => act = () => validatorBase.IsLessThanOrEqualTo(lowerBound).Or.IsGreaterThanOrEqualTo(upperBound).OtherwiseThrowException());

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
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a', 'c', 'g')]
      [Example("foo", 'b', 'c', 'g')]
      [Example("foo", 'c', 'c', 'g')]
      [Example("foo", 'g', 'c', 'g')]
      [Example("foo", 'h', 'c', 'g')]
      [Example("foo", 'j', 'c', 'g')]
      public void TestParameterConditionOrPasses(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the lower bound or greater than or equal to the upper bound"
            .x(() => validatorBase.IsLessThanOrEqualTo(lowerBound).Or.IsGreaterThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a', 'b')]
      [Example("foo", 'a', 'A')]
      public void TestParameterEqualToFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase,
         Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => act = () => validatorBase.IsEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentEqualityException>()
            .WithMessage(string.Format(Resources.MustBeEqualToX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a', 'a')]
      [Example("foo", 'A', 'A')]
      [Example("foo", '*', '*')]
      public void TestParameterEqualToPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validatorBase.IsEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'b')]
      [Example("foo", 'a', 'a')]
      public void TestParameterGreaterThanFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase,
         Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than the value to compare against"
            .x(() => act = () => validatorBase.IsGreaterThan(valueToCompare).OtherwiseThrowException());

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
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'b')]
      public void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase,
         Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => act = () => validatorBase.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

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
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [Example("foo", 'b', 'C')]
      [Example("foo", 'b', 'a')]
      [Example("foo", 'a', 'a')]
      public void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => validatorBase.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNotPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a')]
      [Example("foo", 'A')]
      public void TestParameterIsNotPositiveFails(string parameterName, char parameterValue, UnsignedNumericValidator<char> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validatorBase.IsNotPositive().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustNotBePositive + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [Example("foo", '\0')]
      public void TestParameterIsNotPositivePasses(string parameterName, char parameterValue, UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validatorBase.IsNotPositive().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", '\0')]
      public void TestParameterIsPositiveFails(string parameterName, char parameterValue, UnsignedNumericValidator<char> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validatorBase.IsPositive().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBePositive + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a')]
      [Example("foo", 'A')]
      [Example("foo", ' ')]
      public void TestParameterIsPositivePasses(string parameterName, char parameterValue, UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validatorBase.IsPositive().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a', '\0')]
      [Example("foo", 'a', 'A')]
      [Example("foo", 'a', 'a')]
      [Example("foo", 'b', 'a')]
      public void TestParameterLessThanFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase,
         Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validatorBase.IsLessThan(valueToCompare).OtherwiseThrowException());

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
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a', '\0')]
      [Example("foo", 'a', 'A')]
      [Example("foo", 'b', 'a')]
      public void TestParameterLessThanOrEqualToFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase,
         Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the value to compare against"
            .x(() => act = () => validatorBase.IsLessThanOrEqualTo(valueToCompare).OtherwiseThrowException());

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
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [Example("foo", '\0', 'a')]
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'a')]
      [Example("foo", 'a', 'b')]
      public void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the value to compare against"
            .x(() => validatorBase.IsLessThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [Example("foo", '\0', 'a')]
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'b')]
      public void TestParameterLessThanPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => validatorBase.IsLessThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a', 'a')]
      [Example("foo", 'A', 'A')]
      [Example("foo", '\0', '\0')]
      public void TestParameterNotEqualToFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase,
         Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => act = () => validatorBase.IsNotEqualTo(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentEqualityException>()
            .WithMessage(string.Format(Resources.MustNotBeEqualToX + "\r\nParameter name: {1}", valueToCompare, parameterName)));
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="UnsignedNumericValidator{Char}" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a', 'A')]
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'b')]
      [Example("foo", '\0', ' ')]
      public void TestParameterNotEqualToPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         UnsignedNumericValidator<char> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validatorBase.IsNotEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }
   }
}