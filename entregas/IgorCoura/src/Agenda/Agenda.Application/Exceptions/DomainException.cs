using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Agenda.Application.Exceptions
{
    public class DomainException : Exception
    {
        public List<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();
        public DomainException()
        {
        }

        public DomainException(string? message): base(message)
        {
        }

        public DomainException(string prop, string message) : this()
        {
            Errors.Add(new ValidationFailure(prop, message));
        }

        public DomainException(ValidationResult validationResult) : this()
        {
            Errors.AddRange(validationResult.Errors);
        }
    }
}
