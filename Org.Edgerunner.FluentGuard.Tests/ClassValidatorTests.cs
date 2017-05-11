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
using Xunit;

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
      /// <param name="validator">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public virtual void TestParameterNotNullFails(string parameterName, Person parameterValue, ClassValidator<Person> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is not null"
            .x(() => act = () => validator.IsNotNull().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Resources.MustNotBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="NullableBooleanValidator" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(PersonData.Persons), MemberType = typeof(PersonData))]
      public virtual void TestParameterNotNullPasses(string parameterName, Person parameterValue, ClassValidator<Person> validator)
      {
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
      /// <param name="validator">The <see cref="ClassValidator{Person}" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public void TestParameterIsNullPasses(string parameterName, Person parameterValue, ClassValidator<Person> validator)
      {
         "Given a new validator"
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
      /// <param name="validator">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(PersonData.Persons), MemberType = typeof(PersonData))]
      public void TestParameterIsNullFails(string parameterName, Person parameterValue, ClassValidator<Person> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is null"
            .x(() => act = () => validator.IsNull().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Resources.MustBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsOfType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(PersonData.Officers), MemberType = typeof(PersonData))]
      public void TestParameterIsOfTypePersonFails(string parameterName, Person parameterValue, ClassValidator<Person> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is of type Person"
            .x(() => act = () => validator.IsOfType(typeof(Person)).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Resources.MustBeOfType + "\r\nParameter name: {1}", typeof(Person).Name, parameterName)));
      }

      /// <summary>
      ///    Tests IsOfType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public void TestParameterIsOfTypePersonFailsDueToNullValue(string parameterName, Person parameterValue, ClassValidator<Person> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is of type Person"
            .x(() => act = () => validator.IsOfType(typeof(Person)).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Resources.MustNotBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsOfType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(PersonData.Officers), MemberType = typeof(PersonData))]
      public void TestParameterIsOfTypePersonFailsDueToNullType(string parameterName, Person parameterValue, ClassValidator<Person> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is of type Person"
            .x(() => act = () => validator.IsOfType(null).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage("Value cannot be null.\r\nParameter name: type"));
      }

      /// <summary>
      ///    Tests IsOfType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validator">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(PersonData.Persons), MemberType = typeof(PersonData))]
      public void TestParameterIsOfTypePersonPasses(string parameterName, Person parameterValue, ClassValidator<Person> validator, Action act)
      {
         "Given a new validator"
            .x(() => validator = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is of type Person"
            .x(() => act = () => validator.IsOfType(typeof(Person)).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validator.CurrentException.Should().BeNull());
      }
   }
}