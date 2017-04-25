#region Apache License 2.0

// <copyright file="ContainerValidatorTests.cs" company="Edgerunner.org">
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
using Org.Edgerunner.FluentGuard.Tests.Models;
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;
using Xunit;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class ContainerValidatorTests.
   /// </summary>
   /// <seealso cref="Container" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class ContainerValidatorTests : ValidatorTests<Container>
   {
      /// <summary>
      /// Tests not null or empty validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", null)]
      public override void TestParameterNotNullOrEmptyFailsNull(string parameterName, Container parameterValue, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is not null or empty"
            .x(() => act = () => validator.IsNotNullOrEmpty().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Resources.MustNotBeNull + "\r\nParameter name: {0}", parameterName)));
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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterStartsWithFails(string parameterName, Container parameterValue, Container valueToCompare, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter starts with a given string"
            .x(() => act = () => validator.StartsWith(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformAStartsWithOp));
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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterStartsWithFailsNull(string parameterName, Container parameterValue, Container nullValue, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter starts with a given string"
            .x(() => act = () => validator.StartsWith(null).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformAStartsWithOp));
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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterEndsWithFails(string parameterName, Container parameterValue, Container valueToCompare, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter ends with a given string"
            .x(() => act = () => validator.EndsWith(valueToCompare).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformAnEndsWithOp));
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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterEndsWithFailsNull(string parameterName, Container parameterValue, Container nullValue, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter ends with a given string"
            .x(() => act = () => validator.EndsWith(nullValue).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<InvalidOperationException>()
            .WithMessage(Resources.UnableToPerformAnEndsWithOp));
      }

      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>     
      [Scenario]
      [MemberData(nameof(ContainerData.IsGreaterThan), MemberType = typeof(ContainerData))]
      public override void TestParameterGreaterThanPasses(string parameterName, Container parameterValue, Container valueToCompare, Validator<Container> validator)
      {
         base.TestParameterGreaterThanPasses(parameterName, parameterValue, valueToCompare, validator);
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
      [MemberData(nameof(ContainerData.IsNotEqualTo), MemberType = typeof(ContainerData))]
      public override void TestParameterEqualToFails(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator,
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
      [MemberData(nameof(ContainerData.IsEqualTo), MemberType = typeof(ContainerData))]
      public override void TestParameterEqualToPasses(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator)
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
      [MemberData(nameof(ContainerData.IsLessThanOrEqualTo), MemberType = typeof(ContainerData))]
      public override void TestParameterGreaterThanFails(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator,
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
      [MemberData(nameof(ContainerData.IsLessThan), MemberType = typeof(ContainerData))]
      public override void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator,
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
      [MemberData(nameof(ContainerData.IsGreaterThanOrEqualTo), MemberType = typeof(ContainerData))]
      public override void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator)
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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterIsFalseFails(string parameterName, Container parameterValue, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterIsNegativeFails(string parameterName, Container parameterValue, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterIsNotNegativeFails(string parameterName, Container parameterValue, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsNegative().OtherwiseThrowException());

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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterIsNotPositiveFails(string parameterName, Container parameterValue, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsNegative().OtherwiseThrowException());

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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterIsPositiveFails(string parameterName, Container parameterValue, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is less than the value to compare against"
            .x(() => act = () => validator.IsNegative().OtherwiseThrowException());

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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterIsTrueFails(string parameterName, Container parameterValue, Validator<Container> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

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
      [MemberData(nameof(ContainerData.IsGreaterThanOrEqualTo), MemberType = typeof(ContainerData))]
      public override void TestParameterLessThanFails(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator,
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
      [MemberData(nameof(ContainerData.IsGreaterThan), MemberType = typeof(ContainerData))]
      public override void TestParameterLessThanOrEqualToFails(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator,
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
      [MemberData(nameof(ContainerData.IsLessThanOrEqualTo), MemberType = typeof(ContainerData))]
      public override void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator)
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
      [MemberData(nameof(ContainerData.IsLessThan), MemberType = typeof(ContainerData))]
      public override void TestParameterLessThanPasses(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator)
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
      [MemberData(nameof(ContainerData.IsEqualTo), MemberType = typeof(ContainerData))]
      public override void TestParameterNotEqualToFails(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator,
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
      [MemberData(nameof(ContainerData.IsNotEqualTo), MemberType = typeof(ContainerData))]
      public override void TestParameterNotEqualToPasses(
         string parameterName,
         Container parameterValue,
         Container valueToCompare,
         Validator<Container> validator)
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
      [MemberData(nameof(ContainerData.RandomContainerValues), MemberType = typeof(ContainerData))]
      public override void TestParameterNotNullPasses(string parameterName, Container parameterValue, Validator<Container> validator)
      {
         base.TestParameterNotNullPasses(parameterName, parameterValue, validator);
      }

      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="Validator{T}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ContainerData.IsNull), MemberType = typeof(ContainerData))]
      public override void TestParameterNotNullFails(string parameterName, Container parameterValue, Validator<Container> validator, Action act)
      {
         base.TestParameterNotNullFails(parameterName, parameterValue, validator, act);
      }
   }
}