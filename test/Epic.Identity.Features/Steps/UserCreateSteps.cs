using System.Threading;
using Epic.Identity.Application.Commands;
using Epic.Identity.Application.Handlers;
using Epic.Identity.Core.Domain;
using Epic.Identity.Core.Repository;
using Epic.Identity.Features.Model;
using MediatR;
using Moq;
using Reactor.Core;
using Shouldly;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Epic.Identity.Features.Steps
{
    [Binding]
    public  class UserCreateSteps
    {
        private readonly UserContext context;

        public UserCreateSteps(UserContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// 
        /// </summary>
        [BeforeScenario]
        public void Initialize()
        {
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(r => r.Save(It.IsAny<IMono<User>>())).Returns(Mono.Just(new User()));
            var userRepository = repositoryMock.Object;
            var command = new CreateUserHandler(userRepository);
            context.Command = command;
        }

        /// <summary>
        /// given the user.
        /// </summary>
        /// <param name="table">te</param>
        [Given(@"the user")]
        public void GivenTheUser(Table table)
        {
            var user = table.CreateInstance<CreateUser>();
            context.User = user;
        }

        [When(@"the command is handle")]
        public void WhenTheCommandIsHandle()
        {
            var user = context.User;
            var command = context.Command;
            command.Handle(user, new CancellationToken()).Result.Subscribe(_ => { context.Success = true; });
        }

        [Then(@"I should get no errors")]
        public void ThenIShouldGetNoErrors()
        {
            context.Success.ShouldBeTrue();
        }
        
    }
}