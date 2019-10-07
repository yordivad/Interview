using MCode.Social.Application.Commands.Request;
using MCode.Social.Core.Domain;
using MCode.Social.Core.Repository;
using MediatR;
using Reactor.Core;

namespace MCode.Social.Application.Handlers
{
    public class SetConfigHandler : RequestHandler<SetConfig, IMono<Unit>>
    {
        private readonly IConfigRepository repository;

        public SetConfigHandler(IConfigRepository repository)
        {
            this.repository = repository;
        }

        protected override IMono<Unit> Handle(SetConfig request)
        {
            return this.repository.Save(Config.Create(request.Server)).Map(_ => Unit.Value);
        }
    }
}