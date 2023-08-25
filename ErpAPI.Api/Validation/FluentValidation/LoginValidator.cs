
using ErpAPI.EEntity.DTO.LoginDTO;
using FluentValidation;

namespace ErpAPI.Api.Validation.FluentValidation
{
    public class LoginValidator:AbstractValidator<LoginRequestDTO>
    {
        public LoginValidator()
        {
            RuleFor(q => q.KullaniciAdi).NotEmpty().WithMessage("Kullanici Adi Boş Olamaz");
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");
        }
    }
}
