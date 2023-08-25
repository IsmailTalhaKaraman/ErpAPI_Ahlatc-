using ErpAPI.EEntity.DTO.PositionDTO;
using FluentValidation;

namespace ErpAPI.Api.Validation.FluentValidation
{
    public class PositionValidator:AbstractValidator<PositionRequestDTO>
    {
        public PositionValidator()
        {
            RuleFor(x => x.Görev).NotEmpty().WithMessage("Görev Bilgisi Boş Olamaz");
        }
    }
}
