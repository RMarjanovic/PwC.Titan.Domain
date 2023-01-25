using System;
using PwC.Titan.Domain.Primitives;

namespace PwC.Titan.Domain.Events
{
    public sealed record DescriptionUpdatedEvent(Guid Id, Guid JournalId) : DomainEvent(Id)
    {
    }
}