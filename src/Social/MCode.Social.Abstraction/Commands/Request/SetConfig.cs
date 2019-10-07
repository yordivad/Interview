using System;
using MediatR;
using Orleankka.Meta;
using Reactor.Core;

namespace MCode.Social.Application.Commands.Request
{
    [Serializable]
    public class SetConfig: Command, IRequest<IMono<Unit>>
    {
        public string Server { get; set; }
    }
}