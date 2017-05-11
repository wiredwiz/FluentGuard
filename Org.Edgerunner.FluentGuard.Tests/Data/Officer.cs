#region Apache License 2.0

// <copyright company="Edgerunner.org" file="Officer.cs">
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
   ///    Class that represents an officer.
   /// </summary>
   public class Officer : Person, IOfficer
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="Officer" /> class.
      /// </summary>
      /// <param name="name">
      ///    The person's name.
      /// </param>
      /// <param name="age">
      ///    The person's age
      /// </param>
      public Officer(string name, int age)
         : base(name, age)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="Officer" /> class.
      /// </summary>
      /// <param name="name">
      ///    The name.
      /// </param>
      /// <param name="age">
      ///    The age.
      /// </param>
      /// <param name="rank">
      ///    The rank.
      /// </param>
      public Officer(string name, int age, string rank)
         : base(name, age)
      {
         Rank = rank;
      }

      #endregion

      #region IOfficer Members

      /// <summary>
      ///    Gets or sets the rank.
      /// </summary>
      /// <value>The rank.</value>
      public string Rank { get; set; }

      #endregion
   }
}