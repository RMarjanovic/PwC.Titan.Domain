

using System;
using PwC.Titan.Domain.Abstractions;

namespace PwC.Titan.Domain.Primitives
{
    public abstract record DomainEvent(Guid Id) : IDomainEvent
    {
    }
}
