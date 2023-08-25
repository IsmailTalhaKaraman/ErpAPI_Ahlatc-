using ErpAPI.EEntity.DTO.AuthorityDTO;
using FluentValidation;

namespace ErpAPI.Api.Validation.FluentValidation
{
    public class AuthorityValidator:AbstractValidator<AuthorityRequestDTO>
    {
        public AuthorityValidator()
        {
            RuleFor(q => q.Yetki).NotEmpty().WithMessage("Yetki Boş Olamaz.");
            RuleFor(q => q.KullanıcıID).NotEmpty().WithMessage("Kullanıcı Bilgisi Boş Olamaz");
        }
    }
}
