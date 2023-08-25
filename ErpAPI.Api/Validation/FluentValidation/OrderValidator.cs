
using ErpAPI.EEntity.DTO.OrdetDTO;
using FluentValidation;

namespace ErpAPI.Api.Validation.FluentValidation
{
    public class OrderValidator:AbstractValidator<OrderRequestDTO>
    {
        public OrderValidator()
        {
            RuleFor(q => q.SiparisKodu).NotEmpty().WithMessage("Sipasiş Kodu Boş Olamaz");
            RuleFor(q => q.SatısID).NotEmpty().WithMessage("Satış Id Boş Olamaz");
            RuleFor(q => q.SatisSiparisKodu).NotEmpty().WithMessage("SatisSiparisKodu Boş Olamaz");
            RuleFor(q => q.SiparisAciklamasi).NotEmpty().WithMessage("SiparisAciklamasi Boş Olamaz");
            RuleFor(q => q.KullanıcıID).NotEmpty().WithMessage("Kullanıcı Bilgisi Boş Olamaz");
            RuleFor(q => q.Urun).NotEmpty().WithMessage("Urunler Boş Olamaz");
            RuleFor(q => q.ToplamFiyat).NotEmpty().WithMessage("Fiyat Bilgileri Boş Olamaz");

       
        }

            
            
    }
}
