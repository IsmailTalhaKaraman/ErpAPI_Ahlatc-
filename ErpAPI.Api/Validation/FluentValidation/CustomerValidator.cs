using ErpAPI.EEntity.DTO.CustomerDTO;
using FluentValidation;

namespace ErpAPI.Api.Validation.FluentValidation
{
    public class CustomerValidator:AbstractValidator<CustomerRequestDTO>
    {
        public CustomerValidator()
        {
            RuleFor(q => q.MusteriAdi).NotEmpty().WithMessage("Müşteri Adı Boş Olamaz.");
            RuleFor(q => q.MusterTelefon).NotEmpty().WithMessage("Müşteri Telefonu Boş Olamaz.");
            RuleFor(q => q.MusterEposta).NotEmpty().WithMessage("Müşteri Epostası Boş Olamaz.");
            RuleFor(q => q.MusteriAdres).NotEmpty().WithMessage("Müşteri Adresi Boş Olamaz.");
            RuleFor(q => q.SatısNo).NotEmpty().WithMessage("Müşteri SatışNo Boş Olamaz.");
        }
    }
}
