using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {

        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş Geçmeyınız...!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen Görsel seciniz...!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Baslik kısmını boş Geçmeyınız...!");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("ikinci Baslik kismini bos birakmazin...! ");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("ikinci Aciklama kismini bos birakmayin...!");
            RuleFor(x => x.Status).NotEmpty().WithMessage("About durumunu Belirleyin...!");

        }
    }
}
