using MediatR;
using System;

namespace BibliotecaBackend.Application.Commands
{
    public abstract class Command<T> : IRequest<T>
    {
        public Guid AggregateId { get; set; }
    }
}
