#region Apache License 2.0

// <copyright file="ShortValidatorTests.cs" company="Edgerunner.org">
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
   ///    Class ShortValidatorTests.
   /// </summary>
   /// <seealso cref="short" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class ShortValidatorTests : ValidatorTests<short>
   {
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
      public override void TestParameterGreaterThanPasses(string parameterName, short parameterValue, short valueToCompare, Validator<short> validator)
      {
         base.TestParameterGreaterThanPasses(parameterName, parameterValue, valueToCompare, validator);
      }

      /// <summary>
      ///    Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 1, 2, 5)]
      public override void TestParameterConditionAndFailsLower(
         string parameterName,
         short parameterValue,
         short lowerBound,
         short upperBound,
         Validator<short> validator,
         Action act)
      {
         base.TestParameterConditionAndFailsLower(parameterName, parameterValue, lowerBound, upperBound, validator, act);
      }

      /// <summary>
      ///    Tests AND combining in validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="lowerBound">The lower bound.</param>
      /// <param name="upperBound">The upper bound.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 8, 2, 5)]
      public override void TestParameterConditionAndFailsUpper(
         string parameterName,
         short parameterValue,
         short lowerBound,
         short upperBound,
         Validator<short> validator,
         Action act)
      {
         base.TestParameterConditionAndFailsUpper(parameterName, parameterValue, lowerBound, upperBound, validator, act);
      }

      /// <summary>
      ///    Tests AND combining in validation.
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
      public override void TestParameterConditionAndPasses(
         string parameterName,
         short parameterValue,
         short lowerBound,
         short upperBound,
         Validator<short> validator)
      {
         base.TestParameterConditionAndPasses(parameterName, parameterValue, lowerBound, upperBound, validator);
      }

      /// <summary>
      ///    Tests OR combining in validation.
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
      public override void TestParameterConditionOrFails(
         string parameterName,
         short parameterValue,
         short lowerBound,
         short upperBound,
         Validator<short> validator,
         Action act)
      {
         base.TestParameterConditionOrFails(parameterName, parameterValue, lowerBound, upperBound, validator, act);
      }

      /// <summary>
      ///    Tests OR combining in validation.
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
      public override void TestParameterConditionOrPasses(
         string parameterName,
         short parameterValue,
         short lowerBound,
         short upperBound,
         Validator<short> validator)
      {
         base.TestParameterConditionOrPasses(parameterName, parameterValue, lowerBound, upperBound, validator);
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
      [Example("foo", 2, 6)]
      [Example("foo", 1, 2)]
      [Example("foo", 2, 1)]
      [Example("foo", 4, 2)]
      public override void TestParameterEqualToFails(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator,
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
      [Example("foo", 0, 0)]
      [Example("foo", 1, 1)]
      [Example("foo", -1, -1)]
      public override void TestParameterEqualToPasses(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator)
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
      [Example("foo", 2, 4)]
      [Example("foo", 2, 2)]
      [Example("foo", 0, 1)]
      public override void TestParameterGreaterThanFails(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator,
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
      [Example("foo", 2, 6)]
      [Example("foo", 1, 2)]
      [Example("foo", 2, 4)]
      public override void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator,
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
      [Example("foo", 4, 2)]
      [Example("foo", 3, 2)]
      [Example("foo", 1, 1)]
      [Example("foo", 1, 0)]
      public override void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator)
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
      [Example("foo", -1)]
      [Example("foo", 0)]
      [Example("foo", 1)]
      public override void TestParameterIsFalseFails(string parameterName, short parameterValue, Validator<short> validator, Action act)
      {
         "Given a new validator".x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter is true".x(() => act = () => validator.IsTrue().OtherwiseThrowException());

         "Should throw an exception".x(
                                       () =>
                                          act.ShouldThrow<InvalidOperationException>()
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
      [Example("foo", 0)]
      [Example("foo", 1)]
      public override void TestParameterIsNegativeFails(string parameterName, short parameterValue, Validator<short> validator, Action act)
      {
         base.TestParameterIsNegativeFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      ///    Tests IsNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", -1)]
      [Example("foo", -4)]
      public override void TestParameterIsNegativePasses(string parameterName, short parameterValue, Validator<short> validator)
      {
         base.TestParameterIsNegativePasses(parameterName, parameterValue, validator);
      }

      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", -1)]
      [Example("foo", -4)]
      public override void TestParameterIsNotNegativeFails(string parameterName, short parameterValue, Validator<short> validator, Action act)
      {
         base.TestParameterIsNotNegativeFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", 1)]
      [Example("foo", 4)]
      public override void TestParameterIsNotNegativePasses(string parameterName, short parameterValue, Validator<short> validator)
      {
         base.TestParameterIsNotNegativePasses(parameterName, parameterValue, validator);
      }

      /// <summary>
      ///    Tests IsNotPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 1)]
      [Example("foo", 4)]
      public override void TestParameterIsNotPositiveFails(string parameterName, short parameterValue, Validator<short> validator, Action act)
      {
         base.TestParameterIsNotPositiveFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", -1)]
      [Example("foo", -4)]
      public override void TestParameterIsNotPositivePasses(string parameterName, short parameterValue, Validator<short> validator)
      {
         base.TestParameterIsNotPositivePasses(parameterName, parameterValue, validator);
      }

      /// <summary>
      ///    Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", 0)]
      [Example("foo", -0.001)]
      [Example("foo", -1)]
      public override void TestParameterIsPositiveFails(string parameterName, short parameterValue, Validator<short> validator, Action act)
      {
         base.TestParameterIsPositiveFails(parameterName, parameterValue, validator, act);
      }

      /// <summary>
      ///    Tests IsPositive validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 1)]
      [Example("foo", 4)]
      public override void TestParameterIsPositivePasses(string parameterName, short parameterValue, Validator<short> validator)
      {
         base.TestParameterIsPositivePasses(parameterName, parameterValue, validator);
      }

      /// <summary>
      ///    Tests IsTrue validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", -1)]
      [Example("foo", 0)]
      [Example("foo", 1)]
      public override void TestParameterIsTrueFails(string parameterName, short parameterValue, Validator<short> validator, Action act)
      {
         "Given a new validator".x(() => validator = Ensure.That(parameterName, parameterValue));

         "Testing that the parameter is true".x(() => act = () => validator.IsTrue().OtherwiseThrowException());

         "Should throw an exception".x(
                                       () =>
                                          act.ShouldThrow<InvalidOperationException>()
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
      [Example("foo", 5, 2)]
      [Example("foo", 2, 2)]
      [Example("foo", 3, 2)]
      public override void TestParameterLessThanFails(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator,
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
      [Example("foo", 5, 2)]
      [Example("foo", 3, 2)]
      [Example("foo", 1, 0)]
      public override void TestParameterLessThanOrEqualToFails(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator,
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
      [Example("foo", 2, 5)]
      [Example("foo", 2, 3)]
      [Example("foo", 1, 1)]
      [Example("foo", 0, 1)]
      public override void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator)
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
      [Example("foo", 2, 5)]
      [Example("foo", 2, 3)]
      [Example("foo", 0, 2)]
      public override void TestParameterLessThanPasses(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator)
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
      [Example("foo", 2, 2)]
      [Example("foo", 1, 1)]
      [Example("foo", 0, 0)]
      [Example("foo", -4, -4)]
      public override void TestParameterNotEqualToFails(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator,
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
      [Example("foo", 0, 1)]
      [Example("foo", 0, -1)]
      [Example("foo", 1, 2)]
      [Example("foo", -1, 2)]
      public override void TestParameterNotEqualToPasses(
         string parameterName,
         short parameterValue,
         short valueToCompare,
         Validator<short> validator)
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
      [Example("foo", -1)]
      [Example("foo", 0)]
      [Example("foo", 1)]
      public override void TestParameterNotNullPasses(string parameterName, short parameterValue, Validator<short> validator)
      {
         base.TestParameterNotNullPasses(parameterName, parameterValue, validator);
      }
   }
}