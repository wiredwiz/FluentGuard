﻿#region Apache License 2.0
// <copyright company="Edgerunner.org" file="ValidatorBase.cs">
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

#if NDEPEND
using NDepend.Attributes;
using Org.Edgerunner.NDepend.Attributes;
#endif

namespace Org.Edgerunner.FluentGuard.Validation
{
   /// <summary>
   /// Foundational ValidatorBase class.
   /// </summary>
#if NDEPEND
   [FullCovered]
   [ExcludeFromNestingCheck]
#endif
   public abstract class ValidatorBase
   {
      /// <summary>
      /// Gets or sets the current exception.
      /// </summary>
      /// <value>The current exception.</value>
      internal Exception CurrentException { get; set; }

      /// <summary>
      /// Gets or sets the <see cref="CombinationMode"/> to use when combining conditions.
      /// </summary>
      /// <value>The mode.</value>
      internal CombinationMode Mode { get; set; }

      /// <summary>
      /// Frees this instance from the pool and thus allows it to be garbage collected.
      /// </summary>
      internal abstract void Free();
   }
}