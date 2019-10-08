// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Memoization.cs" company="MCode">
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see https://www.gnu.org/licenses/.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Common.Query
{
    using System;

    /// <summary>
    /// Class Memorization.
    /// </summary>
    /// <typeparam name="T">The type of the specification.</typeparam>
    public class Memoization<T>
    {
        /// <summary>
        /// The has value.
        /// </summary>
        private bool hasValue;

        /// <summary>
        /// The value.
        /// </summary>
        private T value;

        /// <summary>
        /// Gets the specified apply.
        /// </summary>
        /// <param name="apply">The apply.</param>
        /// <returns>the type of T.</returns>
        public T Get(Func<T> apply)
        {
            if (this.hasValue)
            {
                return this.value;
            }

            this.hasValue = true;
            this.value = apply();
            return this.value;
        }
    }
}