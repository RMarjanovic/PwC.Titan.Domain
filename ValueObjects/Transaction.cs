#nullable enable

using System;
using System.Collections.Generic;
using PwC.Titan.Domain.Enums;
using PwC.Titan.Domain.Primitives;
using PwC.Titan.Domain.Shared;

namespace PwC.Titan.Domain.Entities
{
    public class Transaction : ValueObject
    {
        public Transaction(TransactionType type, double value, Description? description, DateTime? transactionDate)
        {
            Value = value;
            Description = description;
            Type = type;
            TransactionDate = transactionDate;
        }
        public double Value { get; private set; }
        public Description? Description { get; private set; }
        public DateTime? TransactionDate { get; private set; }
        public TransactionType Type { get; private set; }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return Type;
        }
        public static Result<Transaction> Create(TransactionType type, double value, Description? description = null, DateTime? transactionDate = null)
        {
            return new Transaction(type, value, description, transactionDate);
        }
    }
}