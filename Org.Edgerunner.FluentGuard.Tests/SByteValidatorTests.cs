﻿#region Apache License 2.0

// <copyright file="SByteValidatorTests.cs" company="Edgerunner.org">
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
   ///    Class that tests the SByteVaildator
   /// </summary>
   /// <seealso cref="sbyte" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class SByteValidatorTests
   {
      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>     
      [Scenario]
      [Example("foo1", 9, 2)]
      [Example("foo2", 4, 2)]
      [Example("foo3", 1, 0)]
      [Example("foo4", 0, -1)]
      public void TestParameterGreaterThanPasses(string parameterName, sbyte parameterValue, sbyte valueToCompare, NumericValidator<sbyte> validatorBase)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 1, 2, 5)]
      [Example("foo2", -3, 0, 5)]
      public void TestParameterConditionAndFailsLower(
         string parameterName,
         sbyte parameterValue,
         sbyte lowerBound,
         sbyte upperBound,
         NumericValidator<sbyte> validatorBase,
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 8, 2, 5)]
      [Example("foo2", -2, -8, -5)]
      public void TestParameterConditionAndFailsUpper(
         string parameterName,
         sbyte parameterValue,
         sbyte lowerBound,
         sbyte upperBound,
         NumericValidator<sbyte> validatorBase,
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 2, 2, 5)]
      [Example("foo2", 4, 2, 5)]
      [Example("foo3", 5, 2, 5)]
      [Example("foo4", 0, -6, 0)]
      public void TestParameterConditionAndPasses(
         string parameterName,
         sbyte parameterValue,
         sbyte lowerBound,
         sbyte upperBound,
         NumericValidator<sbyte> validatorBase)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 3, 2, 6)]
      [Example("foo2", 4, 2, 6)]
      [Example("foo3", 5, 2, 6)]
      [Example("foo4", -5, -6, -2)]
      public void TestParameterConditionOrFails(
         string parameterName,
         sbyte parameterValue,
         sbyte lowerBound,
         sbyte upperBound,
         NumericValidator<sbyte> validatorBase,
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 2, 2, 5)]
      [Example("foo2", 1, 2, 5)]
      [Example("foo3", 0, 2, 5)]
      [Example("foo4", 5, 2, 5)]
      [Example("foo5", 6, 2, 5)]
      [Example("foo6", 9, 2, 5)]
      public void TestParameterConditionOrPasses(
         string parameterName,
         sbyte parameterValue,
         sbyte lowerBound,
         sbyte upperBound,
         NumericValidator<sbyte> validatorBase)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 2, 6)]
      [Example("foo2", 1, 2)]
      [Example("foo3", 2, 1)]
      [Example("foo4", 4, 2)]
      [Example("foo5", -1, -2)]
      public void TestParameterEqualToFails(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase,
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 0, 0)]
      [Example("foo2", 1, 1)]
      [Example("foo3", -1, -1)]
      public void TestParameterEqualToPasses(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 2, 4)]
      [Example("foo2", -5, 3)]
      [Example("foo3", 2, 2)]
      [Example("foo4", 0, 1)]
      public void TestParameterGreaterThanFails(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase,
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 2, 6)]
      [Example("foo2", 1, 2)]
      [Example("foo3", 2, 4)]
      public void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase,
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 4, 2)]
      [Example("foo2", 3, 2)]
      [Example("foo3", 1, 1)]
      [Example("foo4", 1, 0)]
      [Example("foo5", 0, -1)]
      [Example("foo6", 0, 0)]
      [Example("foo7", -8, -8)]
      public void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => validatorBase.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 0)]
      [Example("foo2", 1)]
      public void TestParameterIsNegativeFails(string parameterName, sbyte parameterValue, NumericValidator<sbyte> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validatorBase.IsNegative().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustBeNegative + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", -1)]
      [Example("foo2", -4)]
      public void TestParameterIsNegativePasses(string parameterName, sbyte parameterValue, NumericValidator<sbyte> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validatorBase.IsNegative().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", -1)]
      [Example("foo2", -4)]
      public void TestParameterIsNotNegativeFails(string parameterName, sbyte parameterValue, NumericValidator<sbyte> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validatorBase.IsNotNegative().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentOutOfRangeException>()
            .WithMessage(string.Format(Resources.MustNotBeNegative + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 0)]
      [Example("foo2", 1)]
      [Example("foo3", 4)]
      public void TestParameterIsNotNegativePasses(string parameterName, sbyte parameterValue, NumericValidator<sbyte> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validatorBase.IsNotNegative().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNotPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 1)]
      [Example("foo2", 4)]
      public void TestParameterIsNotPositiveFails(string parameterName, sbyte parameterValue, NumericValidator<sbyte> validatorBase, Action act)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 0)]
      [Example("foo2", -1)]
      [Example("foo3", -4)]
      public void TestParameterIsNotPositivePasses(string parameterName, sbyte parameterValue, NumericValidator<sbyte> validatorBase)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 0)]
      [Example("foo2", -1)]
      public void TestParameterIsPositiveFails(string parameterName, sbyte parameterValue, NumericValidator<sbyte> validatorBase, Action act)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 1)]
      [Example("foo2", 4)]
      public void TestParameterIsPositivePasses(string parameterName, sbyte parameterValue, NumericValidator<sbyte> validatorBase)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 5, 2)]
      [Example("foo2", 2, 2)]
      [Example("foo3", 3, 2)]
      public void TestParameterLessThanFails(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase,
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 5, 2)]
      [Example("foo2", 3, 2)]
      [Example("foo3", 1, 0)]
      [Example("foo4", 0, -3)]
      public void TestParameterLessThanOrEqualToFails(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase,
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 2, 5)]
      [Example("foo2", 2, 3)]
      [Example("foo3", 1, 1)]
      [Example("foo4", -1, -1)]
      [Example("foo5", -1, 1)]
      [Example("foo6", 0, 1)]
      public void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 2, 5)]
      [Example("foo2", 2, 3)]
      [Example("foo3", -1, 1)]
      [Example("foo4", 0, 2)]
      public void TestParameterLessThanPasses(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase)
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", 2, 2)]
      [Example("foo2", 1, 1)]
      [Example("foo3", 0, 0)]
      [Example("foo4", -4, -4)]
      public void TestParameterNotEqualToFails(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase,
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
      /// <param name="validatorBase">The <see cref="NumericValidator{Sbyte}" /> to test with.</param>
      [Scenario]
      [Example("foo1", 0, 1)]
      [Example("foo2", 0, -1)]
      [Example("foo3", 1, 2)]
      [Example("foo4", -1, 2)]
      public void TestParameterNotEqualToPasses(
         string parameterName,
         sbyte parameterValue,
         sbyte valueToCompare,
         NumericValidator<sbyte> validatorBase)
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