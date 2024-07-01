using FluentValidation;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.Validation
{
    public class Validator: AbstractValidator<RegistrationModel>
    {
        public Validator()
        {
            RuleFor(RegistrationModel => RegistrationModel.UserName)
            .NotEmpty();
           // .InclusiveBetween(0,100);

            RuleFor(RegistrationModel => RegistrationModel.Password)
            .NotEmpty()
            .Length(10);

            RuleFor(RegistrationModel => RegistrationModel.ConfirmPassword)
            .NotEmpty()
            .Equal(RegistrationModel => RegistrationModel.Password);

            RuleFor(RegistrationModel => RegistrationModel.Email)
                .NotEmpty();

            RuleFor(RegistrationModel => RegistrationModel.EvenDate).NotEmpty();
        }
    }
}
