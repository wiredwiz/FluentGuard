#region Apache License 2.0

// <copyright file="NullableSByteValidatorTests.cs" company="Edgerunner.org">
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
using Org.Edgerunner.FluentGuard.Tests.Data;
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class that tests the NullableSByteVaildator.
   /// </summary>
   /// <seealso cref="sbyte" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class NullableSByteValidatorTests
   {
      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>     
      [Scenario]
      [NullableSByteExample("foo1", 9, 2)]
      [NullableSByteExample("foo2", 4, 2)]
      [NullableSByteExample("foo3", 1, 0)]
      [NullableSByteExample("foo4", 0, -1)]
      [NullableSByteExample("foo5", -128, null)]
      public void TestParameterGreaterThanPasses(string parameterName, sbyte? parameterValue, sbyte? valueToCompare, NullableNumericValidator<sbyte> validator)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 1, 2, 5)]
      [NullableSByteExample("foo2", -3, 0, 5)]
      [NullableSByteExample("foo3", null, 0, 5)]
      public void TestParameterConditionAndFailsLower(
         string parameterName,
         sbyte? parameterValue,
         sbyte? lowerBound,
         sbyte? upperBound,
         NullableNumericValidator<sbyte> validator,
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 8, 2, 5)]
      [NullableSByteExample("foo2", -2, -8, -5)]
      public void TestParameterConditionAndFailsUpper(
         string parameterName,
         sbyte? parameterValue,
         sbyte? lowerBound,
         sbyte? upperBound,
         NullableNumericValidator<sbyte> validator,
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 2, 2, 5)]
      [NullableSByteExample("foo2", 4, 2, 5)]
      [NullableSByteExample("foo3", 5, 2, 5)]
      [NullableSByteExample("foo4", 0, -6, 0)]
      public void TestParameterConditionAndPasses(
         string parameterName,
         sbyte? parameterValue,
         sbyte? lowerBound,
         sbyte? upperBound,
         NullableNumericValidator<sbyte> validator)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 3, 2, 6)]
      [NullableSByteExample("foo2", 4, 2, 6)]
      [NullableSByteExample("foo3", 5, 2, 6)]
      [NullableSByteExample("foo4", -5, -6, -2)]
      public void TestParameterConditionOrFails(
         string parameterName,
         sbyte? parameterValue,
         sbyte? lowerBound,
         sbyte? upperBound,
         NullableNumericValidator<sbyte> validator,
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 2, 2, 5)]
      [NullableSByteExample("foo2", 1, 2, 5)]
      [NullableSByteExample("foo3", 0, 2, 5)]
      [NullableSByteExample("foo4", 5, 2, 5)]
      [NullableSByteExample("foo5", 6, 2, 5)]
      [NullableSByteExample("foo6", 9, 2, 5)]
      public void TestParameterConditionOrPasses(
         string parameterName,
         sbyte? parameterValue,
         sbyte? lowerBound,
         sbyte? upperBound,
         NullableNumericValidator<sbyte> validator)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 2, 6)]
      [NullableSByteExample("foo2", 1, 2)]
      [NullableSByteExample("foo3", 2, 1)]
      [NullableSByteExample("foo4", 4, 2)]
      [NullableSByteExample("foo5", -1, -2)]
      [NullableSByteExample("foo6", 0, null)]
      public void TestParameterEqualToFails(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => act = () => validator.IsEqualTo(valueToCompare).OtherwiseThrowException());

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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 0, 0)]
      [NullableSByteExample("foo2", 1, 1)]
      [NullableSByteExample("foo3", -1, -1)]
      [NullableSByteExample("foo4", null, null)]
      public void TestParameterEqualToPasses(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 2, 4)]
      [NullableSByteExample("foo2", -5, 3)]
      [NullableSByteExample("foo3", 2, 2)]
      [NullableSByteExample("foo4", 0, 1)]
      [NullableSByteExample("foo5", null, -128)]
      public void TestParameterGreaterThanFails(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator,
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 2, 6)]
      [NullableSByteExample("foo2", 1, 2)]
      [NullableSByteExample("foo3", 2, 4)]
      [NullableSByteExample("foo4", null, -128)]
      public void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator,
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 4, 2)]
      [NullableSByteExample("foo2", 3, 2)]
      [NullableSByteExample("foo3", 1, 1)]
      [NullableSByteExample("foo4", 1, 0)]
      [NullableSByteExample("foo5", 0, -1)]
      [NullableSByteExample("foo6", 0, 0)]
      [NullableSByteExample("foo7", -8, -8)]
      [NullableSByteExample("foo8", null, null)]
      [NullableSByteExample("foo9", -128, null)]
      public void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => validator.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 0)]
      [NullableSByteExample("foo2", 1)]
      [NullableSByteExample("foo3", null)]
      public void TestParameterIsNegativeFails(string parameterName, sbyte? parameterValue, NullableNumericValidator<sbyte> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validator.IsNegative().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeNegative + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", -1)]
      [NullableSByteExample("foo2", -4)]
      public void TestParameterIsNegativePasses(string parameterName, sbyte? parameterValue, NullableNumericValidator<sbyte> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validator.IsNegative().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", -1)]
      [NullableSByteExample("foo2", -4)]
      public void TestParameterIsNotNegativeFails(string parameterName, sbyte? parameterValue, NullableNumericValidator<sbyte> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validator.IsNotNegative().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustNotBeNegative + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 0)]
      [NullableSByteExample("foo2", 1)]
      [NullableSByteExample("foo3", 4)]
      [NullableSByteExample("foo4", null)]
      public void TestParameterIsNotNegativePasses(string parameterName, sbyte? parameterValue, NullableNumericValidator<sbyte> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validator.IsNotNegative().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNotPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 1)]
      [NullableSByteExample("foo2", 4)]
      public void TestParameterIsNotPositiveFails(string parameterName, sbyte? parameterValue, NullableNumericValidator<sbyte> validator, Action act)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 0)]
      [NullableSByteExample("foo2", -1)]
      [NullableSByteExample("foo3", -4)]
      [NullableSByteExample("foo4", null)]
      public void TestParameterIsNotPositivePasses(string parameterName, sbyte? parameterValue, NullableNumericValidator<sbyte> validator)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 0)]
      [NullableSByteExample("foo2", -1)]
      [NullableSByteExample("foo3", null)]
      public void TestParameterIsPositiveFails(string parameterName, sbyte? parameterValue, NullableNumericValidator<sbyte> validator, Action act)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 1)]
      [NullableSByteExample("foo2", 4)]
      public void TestParameterIsPositivePasses(string parameterName, sbyte? parameterValue, NullableNumericValidator<sbyte> validator)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 5, 2)]
      [NullableSByteExample("foo2", 2, 2)]
      [NullableSByteExample("foo3", 3, 2)]
      [NullableSByteExample("foo4", 3, null)]
      public void TestParameterLessThanFails(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator,
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 5, 2)]
      [NullableSByteExample("foo2", 3, 2)]
      [NullableSByteExample("foo3", 1, 0)]
      [NullableSByteExample("foo4", 0, -3)]
      [NullableSByteExample("foo4", -128, null)]
      public void TestParameterLessThanOrEqualToFails(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator,
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 2, 5)]
      [NullableSByteExample("foo2", 1, 1)]
      [NullableSByteExample("foo3", -1, -1)]
      [NullableSByteExample("foo4", -1, 1)]
      [NullableSByteExample("foo5", 0, 1)]
      [NullableSByteExample("foo6", null, null)]
      [NullableSByteExample("foo7", null, -128)]
      public void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 2, 5)]
      [NullableSByteExample("foo2", 2, 3)]
      [NullableSByteExample("foo3", -1, 1)]
      [NullableSByteExample("foo4", 0, 2)]
      [NullableSByteExample("foo5", null, -128)]
      public void TestParameterLessThanPasses(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator)
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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 2, 2)]
      [NullableSByteExample("foo2", 1, 1)]
      [NullableSByteExample("foo3", 0, 0)]
      [NullableSByteExample("foo4", -4, -4)]
      [NullableSByteExample("foo5", null, null)]
      public void TestParameterNotEqualToFails(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator,
         Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => act = () => validator.IsNotEqualTo(valueToCompare).OtherwiseThrowException());

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
      /// <param name="validator">The <see cref="NullableNumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [NullableSByteExample("foo1", 0, 1)]
      [NullableSByteExample("foo2", 0, -1)]
      [NullableSByteExample("foo3", 1, 2)]
      [NullableSByteExample("foo4", -1, 2)]
      [NullableSByteExample("foo5", 0, null)]
      public void TestParameterNotEqualToPasses(
         string parameterName,
         sbyte? parameterValue,
         sbyte? valueToCompare,
         NullableNumericValidator<sbyte> validator)
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