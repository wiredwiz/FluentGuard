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
using Org.Edgerunner.FluentGuard.Exceptions;
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
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public virtual void TestParameterNotNullFails(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
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
      /// Tests not null validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="NullableBooleanValidator" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Persons), MemberType = typeof(ClassData))]
      public virtual void TestParameterNotNullPasses(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase)
      {
         "And given a new ValidatorBase"
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
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public void TestParameterIsNullPasses(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase)
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
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Persons), MemberType = typeof(ClassData))]
      public void TestParameterIsNullFails(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is null"
            .x(() => act = () => validatorBase.IsNull().OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Resources.MustBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsOfType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Officers), MemberType = typeof(ClassData))]
      public void TestParameterIsOfTypePersonFails(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is of type Person"
            .x(() => act = () => validatorBase.IsOfType(typeof(Person)).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentTypeException>()
            .WithMessage(string.Format(Resources.MustBeOfType + "\r\nParameter name: {1}", typeof(Person).Name, parameterName)));
      }

      /// <summary>
      ///    Tests IsOfType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public void TestParameterIsOfTypePersonFailsDueToNullValue(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is of type Person"
            .x(() => act = () => validatorBase.IsOfType(typeof(Person)).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Resources.MustNotBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests IsOfType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Officers), MemberType = typeof(ClassData))]
      public void TestParameterIsOfTypePersonFailsDueToNullType(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is of type null"
            .x(() => act = () => validatorBase.IsOfType(null).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage("Value cannot be null.\r\nParameter name: type"));
      }

      /// <summary>
      ///    Tests IsOfType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Persons), MemberType = typeof(ClassData))]
      public void TestParameterIsOfTypePersonPasses(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is of type Person"
            .x(() => validatorBase.IsOfType(typeof(Person)).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests InheritsType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Persons), MemberType = typeof(ClassData))]
      public void TestParameterInheritsTypeFails(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter inherits from type Officer"
            .x(() => act = () => validatorBase.InheritsType(typeof(Officer)).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentTypeException>()
            .WithMessage(string.Format(Resources.MustInheritType + "\r\nParameter name: {1}", typeof(Officer).Name, parameterName)));
      }

      /// <summary>
      ///    Tests InheritsType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public void TestParameterInheritsTypeFailsDueToNullValue(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter inherits from type Officer"
            .x(() => act = () => validatorBase.InheritsType(typeof(Person)).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Resources.MustNotBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests InheritsType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Persons), MemberType = typeof(ClassData))]
      public void TestParameterInheritsTypeFailsDueToNullType(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter inherits from type Officer"
            .x(() => act = () => validatorBase.InheritsType(null).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage("Value cannot be null.\r\nParameter name: type"));
      }

      /// <summary>
      ///    Tests InheritsType validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Officers), MemberType = typeof(ClassData))]
      public void TestParameterInheritsTypePasses(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter inherits from type Person"
            .x(() => validatorBase.InheritsType(typeof(Person)).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      ///    Tests ImplementsInterface validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Persons), MemberType = typeof(ClassData))]
      public void TestParameterImplementsInterfaceFails(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter implements interface IOfficer"
            .x(() => act = () => validatorBase.ImplementsInterface(typeof(IOfficer)).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentTypeException>()
            .WithMessage(string.Format(Resources.MustImplementInterface + "\r\nParameter name: {1}", typeof(IOfficer).Name, parameterName)));
      }

      /// <summary>
      ///    Tests ImplementsInterface validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [Example("foo1", null)]
      public void TestParameterImplementsInterfaceFailsDueToNullValue(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter implements interface IOfficer"
            .x(() => act = () => validatorBase.ImplementsInterface(typeof(IOfficer)).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage(string.Format(Resources.MustNotBeNull + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      ///    Tests ImplementsInterface validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Persons), MemberType = typeof(ClassData))]
      public void TestParameterImplementsInterfaceFailsDueToNullType(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter implements interface IOfficer"
            .x(() => act = () => validatorBase.ImplementsInterface(null).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentNullException>()
            .WithMessage("Value cannot be null.\r\nParameter name: type"));
      }

      /// <summary>
      ///    Tests ImplementsInterface validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Persons), MemberType = typeof(ClassData))]
      public void TestParameterImplementsInterfaceFailsDueToNonInterface(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter implements interface IOfficer"
            .x(() => act = () => validatorBase.ImplementsInterface(typeof(Officer)).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentTypeException>()
            .WithMessage(Resources.MustBeInterface + "\r\nParameter name: type"));
      }

      /// <summary>
      ///    Tests ImplementsInterface validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.Officers), MemberType = typeof(ClassData))]
      public void TestParameterImplementsInterfacePasses(string parameterName, Person parameterValue, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter implements interface IOfficer"
            .x(() => validatorBase.ImplementsInterface(typeof(IOfficer)).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }

      /// <summary>
      /// Tests IsSameAs validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the first parameter.</param>
      /// <param name="parameterValue2">The value of the second parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.OfficersAndPeople), MemberType = typeof(ClassData))]
      public void TestParameterIsSameAsFails(string parameterName, Person parameterValue, Person parameterValue2, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is same as"
            .x(() => act = () => validatorBase.IsSameAs(parameterValue2).OtherwiseThrowException());

         "Should throw an exception"
            .x(() => act.ShouldThrow<ArgumentException>()
            .WithMessage(string.Format(Resources.MustBeSameAs + "\r\nParameter name: {0}", parameterName)));
      }

      /// <summary>
      /// Tests IsSameAs validation.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The value of the first parameter.</param>
      /// <param name="parameterValue2">The value of the second parameter.</param>
      /// <param name="validatorBase">The <see cref="ClassValidator{Person}" /> to test with.</param>
      /// <param name="act">The <see cref="Action" /> to test with.</param>
      [Scenario]
      [MemberData(nameof(ClassData.OfficersAndPeople), MemberType = typeof(ClassData))]
      public void TestParameterIsSameAsPasses(string parameterName, Person parameterValue, Person parameterValue2, ClassValidator<Person> validatorBase, Action act)
      {
         "Given a new ValidatorBase"
            .x(() => validatorBase = Validate.That(parameterName, parameterValue));

         "Testing that the parameter is same as"
            .x(() => validatorBase.IsSameAs(parameterValue).OtherwiseThrowException());

         "Should not result in an exception"
            .x(() => validatorBase.CurrentException.Should().BeNull());
      }
   }
}