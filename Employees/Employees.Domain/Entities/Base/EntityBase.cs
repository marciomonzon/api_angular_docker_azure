using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public DateTime DateCreated { get; private set; }
        public bool IsDeleted { get; private set; }

        [NotMapped]
        public List<string> Errors { get; set; }

        [NotMapped]
        public bool Valid { get; private set; }

        [NotMapped]
        public bool Invalid => !Valid;

        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
