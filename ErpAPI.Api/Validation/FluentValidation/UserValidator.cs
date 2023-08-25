
using ErpAPI.EEntity.DTO.UserDTO;
using FluentValidation;

namespace ErpAPI.Api.Validation.FluentValidation
{
    public class UserValidator:AbstractValidator<UserRequestDTO>
    {
        public UserValidator()
        {
            RuleFor(q => q.Adi).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.Soyadi).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.Telefon).NotEmpty().WithMessage("Telefon Boş Olamaz");
            RuleFor(q => q.Eposta).NotEmpty().WithMessage("Eposta Boş Olamaz");
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Sifre Boş Olamaz");
            RuleFor(q => q.Görev).NotEmpty().WithMessage("Görev Bilgisi Boş Olamaz");
        }
    }
}
