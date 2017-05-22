#region Apache License 2.0
// <copyright company="Edgerunner.org" file="NullableBooleanValidator.cs">
// Copyright (c)  2017
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
   /// Class NullableBooleanValidatorTests.
   /// </summary>
   public class NullableBooleanValidatorTests
   {
      /// <summary>
      /// Tests equal to validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="valueToCompare">The value to compare.</param>
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      public void TestParameterEqualToFails(string parameterName, bool? parameterValue, bool? valueToCompare, NullableBooleanValidator validatorBase, Action act)
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
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>      
      [Scenario]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public void TestParameterEqualToPasses(string parameterName, bool? parameterValue, bool? valueToCompare, NullableBooleanValidator validatorBase)
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
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, true)]
      [Example("foo", false, false)]
      public void TestParameterNotEqualToFails(string parameterName, bool? parameterValue, bool? valueToCompare, NullableBooleanValidator validatorBase, Action act)
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
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>     
      [Scenario]
      [Example("foo", true, false)]
      [Example("foo", false, true)]
      public void TestParameterNotEqualToPasses(string parameterName, bool? parameterValue, bool? valueToCompare, NullableBooleanValidator validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter value is equal to the value to compare against"
            .x(() => validatorBase.IsNotEqualTo(valueToCompare).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }
      
      /// <summary>
      /// Tests IsTrue validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", false)]
      public void TestParameterIsTrueFails(string parameterName, bool? parameterValue, NullableBooleanValidator validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is true"
            .x(() => act = () => validatorBase.IsTrue().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Resources.MustBeTrue + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests IsTrue validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      public void TestParameterIsTruePasses(string parameterName, bool? parameterValue, NullableBooleanValidator validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is true"
            .x(() => validatorBase.IsTrue().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests IsFalse validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      public void TestParameterIsFalseFails(string parameterName, bool? parameterValue, NullableBooleanValidator validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => act = () => validatorBase.IsFalse().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Resources.MustBeFalse + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests IsFalse validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      [Scenario]
      [Example("foo", false)]
      public void TestParameterIsFalsePasses(string parameterName, bool? parameterValue, NullableBooleanValidator validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is false"
            .x(() => validatorBase.IsFalse().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo", null)]
      public virtual void TestParameterNotNullFails(string parameterName, bool? parameterValue, NullableBooleanValidator validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is not null"
            .x(() => act = () => validatorBase.IsNotNull().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Properties.Resources.MustNotBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      [Scenario]
      [Example("foo", true)]
      [Example("foo", false)]
      public virtual void TestParameterNotNullPasses(string parameterName, bool? parameterValue, NullableBooleanValidator validatorBase)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is not null"
            .x(() => validatorBase.IsNotNull().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNull validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public void TestParameterIsNullPasses(string parameterName, bool? parameterValue, NullableBooleanValidator validatorBase)
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
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", true)]
      [Example("foo2", false)]
      public void TestParameterIsNullFails(string parameterName, bool? parameterValue, NullableBooleanValidator validatorBase, Action act)
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