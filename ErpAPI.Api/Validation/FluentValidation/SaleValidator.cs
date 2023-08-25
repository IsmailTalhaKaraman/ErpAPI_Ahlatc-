
using ErpAPI.EEntity.DTO.SaleDTO;
using FluentValidation;

namespace ErpAPI.Api.Validation.FluentValidation
{
    public class SaleValidator:AbstractValidator<SaleRequestDTO>
    {
        public SaleValidator()
        {
            RuleFor(q => q.SiparisID).NotEmpty().WithMessage("SiparişID Bilgisi Boş Olamaz");
            RuleFor(q => q.KullaniciID).NotEmpty().WithMessage("Kullanici Bilgisi Boş Olamaz");
            RuleFor(q => q.MusteriID).NotEmpty().WithMessage("Müşteri Bilgisi Boş Olamaz");
            RuleFor(q => q.SatısFiyati).NotEmpty().WithMessage("Satışı Fiyatı Boş Olamaz");
            RuleFor(q => q.SatisNo).NotEmpty().WithMessage("SatişNo Bilgisi Boş Olamaz");
            
        }
    }
}
