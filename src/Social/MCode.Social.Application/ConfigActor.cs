using MCode.Social.Actor.Abstract;
using MCode.Social.Application.Commands.Request;
using MediatR;
using Orleankka;

namespace MCode.Social.Actor
{
    public class ConfigActor: DispatchActorGrain, IConfigActor
    {
        private readonly IMediator mediator;

        public ConfigActor(IMediator mediator)
        {
            this.mediator = mediator;
        }

        void On(SetConfig config)
        { 
            this.mediator.Send(config);
        }
    }
}