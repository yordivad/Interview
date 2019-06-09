// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" ActiveCandidateSpec.cs" company="MCode Software">
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

namespace Epic.Interview.Core.Specification
{
    using System;
    using System.Linq.Expressions;

    using Epic.Common.Query;
    using Epic.Interview.Core.Domain.Entities;

    /// <summary>
    /// Class ActiveCandidateSpec.
    /// </summary>
    /// <seealso cref="Common.Query.Specification{Candidate}" />
    public class ActiveCandidateSpec : Specification<Candidate>
    {
        /// <summary>
        /// Gets the spec.
        /// </summary>
        /// <value>The spec.</value>
        public override Expression<Func<Candidate, bool>> Spec => candidate => candidate.Active;
    }
}