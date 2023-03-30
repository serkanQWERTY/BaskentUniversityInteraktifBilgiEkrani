using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class FacultyValidator : AbstractValidator<Faculty>
    {
        public FacultyValidator()
        {
            RuleFor(x => x.FacultyName).NotEmpty().WithMessage("Fakülte ismini boş geçemezsiniz.");
            RuleFor(x => x.FacultyName).MinimumLength(12).WithMessage("12 Karakterden düşük değer girilemez.");
            RuleFor(x => x.FacultyName).MaximumLength(100).WithMessage("100 Karakterden fazla değer girilemez.");

            RuleFor(x => x.FacultyAddress).NotEmpty().WithMessage("Fakülte adresini boş geçemezsiniz.");
            RuleFor(x => x.FacultyAddress).MinimumLength(12).WithMessage("12 Karakterden düşük değer girilemez.");
            RuleFor(x => x.FacultyAddress).MaximumLength(150).WithMessage("150 Karakterden fazla değer girilemez.");
        }

    }
}
