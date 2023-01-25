using System;
using MediatR;

namespace PwC.Titan.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        public Guid Id { get; init; }
    }
}
