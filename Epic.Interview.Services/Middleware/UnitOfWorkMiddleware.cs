// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" UnitOfWorkMiddleware.cs" company="MCode Software">
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

namespace Epic.Interview.Services.Middleware
{
    using System.Threading.Tasks;

    using Epic.Common.Domain;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Class UnitOfWorkMiddleware.
    /// </summary>
    public class UnitOfWorkMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public UnitOfWorkMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="uow">The unit of work.</param>
        /// <returns>The Task.</returns>
        public async Task Invoke(HttpContext context, IUnitOfWork uow)
        {
            await this.next.Invoke(context);
            uow.Commit();
        }
    }
}