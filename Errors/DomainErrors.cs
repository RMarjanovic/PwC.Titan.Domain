using System;
using PwC.Titan.Domain.Shared;

namespace PwC.Titan.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Journal
        {
            public static readonly Error TransactionsIdentical = new(
                "Journal.TransactionsIdentical.",
                "Transactions are identical to current.");

            public static readonly Error TransactionSumIsNotZero = new(
                "Journal.TransactionSumIsNotZero",
                $"Sum of all transactions are not zero.");

            public static readonly Error DescriptionIdentical = new(
                "Journal.DescriptionIdentical",
                $"Description is identical to current.");
        }
        public static class Description
        {
            public static readonly Func<string, int, Error> ExceedingMaxLength = (value, maxLength) => new Error(
               "Description.ExceedingMaxLength",
               $"The value {value} exceeds the max length of {maxLength}.");
        }
    }
}
