using PwC.Titan.Domain.Shared;

namespace PwC.Titan.Domain.Abstractions
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new(
            "ValidationError",
            "A validation problem occurred.");

        Error[] Errors { get; }
    }
}
