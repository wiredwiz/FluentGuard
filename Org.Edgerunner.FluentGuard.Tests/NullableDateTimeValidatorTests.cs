#region Apache License 2.0

// <copyright file="NullableDateTimeValidatorTests.cs" company="Edgerunner.org">
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
using Xunit;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   /// Class NullableDateTimeValidatorTests.
   /// </summary>
   /// <seealso cref="DateTime" />
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]

   // ReSharper disable once ClassTooBig
   public class NullableDateTimeValidatorTests
   {
      /// <summary>
      /// Tests greater than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>     
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsGreaterThan), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterGreaterThanPasses(string parameterName, DateTime? parameterValue, DateTime? valueToCompare, NullableDateTimeValidator validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than the value to compare against"
            .x(() => validatorBase.IsGreaterThan(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsNotEqualTo), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterEqualToFails(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase,
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
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsEqualTo), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterEqualToPasses(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase)
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
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsLessThanOrEqualTo), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterGreaterThanFails(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase,
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
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsLessThan), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterGreaterThanOrEqualToFails(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase,
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
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsGreaterThanOrEqualTo), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterGreaterThanOrEqualToPasses(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is greater than or equal to the value to compare against"
            .x(() => validatorBase.IsGreaterThanOrEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests less than validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsGreaterThanOrEqualTo), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterLessThanFails(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase,
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
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsGreaterThan), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterLessThanOrEqualToFails(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase,
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
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsLessThanOrEqualTo), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterLessThanOrEqualToPasses(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase)
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
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsLessThan), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterLessThanPasses(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase)
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
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsEqualTo), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterNotEqualToFails(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase,
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
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.IsNotEqualTo), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterNotEqualToPasses(
         string parameterName,
         DateTime? parameterValue,
         DateTime? valueToCompare,
         NullableDateTimeValidator validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validatorBase.IsNotEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.RandomDateValues), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterNotNullPasses(string parameterName, DateTime? parameterValue, NullableDateTimeValidator validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is not null"
            .x(() => validatorBase.IsNotNull().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public void TestParameterNotNullFails(string parameterName, DateTime? parameterValue, NullableDateTimeValidator validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is not null"
            .x(() => act = () => validatorBase.IsNotNull().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Resources.MustNotBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsNull validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public void TestParameterIsNullPasses(string parameterName, DateTime? parameterValue, NullableDateTimeValidator validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is null"
            .x(() => validatorBase.IsNull().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNull validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableDateTimeValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(NullableDateTimeData.RandomDateValues), MemberType = typeof(NullableDateTimeData))]
      public void TestParameterIsNullFails(string parameterName, DateTime? parameterValue, NullableDateTimeValidator validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is null"
            .x(() => act = () => validatorBase.IsNull().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Resources.MustBeNull + "\r\nParameter name: {0}", parameterName)));
      }
   }
}