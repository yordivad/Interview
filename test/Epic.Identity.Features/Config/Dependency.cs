using System;
using System.Linq;
using Autofac;
using Epic.Identity.Features.Context;
using Epic.Identity.Features.Steps;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace Epic.Identity.Features.Config
{
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