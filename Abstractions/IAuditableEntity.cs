using System;

namespace PwC.Titan.Domain.Abstractions
{
    public interface IAuditableEntity
    {
        DateTime CreatedOnUtc { get; set; }
        DateTime ModifiedOnUtc { get; set; }
    }
}