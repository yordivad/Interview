// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserCreateSteps.cs" company="MCode">
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
//  Class UserCreateSteps.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Epic.Identity.Features.Steps
{
    using System.Threading;

    using Epic.Identity.Application.Commands.Request;
    using Epic.Identity.Application.Handlers;
    using Epic.Identity.Core.Domain;
    using Epic.Identity.Core.Repository;
    using Epic.Identity.Features.Context;

    using Moq;

    using Reactor.Core;

    using Shouldly;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The user create class.
    /// </summary>
    [Binding]
    public class UserCreateSteps
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly UserContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCreateSteps"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserCreateSteps(UserContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// given the user.
        /// </summary>
        /// <param name="table">the table.</param>
        [Given(@"the user")]
        public void GivenTheUser(Table table)
        {
            var user = table.CreateInstance<CreateUser>();
            this.context.User = user;
        }

        /// <summary>
        /// Initialize test
        /// </summary>
        [BeforeScenario]
        public void Initialize()
        {
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(r => r.Save(It.IsAny<IMono<User>>())).Returns(Mono.Just(new User()));
            var userRepository = repositoryMock.Object;
            var command = new CreateUserHandler(userRepository);
            this.context.Command = command;
        }

        /// <summary>
        /// Then the i should get no errors.
        /// </summary>
        [Then(@"I should get no errors")]
        public void ThenIShouldGetNoErrors()
        {
            this.context.Success.ShouldBeTrue();
        }

        /// <summary>
        /// When the command is handle.
        /// </summary>
        [When(@"the command is handle")]
        public void WhenTheCommandIsHandle()
        {
            var user = this.context.User;
            var command = this.context.Command;
            command.Handle(user, new CancellationToken()).Result.Subscribe(_ => { this.context.Success = true; });
        }
    }
}