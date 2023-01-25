using System;
using PwC.Titan.Domain.Primitives;
using System.Collections.Generic;
using PwC.Titan.Domain.Abstractions;
using PwC.Titan.Domain.Shared;
using PwC.Titan.Domain.Errors;
using System.Linq;
using PwC.Titan.Domain.Events;
using PwC.Titan.Domain.Enums;

namespace PwC.Titan.Domain.Entities
{
    public class Journal : AggregateRoot, IAuditableEntity
    {
        private readonly List<Transaction> _transactions = new();

        public Journal(Guid id, DateTime journalDate, Description description) : base(id)
        {
            JournalDate = journalDate;
            Description = description;
        }

        public IReadOnlyCollection<Transaction> Transactions => _transactions;
        public DateTime JournalDate { get; private set; }
        public Description Description { get; private set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime ModifiedOnUtc { get; set; }

        public Result AddTransactions(List<Transaction> transactions)
        {
            if (_transactions.Select(x => x.Value).Sum() != 0)
                return Result.Failure(DomainErrors.Journal.TransactionSumIsNotZero);
            _transactions.AddRange(transactions);
            RaiseDomainEvent(new AddedTransactionsEvent(new Guid(), Id));
            return Result.Success();
        }

        public Result UpdateDescription(Description description)
        {
            if (Description.Equals(description))
                return Result.Failure(DomainErrors.Journal.DescriptionIdentical);
            Description = description;
            RaiseDomainEvent(new DescriptionUpdatedEvent(new Guid(), Id));
            return Result.Success();
        }
        public double JournalValue()
        {
            return Transactions
                .Where(x => x.Type == TransactionType.DEBIT)
                .Select(x => x.Value)
                .Sum();
        }

        public static Result<Journal> Create(DateTime journalDate, Description description)
        {
            return new Journal(Guid.NewGuid(), journalDate, description);
        }
    }
}