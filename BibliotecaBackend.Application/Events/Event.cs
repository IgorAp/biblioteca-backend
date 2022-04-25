using MediatR;
using System;

namespace BibliotecaBackend.Application.Events
{
    public class Event : INotification 
    {
        public Guid AggregateId { get; set; }
    }
}
