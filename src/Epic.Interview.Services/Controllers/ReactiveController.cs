// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveController.cs" company="MCode">
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
// <summary>
//  Class ReactiveController.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Interview.Services.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Reactor.Core;

    /// <summary>
    /// Class ReactiveController.
    /// </summary>
    public class ReactiveController : ControllerBase
    {
        /// <summary>
        /// Results the specified task.
        /// </summary>
        /// <typeparam name="T">The type of the response</typeparam>
        /// <param name="task">The task.</param>
        /// <returns>the IActionResult.</returns>
        public IActionResult Result<T>(Task<IMono<T>> task)
        {
            return task.ContinueWith(r => r.Result.Map(m => new ObjectResult(m))).Result.Block();
        }
    }
}