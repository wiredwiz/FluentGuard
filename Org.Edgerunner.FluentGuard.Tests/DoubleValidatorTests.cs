#region Apache License 2.0

// <copyright file="DoubleValidatorTests.cs" company="Edgerunner.org">
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
   ///    Class DoubleValidatorTests.
   /// </summary>
   /// <seealso cref="double" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class DoubleValidatorTests
   {
      /// <summary>
      ///    Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 1, 2, 5)]
      [Example("foo", 1.9999, 2, 5)]
      public void TestParameterConditionAndFailsLower(
         string parameterName,
         double parameterValue,
         double lowerBound,
         double upperBound,
         NumericValidator<double> validator,
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 8, 2, 5)]
      [Example("foo", 5.000001, 2, 5)]
      public void TestParameterConditionAndFailsUpper(
         string parameterName,
         double parameterValue,
         double lowerBound,
         double upperBound,
         NumericValidator<double> validator,
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 2, 5)]
      [Example("foo", 2.00001, 2, 5)]
      [Example("foo", 4, 2, 5)]
      [Example("foo", 5, 2, 5)]
      public void TestParameterConditionAndPasses(
         string parameterName,
         double parameterValue,
         double lowerBound,
         double upperBound,
         NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 3, 2, 6)]
      [Example("foo", 2.0001, 2, 6)]
      [Example("foo", 4, 2, 6)]
      [Example("foo", 5, 2, 6)]
      public void TestParameterConditionOrFails(
         string parameterName,
         double parameterValue,
         double lowerBound,
         double upperBound,
         NumericValidator<double> validator,
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 2, 5)]
      [Example("foo", 1, 2, 5)]
      [Example("foo", 1.9999999, 2, 5)]
      [Example("foo", 0, 2, 5)]
      [Example("foo", 5, 2, 5)]
      [Example("foo", 6, 2, 5)]
      [Example("foo", 9, 2, 5)]
      public void TestParameterConditionOrPasses(
         string parameterName,
         double parameterValue,
         double lowerBound,
         double upperBound,
         NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 6)]
      [Example("foo", 1, 2)]
      [Example("foo", 2, 1)]
      [Example("foo", 4, 2)]
      [Example("foo", 3.9999999999, 4)]
      public void TestParameterEqualToFails(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator,
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 0, 0)]
      [Example("foo", 0.42218936299, 0.42218936299)]
      [Example("foo", 1, 1)]
      [Example("foo", -1, -1)]
      public void TestParameterEqualToPasses(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 4)]
      [Example("foo", 2, 2)]
      [Example("foo", 0, 1)]
      public void TestParameterGreaterThanFails(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator,
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
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>     
      [Scenario]
      [Example("foo", 9, 2)]
      [Example("foo", 4, 2)]
      [Example("foo", 1, 0)]
      [Example("foo", 0.0000000001, 0)]
      public void TestParameterGreaterThanPasses(string parameterName, double parameterValue, double valueToCompare, NumericValidator<double> validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than the value to compare against"
            .x(() => validator.IsGreaterThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 6)]
      [Example("foo", 1, 2)]
      [Example("foo", 1.999999999, 2)]
      [Example("foo", 2, 4)]
      public void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator,
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 4, 2)]
      [Example("foo", 3, 2)]
      [Example("foo", 1, 1)]
      [Example("foo", 1, 0)]
      public void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", 1)]
      [Example("foo", 1.00001)]
      public void TestParameterIsNegativeFails(string parameterName, double parameterValue, NumericValidator<double> validator, Action act)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", -0.0000001)]
      [Example("foo", -1)]
      [Example("foo", -4)]
      public void TestParameterIsNegativePasses(string parameterName, double parameterValue, NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", -1)]
      [Example("foo", -4)]
      public void TestParameterIsNotNegativeFails(string parameterName, double parameterValue, NumericValidator<double> validator, Action act)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", 1)]
      [Example("foo", 4)]
      public void TestParameterIsNotNegativePasses(string parameterName, double parameterValue, NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 1)]
      [Example("foo", 4)]
      public void TestParameterIsNotPositiveFails(string parameterName, double parameterValue, NumericValidator<double> validator, Action act)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", -1)]
      [Example("foo", -4)]
      public void TestParameterIsNotPositivePasses(string parameterName, double parameterValue, NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", -0.001)]
      [Example("foo", -1)]
      public void TestParameterIsPositiveFails(string parameterName, double parameterValue, NumericValidator<double> validator, Action act)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 1)]
      [Example("foo", 4)]
      public void TestParameterIsPositivePasses(string parameterName, double parameterValue, NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 5, 2)]
      [Example("foo", 2, 2)]
      [Example("foo", 3, 2)]
      public void TestParameterLessThanFails(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator,
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 5, 2)]
      [Example("foo", 3, 2)]
      [Example("foo", 1, 0)]
      public void TestParameterLessThanOrEqualToFails(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator,
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 5)]
      [Example("foo", 2, 3)]
      [Example("foo", 1, 1)]
      [Example("foo", 0, 1)]
      public void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 5)]
      [Example("foo", 2, 3)]
      [Example("foo", 0, 2)]
      public void TestParameterLessThanPasses(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator)
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 2)]
      [Example("foo", 1, 1)]
      [Example("foo", 0, 0)]
      [Example("foo", -4, -4)]
      public void TestParameterNotEqualToFails(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator,
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
      /// <param name="validator">The <see cref="NumericValidator{Double}" /> to test with.</param>
      [Scenario]
      [Example("foo", 0, 1)]
      [Example("foo", 0, -1)]
      [Example("foo", 1, 2)]
      [Example("foo", -1, 2)]
      public void TestParameterNotEqualToPasses(
         string parameterName,
         double parameterValue,
         double valueToCompare,
         NumericValidator<double> validator)
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