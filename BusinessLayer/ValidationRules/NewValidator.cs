using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NewValidator : AbstractValidator<New>
    {
        public NewValidator()
        {
            RuleFor(x => x.NewName).NotEmpty().WithMessage("Haber ismini boş geçemezsiniz.");
            RuleFor(x => x.NewName).MinimumLength(12).WithMessage("10 Karakterden düşük değer girilemez.");
            RuleFor(x => x.NewName).MaximumLength(50).WithMessage("50 Karakterden fazla değer girilemez.");
            RuleFor(x => x.NewDescription).NotEmpty().WithMessage("Haber Açıklamasını boş geçemezsiniz.");
            RuleFor(x => x.NewDescription).MinimumLength(12).WithMessage("15 Karakterden düşük değer girilemez.");
            RuleFor(x => x.NewDescription).MaximumLength(50).WithMessage("100 Karakterden fazla değer girilemez.");
            RuleFor(x => x.NewStatus).NotEmpty().WithMessage("Haber durumu True veya False seçeneklerinden biri olmalıdır. True Aktif , False Pasif Anlamına Gelmektedir");
            RuleFor(x => x.NewCreationDate).NotEmpty().WithMessage("Haber oluşturulma tarihini boş geçemezsiniz. Kabul edilen format gg.aa.yyyy olmalıdır.");
        }
    }
}
