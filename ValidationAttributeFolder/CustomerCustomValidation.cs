using FluentValidation;
using SurveyBasket.Contracts.Requests;

namespace SurveyBasket.ValidationAttributeFolder
{
    public class PollCustomValidator:AbstractValidator<PollRequest>
    {
        public PollCustomValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Add {PropertyName}")
                .Length(5, 100).WithMessage(
                "must provide title you entered {PropertyValue} but must enter at least {MinLength} and at most {MaxLength}");

            RuleFor(p => p.Description).NotEmpty().WithMessage("you must provide {PropertyName}")
                .Length(5, 1000)
                .WithMessage(
                "you typied '{PropertyValue}' but value length must be at least {MaxLength} , at least {MinLength}");

            RuleFor(p=>p.StartsAt).NotEmpty().WithMessage("'{PropertyName}' can't be empty").
                LessThan(p=>p.EndsAt).WithMessage("'{PropertyName}' must be less than EndsAt");
            RuleFor(p => p.EndsAt).NotEmpty().WithMessage("'{PropertyName}' can't be empty").
                GreaterThan(p => p.StartsAt).WithMessage("'{PropertyName}' must be greater than StartsAt");
            RuleFor(p=>p).Must(hasValidDate).WithMessage("EndsAt must be greater than StartsAt");
        }
        bool hasValidDate(PollRequest pollRequest)
        {
            return pollRequest.EndsAt > pollRequest.StartsAt;
        }

    }
}
