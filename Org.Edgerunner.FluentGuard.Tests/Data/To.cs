﻿#region Apache License 2.0
// <copyright file="TypeExtensions.cs" company="Edgerunner.org">
// Copyright 2016 Thaddeus Ryker
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
   /// Class exposing some type extensions.
   /// </summary>
   internal static class To
   {
      public static byte Byte(uint item)
      {
         return (byte)item;
      }
   }
}