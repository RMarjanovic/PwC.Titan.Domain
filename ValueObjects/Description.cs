using System.Collections.Generic;
using PwC.Titan.Domain.Errors;
using PwC.Titan.Domain.Primitives;
using PwC.Titan.Domain.Shared;

namespace PwC.Titan.Domain.Entities
{
    public class Description : ValueObject
    {
        private const int MaxLength = 256;
        public Description(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static Result<Description> Create(string value)
        {
            if (value.Length > MaxLength)
                return Result.Failure<Description>(DomainErrors.Description.ExceedingMaxLength(value, MaxLength));
            return new Description(value);
        }
    }
}