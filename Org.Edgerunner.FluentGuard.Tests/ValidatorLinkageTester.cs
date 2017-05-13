#region Apache License 2.0
// <copyright company="Edgerunner.org" file="ValidatorLinkageTester.cs">
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
using Org.Edgerunner.FluentGuard.Properties;
using Org.Edgerunner.FluentGuard.Validation;
using Xbehave;

namespace Org.Edgerunner.FluentGuard.Tests
{
   /// <summary>
   /// Class containing tests for the <see cref="ValidatorLinkage{T}"/>.
   /// </summary>
   public class ValidatorLinkageTester
   {
      /// <summary>
      /// Tests equality of <see cref="ValidatorLinkage{T}"/>.
      /// </summary>
      /// <param name="firstLinkage">The first linkage.</param>
      /// <param name="secondLinkage">The second linkage.</param>
      /// <param name="areEqual">Determines whether the two linkages are equal.</param>
      [Scenario]
      public void TestInstancesAreEqualFails(ValidatorLinkage<BooleanValidator> firstLinkage, ValidatorLinkage<BooleanValidator> secondLinkage, bool areEqual)
      {
         "Given a first validator linkage instance"
            .x(() => firstLinkage = new ValidatorLinkage<BooleanValidator>(Validate.That("test1", true)));

         "And given a secondLinkage validator linkage instance"
            .x(() => secondLinkage = new ValidatorLinkage<BooleanValidator>(Validate.That("test2", true)));

         "Testing that both linkages are equal"
            .x(() => { areEqual = firstLinkage == secondLinkage; });

         "Should evaluate false"
            .x(() => areEqual.Should().BeFalse());
      }

      /// <summary>
      /// Tests equality of <see cref="ValidatorLinkage{T}"/>.
      /// </summary>
      /// <param name="firstLinkage">The first linkage.</param>
      /// <param name="secondLinkage">The second linkage.</param>
      /// <param name="areNotEqual">Determines whether the two linkages are equal.</param>
      [Scenario]
      public void TestInstancesAreNotEqualPasses(ValidatorLinkage<BooleanValidator> firstLinkage, ValidatorLinkage<BooleanValidator> secondLinkage, bool areNotEqual)
      {
         "Given a first validator linkage instance"
            .x(() => firstLinkage = new ValidatorLinkage<BooleanValidator>(Validate.That("test1", true)));

         "And given a secondLinkage validator linkage instance"
            .x(() => secondLinkage = new ValidatorLinkage<BooleanValidator>(Validate.That("test2", true)));

         "Testing that both linkages are not equal"
            .x(() => { areNotEqual = firstLinkage != secondLinkage; });

         "Should evaluate true"
            .x(() => areNotEqual.Should().BeTrue());
      }

      /// <summary>
      /// Tests equality of <see cref="ValidatorLinkage{T}" />.
      /// </summary>
      /// <param name="linkage">The first linkage.</param>
      /// <param name="areEqual">Determines whether the two linkages are equal.</param>
      [Scenario]
      public void TestInstancesAreEqualFailsDueToNull(ValidatorLinkage<BooleanValidator> linkage, bool areEqual)
      {
         "Given a new validator linkage instance"
            .x(() => linkage = new ValidatorLinkage<BooleanValidator>(Validate.That("test1", true)));

         "Testing that both linkage equals a null"
            .x(() => { areEqual = linkage.Equals(null); });

         "Should evaluate false"
            .x(() => areEqual.Should().BeFalse());
      }

      /// <summary>
      /// Tests equality of <see cref="ValidatorLinkage{T}"/>.
      /// </summary>
      /// <param name="firstLinkage">The first linkage.</param>
      /// <param name="secondLinkage">The second linkage.</param>
      /// <param name="areEqual">Determines whether the two linkages are equal.</param>
      [Scenario]
      public void TestInstancesAsObjectsAreEqualFails(ValidatorLinkage<BooleanValidator> firstLinkage, object secondLinkage, bool areEqual)
      {
         "Given a new first validator linkage instance"
            .x(() => firstLinkage = new ValidatorLinkage<BooleanValidator>(Validate.That("test1", true)));

         "And given a new secondLinkage validator linkage instance stored as an object"
            .x(() => secondLinkage = new ValidatorLinkage<BooleanValidator>(Validate.That("test2", true)));

         "Testing that both linkages are equal"
            .x(() => { areEqual = firstLinkage.Equals(secondLinkage); });

         "Should evaluate false"
            .x(() => areEqual.Should().BeFalse());
      }

      /// <summary>
      /// Tests equality of <see cref="ValidatorLinkage{T}" />.
      /// </summary>
      /// <param name="validator">The validator to test with.</param>
      /// <param name="firstLinkage">The first linkage.</param>
      /// <param name="secondLinkage">The second linkage.</param>
      /// <param name="areEqual">Determines whether the two linkages are equal.</param>
      [Scenario]
      public void TestInstancesAreEqualPasses(BooleanValidator validator, ValidatorLinkage<BooleanValidator> firstLinkage, ValidatorLinkage<BooleanValidator> secondLinkage, bool areEqual)
      {
         "Given a new validator instance"
            .x(() => validator = Validate.That("test1", true));

         "And given a first validator linkage instance"
            .x(() => firstLinkage = new ValidatorLinkage<BooleanValidator>(validator));

         "And given a secondLinkage validator linkage instance"
            .x(() => secondLinkage = new ValidatorLinkage<BooleanValidator>(validator));

         "Testing that both linkages are equal"
            .x(() => { areEqual = firstLinkage == secondLinkage; });

         "Should evaluate true"
            .x(() => areEqual.Should().BeTrue());
      }

      /// <summary>
      /// Tests equality of <see cref="ValidatorLinkage{T}" />.
      /// </summary>
      /// <param name="validator">The validator to test with.</param>
      /// <param name="firstLinkage">The first linkage.</param>
      /// <param name="secondLinkage">The second linkage.</param>
      /// <param name="areEqual">Determines whether the two linkages are equal.</param>
      [Scenario]
      public void TestTwoEqualInstancesHaveSameHashPasses(BooleanValidator validator, ValidatorLinkage<BooleanValidator> firstLinkage, ValidatorLinkage<BooleanValidator> secondLinkage, bool areEqual)
      {
         "Given a new validator instance"
            .x(() => validator = Validate.That("test1", true));

         "And given a first validator linkage instance"
            .x(() => firstLinkage = new ValidatorLinkage<BooleanValidator>(validator));

         "And given a secondLinkage validator linkage instance"
            .x(() => secondLinkage = new ValidatorLinkage<BooleanValidator>(validator));

         "Testing that both linkage's hashes are equal"
            .x(() => { areEqual = firstLinkage.GetHashCode() == secondLinkage.GetHashCode(); });

         "Should evaluate true"
            .x(() => areEqual.Should().BeTrue());
      }
   }
}