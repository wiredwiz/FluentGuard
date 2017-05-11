#region Apache License 2.0

// <copyright company="Edgerunner.org" file="Person.cs">
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

namespace Org.Edgerunner.FluentGuard.Tests.Data
{
   /// <summary>
   ///    Class that represents a person.
   /// </summary>
   public class Person
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="Person" /> class.
      /// </summary>
      /// <param name="name">The person's name.</param>
      /// <param name="age">The person's age</param>
      public Person(string name, int age)
      {
         Name = name;
         Age = age;
      }

      #endregion

      /// <summary>
      ///    Gets or sets the age.
      /// </summary>
      /// <value>The age.</value>
      public int Age { get; set; }

      /// <summary>
      ///    Gets or sets the name.
      /// </summary>
      /// <value>The name.</value>
      public string Name { get; set; }
   }
}