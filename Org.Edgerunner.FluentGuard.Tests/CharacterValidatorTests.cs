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
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class CharacterValidatorTests.
   /// </summary>
   /// <seealso cref="char" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class CharacterValidatorTests : ValidatorTests<char>
   {
      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>     
      [Scenario]
      [Example("foo", 'a', 'A')]
      [Example("foo", 'b', 'a')]
      public override void TestParameterGreaterThanPasses(string parameterName, char parameterValue, char valueToCompare, Validator<char> validator)
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
      [Example("foo", 'a', 'b', 'g')]
      [Example("foo", ' ', 'b', 'g')]
      public override void TestParameterConditionAndFailsLower(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         Validator<char> validator,
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
      [Example("foo", 'j', 'c', 'g')]
      [Example("foo", 'h', 'c', 'g')]     
      public override void TestParameterConditionAndFailsUpper(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         Validator<char> validator,
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
      [Example("foo", 'c', 'c', 'g')]
      [Example("foo", 'd', 'c', 'g')]
      [Example("foo", 'e', 'c', 'g')]
      [Example("foo", 'f', 'c', 'g')]
      [Example("foo", 'g', 'c', 'g')]
      public override void TestParameterConditionAndPasses(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         Validator<char> validator)
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
      [Example("foo", 'd', 'c', 'g')]
      [Example("foo", 'e', 'c', 'g')]
      [Example("foo", 'f', 'c', 'g')]
      public override void TestParameterConditionOrFails(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         Validator<char> validator,
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
      [Example("foo", 'a', 'c', 'g')]
      [Example("foo", 'b', 'c', 'g')]
      [Example("foo", 'c', 'c', 'g')]
      [Example("foo", 'g', 'c', 'g')]
      [Example("foo", 'h', 'c', 'g')]
      [Example("foo", 'j', 'c', 'g')]
      public override void TestParameterConditionOrPasses(
         string parameterName,
         char parameterValue,
         char lowerBound,
         char upperBound,
         Validator<char> validator)
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
      [Example("foo", 'a', 'b')]
      [Example("foo", 'a', 'A')]
      public override void TestParameterEqualToFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator,
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
      [Example("foo", 'a', 'a')]
      [Example("foo", 'A', 'A')]
      [Example("foo", '*', '*')]
      public override void TestParameterEqualToPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator)
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
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'b')]
      [Example("foo", 'a', 'a')]
      public override void TestParameterGreaterThanFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator,
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
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'b')]
      public override void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator,
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
      [Example("foo", 'b', 'C')]
      [Example("foo", 'b', 'a')]
      [Example("foo", 'a', 'a')]
      public override void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator)
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
      [Example("foo", 'a')]
      [Example("foo", 'A')]
      [Example("foo", '\0')]
      public override void TestParameterIsFalseFails(string parameterName, char parameterValue, Validator<char> validator, Action act)
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
      [Example("foo", 'a')]
      [Example("foo", 'A')]
      [Example("foo", '\0')]
      public override void TestParameterIsNegativeFails(string parameterName, char parameterValue, Validator<char> validator, Action act)
      {
         base.TestParameterIsNegativeFails(parameterName, parameterValue, validator, act);
      }
      
      /// <summary>
      ///    Tests IsNotNegative validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      [Scenario]
      [Example("foo", 'a')]
      [Example("foo", 'A')]
      [Example("foo", '\0')]
      public override void TestParameterIsNotNegativePasses(string parameterName, char parameterValue, Validator<char> validator)
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
      [Example("foo", 'a')]
      [Example("foo", 'A')]
      public override void TestParameterIsNotPositiveFails(string parameterName, char parameterValue, Validator<char> validator, Action act)
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
      [Example("foo", '\0')]
      public override void TestParameterIsNotPositivePasses(string parameterName, char parameterValue, Validator<char> validator)
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
      [Example("foo", '\0')]
      public override void TestParameterIsPositiveFails(string parameterName, char parameterValue, Validator<char> validator, Action act)
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
      [Example("foo", 'a')]
      [Example("foo", 'A')]
      [Example("foo", ' ')]
      public override void TestParameterIsPositivePasses(string parameterName, char parameterValue, Validator<char> validator)
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
      [Example("foo", '\0')]
      [Example("foo", 'a')]
      [Example("foo", 'A')]
      public override void TestParameterIsTrueFails(string parameterName, char parameterValue, Validator<char> validator, Action act)
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
      [Example("foo", 'a', '\0')]
      [Example("foo", 'a', 'A')]
      [Example("foo", 'a', 'a')]
      [Example("foo", 'b', 'a')]
      public override void TestParameterLessThanFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator,
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
      [Example("foo", 'a', '\0')]
      [Example("foo", 'a', 'A')]
      [Example("foo", 'b', 'a')]
      public override void TestParameterLessThanOrEqualToFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator,
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
      [Example("foo", '\0', 'a')]
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'a')]
      [Example("foo", 'a', 'b')]
      public override void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator)
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
      [Example("foo", '\0', 'a')]
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'b')]
      public override void TestParameterLessThanPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator)
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
      [Example("foo", 'a', 'a')]
      [Example("foo", 'A', 'A')]
      [Example("foo", '\0', '\0')]
      public override void TestParameterNotEqualToFails(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator,
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
      [Example("foo", 'a', 'A')]
      [Example("foo", 'A', 'a')]
      [Example("foo", 'a', 'b')]
      [Example("foo", '\0', ' ')]
      public override void TestParameterNotEqualToPasses(
         string parameterName,
         char parameterValue,
         char valueToCompare,
         Validator<char> validator)
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
      [Example("foo", '\0')]
      [Example("foo", 'a')]
      [Example("foo", 'A')]
      public override void TestParameterNotNullPasses(string parameterName, char parameterValue, Validator<char> validator)
      {
         base.TestParameterNotNullPasses(parameterName, parameterValue, validator);
      }
   }
}