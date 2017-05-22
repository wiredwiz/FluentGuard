#region Apache License 2.0

// <copyright file="IntegerValidatorTests.cs" company="Edgerunner.org">
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
   ///    Class that tests the IntegerValidator.
   /// </summary>
   /// <seealso cref="int" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class IntegerValidatorTests
   {
      /// <summary>
      /// Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 5, 2)]
      [Example("foo", 2, 2)]
      [Example("foo", 3, 2)]
      public virtual void TestParameterLessThanFails(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase, Action act)
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
      /// Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 5)]
      [Example("foo", 2, 3)]
      [Example("foo", 0, 2)]
      public virtual void TestParameterLessThanPasses(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => validatorBase.IsLessThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests less than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>      
      [Scenario]
      [Example("foo", 5, 2)]
      [Example("foo", 3, 2)]
      [Example("foo", 1, 0)]
      public virtual void TestParameterLessThanOrEqualToFails(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase, Action act)
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
      /// Tests less than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>     
      [Scenario]
      [Example("foo", 2, 5)]
      [Example("foo", 2, 3)]
      [Example("foo", 1, 1)]
      [Example("foo", 0, 1)]
      public virtual void TestParameterLessThanOrEqualToPasses(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the value to compare against"
            .x(() => validatorBase.IsLessThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>      
      [Scenario]
      [Example("foo", 2, 4)]
      [Example("foo", 2, 2)]
      [Example("foo", 0, 1)]
      public virtual void TestParameterGreaterThanFails(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase, Action act)
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
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>     
      [Scenario]
      [Example("foo", 9, 2)]
      [Example("foo", 4, 2)]
      [Example("foo", 1, 0)]
      public virtual void TestParameterGreaterThanPasses(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than the value to compare against"
            .x(() => validatorBase.IsGreaterThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>      
      [Scenario]
      [Example("foo", 2, 6)]
      [Example("foo", 1, 2)]
      [Example("foo", 2, 4)]
      public virtual void TestParameterGreaterThanOrEqualToFails(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase, Action act)
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
      /// Tests greater than or equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>      
      [Scenario]
      [Example("foo", 4, 2)]
      [Example("foo", 3, 2)]
      [Example("foo", 1, 1)]
      [Example("foo", 1, 0)]
      public virtual void TestParameterGreaterThanOrEqualToPasses(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => validatorBase.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>    
      [Scenario]
      [Example("foo", 2, 6)]
      [Example("foo", 1, 2)]
      [Example("foo", 2, 1)]
      [Example("foo", 4, 2)]
      public virtual void TestParameterEqualToFails(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase, Action act)
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
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>      
      [Scenario]
      [Example("foo", 0, 0)]
      [Example("foo", 1, 1)]
      [Example("foo", -1, -1)]
      public virtual void TestParameterEqualToPasses(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validatorBase.IsEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>     
      [Scenario]
      [Example("foo", 2, 2)]
      [Example("foo", 1, 1)]
      [Example("foo", 0, 0)]
      [Example("foo", -4, -4)]
      public virtual void TestParameterNotEqualToFails(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase, Action act)
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
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>     
      [Scenario]
      [Example("foo", 0, 1)]
      [Example("foo", 0, -1)]
      [Example("foo", 1, 2)]
      [Example("foo", -1, 2)]
      public virtual void TestParameterNotEqualToPasses(string parameterName, int parameterValue, int valueToCompare, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validatorBase.IsNotEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 1, 2, 5)]
      public virtual void TestParameterConditionAndFailsLower(string parameterName, int parameterValue, int lowerBound, int upperBound, NumericValidator<int> validatorBase, Action act)
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
      /// Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 8, 2, 5)]
      public virtual void TestParameterConditionAndFailsUpper(string parameterName, int parameterValue, int lowerBound, int upperBound, NumericValidator<int> validatorBase, Action act)
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
      /// Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 2, 5)]
      [Example("foo", 4, 2, 5)]
      [Example("foo", 5, 2, 5)]
      public virtual void TestParameterConditionAndPasses(string parameterName, int parameterValue, int lowerBound, int upperBound, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater or equal to the lower bound and less than or equal to the upper bound"
            .x(() => validatorBase.IsGreaterThanOrEqualTo(lowerBound).And.IsLessThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests OR combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>      
      [Scenario]
      [Example("foo", 3, 2, 6)]
      [Example("foo", 4, 2, 6)]
      [Example("foo", 5, 2, 6)]
      public virtual void TestParameterConditionOrFails(string parameterName, int parameterValue, int lowerBound, int upperBound, NumericValidator<int> validatorBase, Action act)
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
      /// Tests OR combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      [Scenario]
      [Example("foo", 2, 2, 5)]
      [Example("foo", 1, 2, 5)]
      [Example("foo", 0, 2, 5)]
      [Example("foo", 5, 2, 5)]
      [Example("foo", 6, 2, 5)]
      [Example("foo", 9, 2, 5)]
      public virtual void TestParameterConditionOrPasses(string parameterName, int parameterValue, int lowerBound, int upperBound, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than or equal to the lower bound or greater than or equal to the upper bound"
            .x(() => validatorBase.IsLessThanOrEqualTo(lowerBound).Or.IsGreaterThanOrEqualTo(upperBound).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", -0.001)]
      [Example("foo", -1)]
      public virtual void TestParameterIsPositiveFails(string parameterName, int parameterValue, NumericValidator<int> validatorBase, Action act)
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
      /// Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      [Scenario]
      [Example("foo", 1)]
      [Example("foo", 4)]
      public virtual void TestParameterIsPositivePasses(string parameterName, int parameterValue, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validatorBase.IsPositive().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests IsNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", 1)]
      public virtual void TestParameterIsNegativeFails(string parameterName, int parameterValue, NumericValidator<int> validatorBase, Action act)
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
      /// Tests IsNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      [Scenario]
      [Example("foo", -1)]
      [Example("foo", -4)]
      public virtual void TestParameterIsNegativePasses(string parameterName, int parameterValue, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validatorBase.IsNegative().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", -1)]
      [Example("foo", -4)]
      public virtual void TestParameterIsNotNegativeFails(string parameterName, int parameterValue, NumericValidator<int> validatorBase, Action act)
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
      /// Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", 1)]
      [Example("foo", 4)]
      public virtual void TestParameterIsNotNegativePasses(string parameterName, int parameterValue, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validatorBase.IsNotNegative().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests IsNotPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 1)]
      [Example("foo", 4)]
      public virtual void TestParameterIsNotPositiveFails(string parameterName, int parameterValue, NumericValidator<int> validatorBase, Action act)
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
      /// Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NumericValidator{Integer}" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", -1)]
      [Example("foo", -4)]
      public virtual void TestParameterIsNotPositivePasses(string parameterName, int parameterValue, NumericValidator<int> validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validatorBase.IsNotPositive().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }
   }
}