using Epic.Identity.Application.Commands;
using Epic.Identity.Core.Repository;
using MediatR;
using Reactor.Core;

namespace Epic.Identity.Features.Model
{
    public class UserContext
    {
        public IUserRepository Repository { get; set; }

        public IRequestHandler<CreateUser, IMono<Unit>> Command { get; set; }
        
        public CreateUser User {get; set;}

        public bool Success { get; set; }
        
    }
}