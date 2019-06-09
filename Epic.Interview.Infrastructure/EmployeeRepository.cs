// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" EmployeeRepository.cs" company="MCode Software">
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

namespace Epic.Interview.Infrastructure
{
    using Epic.Interview.Core.Domain.Entities;
    using Epic.Interview.Core.Repository;
    using Epic.Interview.Infrastructure.Persistence;

    /// <summary>
    /// Class EmployeeRepository.
    /// </summary>
    /// <seealso cref="Persistence.Repository{int, Employee}" />
    /// <seealso cref="IEmployeeRepository" />
    public class EmployeeRepository : Repository<int, Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="set">The set.</param>
        public EmployeeRepository(IEntitySet set)
            : base(set)
        {
        }
    }
}