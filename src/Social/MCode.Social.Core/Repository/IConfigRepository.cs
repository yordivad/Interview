// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigRepository.cs" company="MCode">
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
//  Class IConfigRepository.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MCode.Social.Core.Repository
{
    using Epic.Common.Domain;

    using MCode.Social.Core.Domain;

    /// <summary>
    /// The config repository.
    /// </summary>
    /// <seealso>
    ///     <cref>Epic.Common.Domain.IRepository{System.Int64, MCode.Social.Core.Domain.Config}</cref>
    /// </seealso>
    public interface IConfigRepository : IRepository<long, Config>
    {
    }
}