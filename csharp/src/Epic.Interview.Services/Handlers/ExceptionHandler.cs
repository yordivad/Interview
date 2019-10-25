// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandler.cs" company="MCode">
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

namespace Epic.Interview.Services.Handlers
{
    using System.Net;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// Class ExceptionHandler.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute" />
    public class ExceptionHandler : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <inheritdoc />
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(
                new
                    {
                        context.Exception.Message,
                        Description = $"There was a error {context.Exception.HelpLink}",
                        statusCode = HttpStatusCode.InternalServerError,
                    });
        }
    }
}