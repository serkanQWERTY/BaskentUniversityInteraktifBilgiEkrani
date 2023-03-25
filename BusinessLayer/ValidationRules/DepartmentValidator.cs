using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("Bölüm ismini boş geçemezsiniz.");
            RuleFor(x => x.DepartmentName).MinimumLength(12).WithMessage("10 Karakterden düşük değer girilemez.");
            RuleFor(x => x.DepartmentName).MaximumLength(50).WithMessage("50 Karakterden fazla değer girilemez.");
            RuleFor(x => x.DepartmentAddress).NotEmpty().WithMessage("Bölüm adresini boş geçemezsiniz.");
            RuleFor(x => x.DepartmentAddress).MinimumLength(12).WithMessage("15 Karakterden düşük değer girilemez.");
            RuleFor(x => x.DepartmentAddress).MaximumLength(50).WithMessage("100 Karakterden fazla değer girilemez.");
            RuleFor(x => x.DepartmentStatus).NotEmpty().WithMessage("Bölüm durumu True veya False seçeneklerinden biri olmalıdır. True Aktif , False Pasif Anlamına Gelmektedir");
            RuleFor(x => x.DepartmentCreationDate).NotEmpty().WithMessage("Bölüm kuruluş tarihini boş geçemezsiniz. Kabul edilen format gg.aa.yyyy olmalıdır.");
        }

    }
}
