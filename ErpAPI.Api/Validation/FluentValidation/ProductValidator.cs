using ErpAPI.EEntity.DTO.ProductDTO;
using FluentValidation;

namespace ErpAPI.Api.Validation.FluentValidation
{
    public class ProductValidator:AbstractValidator<ProductRequestDTO>
    {
        public ProductValidator()
        {
            RuleFor(q => q.UrunKodu).NotEmpty().WithMessage("Ürün Kodu Boş Olamaz");
            RuleFor(q => q.UrunAdi).NotEmpty().WithMessage("Ürün Adı Boş Olamaz");
            RuleFor(q => q.BirimFiyat).NotEmpty().WithMessage("Birim Fiyat Boş Olamaz");
        }
    }
    
}
