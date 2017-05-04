#region Apache License 2.0
// <copyright company="Edgerunner.org" file="ValidateTests.cs">
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
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.FluentGuard.Tests.Data;
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   ///    Class that tests the Validate class.
   /// </summary>
   [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Can be skipped for unit tests.")]
   [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Is a necessity of xBehave tests")]
   public class ValidateTests
   {
      /// <summary>
      /// Tests the nullable integer That() overload.
      /// </summary>
      /// <param name="validator">The <see cref="NullableNumericValidator{Int32}" /> to test with.</param>     
      [Scenario]
      public void TestValidationOfANullableIntReturnsCorrectValidator(Validator validator)
      {
         "Given a new validator created from a nullable int"
            .x(() => validator = Validate.That("foo", (int?)3));

         "Test that the type of validator returned is a NullableNumericValidator of type integer"
            .x(() => validator.Should().BeOfType(typeof(NullableNumericValidator<int>)));
      }

      /// <summary>
      /// Tests the nullable unsigned integer That() overload.
      /// </summary>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{UInt32}" /> to test with.</param>     
      [Scenario]
      public void TestValidationOfANullableUnsignedIntReturnsCorrectValidator(Validator validator)
      {
         "Given a new validator created from an nullable unsigned int"
            .x(() => validator = Validate.That("foo", (uint?)3));

         "Test that the type of validator returned is a NullableUnsignedNumericValidator of type unsigned integer"
            .x(() => validator.Should().BeOfType(typeof(NullableUnsignedNumericValidator<uint>)));
      }

      /// <summary>
      /// Tests the nullable long That() overload.
      /// </summary>
      /// <param name="validator">The <see cref="NullableNumericValidator{Long}" /> to test with.</param>     
      [Scenario]
      public void TestValidationOfANullableLongReturnsCorrectValidator(Validator validator)
      {
         "Given a new validator created from a nullable long"
            .x(() => validator = Validate.That("foo", (long?)3));

         "Test that the type of validator returned is a NullableNumericValidator of type long"
            .x(() => validator.Should().BeOfType(typeof(NullableNumericValidator<long>)));
      }

      /// <summary>
      /// Tests the nullable unsigned long That() overload.
      /// </summary>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Long}" /> to test with.</param>     
      [Scenario]
      public void TestValidationOfANullableUnsignedLongReturnsCorrectValidator(Validator validator)
      {
         "Given a new validator created from a nullable unsigned long"
            .x(() => validator = Validate.That("foo", (ulong?)3));

         "Test that the type of validator returned is a NullableUnsignedNumericValidator of type unsigned long"
            .x(() => validator.Should().BeOfType(typeof(NullableUnsignedNumericValidator<ulong>)));
      }

      /// <summary>
      /// Tests the nullable short That() overload.
      /// </summary>
      /// <param name="validator">The <see cref="NullableNumericValidator{Short}" /> to test with.</param>     
      [Scenario]
      public void TestValidationOfANullableShortReturnsCorrectValidator(Validator validator)
      {
         "Given a new validator created from a nullable long"
            .x(() => validator = Validate.That("foo", (short?)3));

         "Test that the type of validator returned is a NullableNumericValidator of type short"
            .x(() => validator.Should().BeOfType(typeof(NullableNumericValidator<short>)));
      }

      /// <summary>
      /// Tests the nullable unsigned short That() overload.
      /// </summary>
      /// <param name="validator">The <see cref="NullableUnsignedNumericValidator{Short}" /> to test with.</param>     
      [Scenario]
      public void TestValidationOfANullableUnsignedShortReturnsCorrectValidator(Validator validator)
      {
         "Given a new validator created from a nullable unsigned short"
            .x(() => validator = Validate.That("foo", (ushort?)3));

         "Test that the type of validator returned is a NullableUnsignedNumericValidator of type unsigned short"
            .x(() => validator.Should().BeOfType(typeof(NullableUnsignedNumericValidator<ushort>)));
      }

      /// <summary>
      /// Tests the nullable double That() overload.
      /// </summary>
      /// <param name="validator">The <see cref="NullableNumericValidator{Double}" /> to test with.</param>     
      [Scenario]
      public void TestValidationOfANullableDoubleReturnsCorrectValidator(Validator validator)
      {
         "Given a new validator created from a nullable double"
            .x(() => validator = Validate.That("foo", (double?)3.302));

         "Test that the type of validator returned is a NullableNumericValidator of type double"
            .x(() => validator.Should().BeOfType(typeof(NullableNumericValidator<double>)));
      }

      /// <summary>
      /// Tests the nullable decimal That() overload.
      /// </summary>
      /// <param name="validator">The <see cref="NullableNumericValidator{Decimal}" /> to test with.</param>     
      [Scenario]
      public void TestValidationOfANullableDecimalReturnsCorrectValidator(Validator validator)
      {
         "Given a new validator created from a nullable decimal"
            .x(() => validator = Validate.That("foo", (decimal?)3.302));

         "Test that the type of validator returned is a NullableNumericValidator of type decimal"
            .x(() => validator.Should().BeOfType(typeof(NullableNumericValidator<decimal>)));
      }

      /// <summary>
      /// Tests the nullable float That() overload.
      /// </summary>
      /// <param name="validator">The <see cref="NullableNumericValidator{Float}" /> to test with.</param>     
      [Scenario]
      public void TestValidationOfANullableFloatReturnsCorrectValidator(Validator validator)
      {
         "Given a new validator created from a nullable Float"
            .x(() => validator = Validate.That("foo", (float?)3.302));

         "Test that the type of validator returned is a NullableNumericValidator of type Float"
            .x(() => validator.Should().BeOfType(typeof(NullableNumericValidator<float>)));
      }
   }
}