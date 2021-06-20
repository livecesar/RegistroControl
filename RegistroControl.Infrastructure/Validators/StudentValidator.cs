using System;
using FluentValidation;
using RegistroControl.Core.DTOs;

namespace RegistroControl.Infrastructure.Validators
{
    public class StudentValidator : AbstractValidator<StudentDto>
    {
        public StudentValidator()
        {
            RuleFor(student => student.DniNumber)
                .NotNull();
            RuleFor(student => student.Birthdate)
                .LessThan(DateTime.Now);
        }
    }
}
