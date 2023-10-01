using FluentValidation;

namespace MovieStore.Application.PurchasedMovies.Commands.DeletePurchasedMovie;

public class DeletePurchasedMovieCommandValidator : AbstractValidator<DeletePurchasedMovieCommand>
{
    public DeletePurchasedMovieCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Silinecek sipariş verisinin ID parametresi eksik.");
    }
}