#region Apache License 2.0
// <copyright company="Edgerunner.org" file="ImmutableAttribute.cs">
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

namespace Org.Edgerunner.FluentGuard.Attributes
{
   /// <summary>
   /// This attribute can be used to declare a type as immutable.
   /// </summary>
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
   internal sealed class ImmutableAttribute : Attribute
   {
   }
}