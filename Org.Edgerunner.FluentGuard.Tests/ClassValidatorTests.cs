#region Apache License 2.0
// <copyright company="Edgerunner.org" file="ClassValidatorTests.cs">
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
using System.Text;
using FluentAssertions;
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.FluentGuard.Tests.Data;
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class that tests the ClassValidator.
   /// </summary>
   public class ClassValidatorTests
   {
      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="ClassValidator{StringBuilder}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      public virtual void TestParameterNotNullFails(string parameterName, StringBuilder parameterValue, ClassValidator<StringBuilder> validator, Action act)
      {
         "Given a null StringBuilder"
            .x(() => parameterValue = null);

         "And given a new validator"
            .x(() => validator = Validate.That("foo", parameterValue));

         "Testing that the parameter is not null"
            .x(() => act = () => validator.IsNotNull().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(Resources.MustNotBeNull + "\r\nParameter name: foo"));
      }

      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableBooleanValidator" /> to test with.</param>
      [Scenario]
      public virtual void TestParameterNotNullPasses(string parameterName, StringBuilder parameterValue, ClassValidator<StringBuilder> validator)
      {
         "Given a new StringBuilder"
            .x(() => parameterValue = new StringBuilder());

         "And given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is not null"
            .x(() => validator.IsNotNull().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNull validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="ClassValidator{StringBuilder}" /> to test with.</param>
      [Scenario]
      public void TestParameterIsNullPasses(string parameterName, StringBuilder parameterValue, ClassValidator<StringBuilder> validator)
      {
         "Given a null StringBuilder"
            .x(() => parameterValue = null);

         "And given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is null"
            .x(() => validator.IsNull().OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests IsNull validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="ClassValidator{StringBuilder}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      public void TestParameterIsNullFails(string parameterName, StringBuilder parameterValue, ClassValidator<StringBuilder> validator, Action act)
      {
         "Given a new StringBuilder"
            .x(() => parameterValue = new StringBuilder());

         "And given a new validator"
            .x(() => validator = Validate.That("foo", parameterValue));

         "Testing that the parameter is null"
            .x(() => act = () => validator.IsNull().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(Resources.MustBeNull + "\r\nParameter name: foo"));
      }
   }
}