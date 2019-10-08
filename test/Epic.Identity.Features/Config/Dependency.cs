// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Review.cs" company="MCode">
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see https://www.gnu.org/licenses.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Features.Config
{
    using System;
    using System.Linq;
    using Autofac;
    using Epic.Identity.Features.Context;
    using SpecFlow.Autofac;
    using TechTalk.SpecFlow;
    
    /// <summary>
    /// The container dependency.
    /// </summary>
    public static class Dependency
    {
        /// <summary>
        /// The builder.
        /// </summary>
        /// <returns></returns>
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserContext>().As<UserContext>();
            builder.RegisterTypes(typeof(Dependency).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();

            return builder;
        }
    }
}