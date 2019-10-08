// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="MCode">
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
//  Class Program.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MCode.Social.Server
{
    using System;

    using MCode.Social.Application;
    using MCode.Social.Infrastructure;

    using Orleans.Hosting;

    /// <summary>
    /// the program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var builder = new SiloHostBuilder();

            builder.ConfigureApplicationParts(manager => { manager.AddApp(); });

            builder.ConfigureServices(
                services =>
                    {
                        services.AddSocialApp();
                        services.AddSocialInfrastructure();
                    });

            Console.WriteLine("Hello World!");
        }
    }
}