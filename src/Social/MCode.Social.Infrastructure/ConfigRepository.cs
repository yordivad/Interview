// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigRepository.cs" company="MCode">
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

namespace MCode.Social.Infrastructure
{
    using Epic.Data.Infrastructure;

    using MCode.Social.Core.Domain;
    using MCode.Social.Core.Repository;

    /// <summary>
    /// The config repository.
    /// </summary>
    /// <seealso>
    ///     <cref>Epic.Data.Infrastructure.Repository{System.Int64, MCode.Social.Core.Domain.Config}</cref>
    /// </seealso>
    /// <seealso cref="MCode.Social.Core.Repository.IConfigRepository" />
    public class ConfigRepository : Repository<long, Config>, IConfigRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigRepository"/> class.
        /// </summary>
        /// <param name="set">The set.</param>
        public ConfigRepository(IEntitySet set)
            : base(set)
        {
        }
    }
}