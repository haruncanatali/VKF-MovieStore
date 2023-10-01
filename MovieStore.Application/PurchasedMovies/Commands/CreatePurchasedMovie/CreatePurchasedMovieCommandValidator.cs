using FluentValidation;

namespace MovieStore.Application.PurchasedMovies.Commands.CreatePurchasedMovie;

public class CreatePurchasedMovieCommandValidator : AbstractValidator<CreatePurchasedMovieCommand>
{
    public CreatePurchasedMovieCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotNull().WithMessage("Satın alınan filmin müşterisi girilmelidir.");
        RuleFor(c => c.FilmId)
            .NotNull().WithMessage("Satın alınan filmin filmi girilmelidir.");
        RuleFor(c => c.Amount)
            .NotNull().WithMessage("Satın alınan filmin adeti girilmelidir.");
    }
}