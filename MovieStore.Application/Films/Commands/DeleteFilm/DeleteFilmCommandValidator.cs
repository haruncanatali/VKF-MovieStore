using FluentValidation;

namespace MovieStore.Application.Films.Commands.DeleteFilm;

public class DeleteFilmCommandValidator : AbstractValidator<DeleteFilmCommand>
{
    public DeleteFilmCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Silinecek film için parametre bulunamadı. (ID)");
    }
}