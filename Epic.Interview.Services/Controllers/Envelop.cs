// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" Envelop.cs" company="MCode Software">
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
// </copyright>
// <summary>
//  Contributors: Roy Gonzalez
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Epic.Interview.Services.Controllers
{
    /// <summary>
    /// Class Envelop.
    /// </summary>
    public class Envelop
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Envelop"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }
    }
}