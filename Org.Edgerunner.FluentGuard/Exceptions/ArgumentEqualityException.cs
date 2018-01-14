#region Apache License 2.0

// <copyright company="Edgerunner.org" file="ArgumentEqualityException.cs">
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
using System.Runtime.Serialization;

#if NDEPEND
using NDepend.Attributes;
using Org.Edgerunner.NDepend.Attributes;
#endif

namespace Org.Edgerunner.FluentGuard.Exceptions
{
   /// <summary>
   ///    The exception that is thrown when the value of an argument fails a test of equality or inequality.
   /// </summary>
   /// <seealso cref="System.ArgumentException" />
#if NDEPEND
   [UncoverableByTest]
#endif
   [Serializable]
   public class ArgumentEqualityException : ArgumentException
   {
      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="ArgumentEqualityException" /> class.
      /// </summary>
#if NDEPEND
      [OverloadVerified]
#endif
      public ArgumentEqualityException()
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="ArgumentEqualityException" /> class.
      /// </summary>
      /// <param name="message">The error message that explains the reason for the exception.</param>
#if NDEPEND
      [OverloadVerified]
#endif
      public ArgumentEqualityException(string message)
         : base(message)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="ArgumentEqualityException" /> class.
      /// </summary>
      /// <param name="message">The error message that explains the reason for the exception.</param>
      /// <param name="innerException">
      ///    The exception that is the cause of the current exception. If the
      ///    <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch
      ///    block that handles the inner exception.
      /// </param>
#if NDEPEND
      [OverloadVerified]
#endif
      public ArgumentEqualityException(string message, Exception innerException)
         : base(message, innerException)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="ArgumentEqualityException" /> class.
      /// </summary>
      /// <param name="message">The error message that explains the reason for the exception.</param>
      /// <param name="paramName">The name of the parameter that caused the current exception.</param>
      /// <param name="innerException">
      ///    The exception that is the cause of the current exception. If the
      ///    <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch
      ///    block that handles the inner exception.
      /// </param>
#if NDEPEND
      [OverloadVerified]
#endif
      public ArgumentEqualityException(string message, string paramName, Exception innerException)
         : base(message, paramName, innerException)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="ArgumentEqualityException" /> class.
      /// </summary>
      /// <param name="message">The error message that explains the reason for the exception.</param>
      /// <param name="paramName">The name of the parameter that caused the current exception.</param>
#if NDEPEND
      [OverloadVerified]
#endif
      public ArgumentEqualityException(string message, string paramName)
         : base(message, paramName)
      {
      }

      /// <summary>
      ///    Initializes a new instance of the <see cref="ArgumentEqualityException" /> class.
      /// </summary>
      /// <param name="info">The object that holds the serialized object data.</param>
      /// <param name="context">The contextual information about the source or destination.</param>
#if NDEPEND
      [OverloadVerified]
#endif
      protected ArgumentEqualityException(SerializationInfo info, StreamingContext context)
         : base(info, context)
      {
      }

      #endregion
   }
}