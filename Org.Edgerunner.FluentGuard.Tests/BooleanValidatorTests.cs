#region Apache License 2.0

// <copyright file="BooleanValidatorTests.cs" company="Edgerunner.org">
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
using FluentAssertions;
using Org.Edgerunner.FluentGuard.Exceptions;
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   /// Class BooleanValidatorTests.
   /// </summary>
   public class BooleanValidatorTests
   {
      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      public void TestParameterEqualToFails(string parameterName, bool parameterValue, bool valueToCompare, BooleanValidator validator, Action act)
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
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      public void TestParameterEqualToWithCustomExceptionFails(string parameterName, bool parameterValue, bool valueToCompare, BooleanValidator validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against and throwing a custom exception if not"
            .x(() => act = () => validator.IsEqualTo(valueToCompare).OtherwiseThrow(new ArgumentException("Some nonsense message", parameterName)));

         "Should result in that custom exception being thrown"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format("Some nonsense message\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public void TestParameterEqualToWithCustomExceptionPasses(string parameterName, bool parameterValue, bool valueToCompare, BooleanValidator validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against and throwing a custom exception if not"
            .x(() => validator.IsEqualTo(valueToCompare).OtherwiseThrow(new ArgumentException("Some nonsense message", parameterName)));

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>      
      [Scenario]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public void TestParameterEqualToPasses(string parameterName, bool parameterValue, bool valueToCompare, BooleanValidator validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validator.IsEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public void TestParameterNotEqualToFails(string parameterName, bool parameterValue, bool valueToCompare, BooleanValidator validator, Action act)
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
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      public void TestParameterNotEqualToPasses(string parameterName, bool parameterValue, bool valueToCompare, BooleanValidator validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validator.IsNotEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }
      
      /// <summary>
      /// Tests IsTrue validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", false)]
      public void TestParameterIsTrueFails(string parameterName, bool parameterValue, BooleanValidator validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is true"
            .x(() => act = () => validator.IsTrue().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Resources.MustBeTrue + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests IsTrue validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      public void TestParameterIsTruePasses(string parameterName, bool parameterValue, BooleanValidator validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is true"
            .x(() => validator.IsTrue().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests IsFalse validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      public void TestParameterIsFalseFails(string parameterName, bool parameterValue, BooleanValidator validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validator.IsFalse().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Resources.MustBeFalse + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests IsFalse validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="BooleanValidator" /> to test with.</param>
      [Scenario]
      [Example("foo", false)]
      public void TestParameterIsFalsePasses(string parameterName, bool parameterValue, BooleanValidator validator)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validator.IsFalse().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }      
   }
}
