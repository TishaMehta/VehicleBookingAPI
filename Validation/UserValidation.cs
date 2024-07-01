using FluentValidation;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.Validation
{
    public class UserValidation : AbstractValidator<UserModel>
    {
        private bool Message(DateTime date)
        {
            return date == DateTime.Now.AddDays(5);
        }
        public UserValidation() {
            RuleFor(UserModel => UserModel.FirstName)
            .NotEmpty().WithMessage("first name is required");

            RuleFor(UserModel => UserModel.LastName)
           .NotEmpty().WithMessage("last name is required");

            RuleFor(UserModel => UserModel.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Put your email in proper format");

            RuleFor(UserModel => UserModel.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required")
            .Length(10);

            RuleFor(UserModel => UserModel.Address)
            .NotEmpty();

            RuleFor(UserModel => UserModel.Password)
            .NotEmpty();


        }
    }
}
