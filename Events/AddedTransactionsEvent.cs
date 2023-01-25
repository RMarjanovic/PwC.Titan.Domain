using System;
using PwC.Titan.Domain.Primitives;

namespace PwC.Titan.Domain.Events
{
    public sealed record AddedTransactionsEvent(Guid Id, Guid JournalId) : DomainEvent(Id)
    {
    }
}