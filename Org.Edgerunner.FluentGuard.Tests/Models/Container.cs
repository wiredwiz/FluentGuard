#region Apache License 2.0

// <copyright file="Container.cs" company="Edgerunner.org">
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

using System;

namespace Org.Edgerunner.FluentGuard.Tests.Models
{
   /// <summary>
   ///    Class that represents a container.
   /// </summary>
   public class Container : IEquatable<Container>, IComparable<Container>
   {
      /// <summary>
      ///    Gets or sets the depth.
      /// </summary>
      /// <value>The depth.</value>
      public double Depth { get; set; }

      /// <summary>
      ///    Gets or sets the height.
      /// </summary>
      /// <value>The height.</value>
      public double Height { get; set; }

      /// <summary>
      ///    Gets or sets the weight.
      /// </summary>
      /// <value>The weight.</value>
      public double Weight { get; set; }

      /// <summary>
      ///    Gets or sets the width.
      /// </summary>
      /// <value>The width.</value>
      public double Width { get; set; }

      #region Operators

      /// <summary>
      ///    Implements the == operator.
      /// </summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator ==(Container left, Container right)
      {
         return Equals(left, right);
      }

      /// <summary>
      ///    Implements the &gt; operator.
      /// </summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator >(Container left, Container right)
      {
         return left.CompareTo(right) == 1;
      }

      /// <summary>
      ///    Implements the != operator.
      /// </summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator !=(Container left, Container right)
      {
         return !Equals(left, right);
      }

      /// <summary>
      ///    Implements the &lt; operator.
      /// </summary>
      /// <param name="left">The left.</param>
      /// <param name="right">The right.</param>
      /// <returns>The result of the operator.</returns>
      public static bool operator <(Container left, Container right)
      {
         return left.CompareTo(right) == -1;
      }

      #endregion

      #region Core Methods

      /// <summary>Determines whether the specified object is equal to the current object.</summary>
      /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
      /// <param name="obj">The object to compare with the current object. </param>
      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj))
            return false;
         if (ReferenceEquals(this, obj))
            return true;
         if (obj.GetType() != this.GetType())
            return false;
         return Equals((Container)obj);
      }

      /// <summary>Serves as the default hash function. </summary>
      /// <returns>A hash code for the current object.</returns>
      public override int GetHashCode()
      {
         unchecked
         {
            var hashCode = Weight.GetHashCode();
            hashCode = (hashCode * 397) ^ Height.GetHashCode();
            hashCode = (hashCode * 397) ^ Width.GetHashCode();
            hashCode = (hashCode * 397) ^ Depth.GetHashCode();
            return hashCode;
         }
      }

      #endregion

      #region IComparable<Container> Members

      /// <summary>
      ///    Compares the current instance with another object of the same type and returns an integer that indicates
      ///    whether the current instance precedes, follows, or occurs in the same position in the sort order as the other
      ///    object.
      /// </summary>
      /// <returns>
      ///    A value that indicates the relative order of the objects being compared. The return value has these meanings:
      ///    Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance
      ///    occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows
      ///    <paramref name="other" /> in the sort order.
      /// </returns>
      /// <param name="other">An object to compare with this instance. </param>
      public int CompareTo(Container other)
      {
         return Weight.CompareTo(other.Weight);
      }

      #endregion

      #region IEquatable<Container> Members

      /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
      /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
      /// <param name="other">An object to compare with this object.</param>
      public bool Equals(Container other)
      {
         if (ReferenceEquals(null, other))
            return false;
         if (ReferenceEquals(this, other))
            return true;
         return Weight.Equals(other.Weight) && Height.Equals(other.Height) && Width.Equals(other.Width) && Depth == other.Depth;
      }

      #endregion
   }
}