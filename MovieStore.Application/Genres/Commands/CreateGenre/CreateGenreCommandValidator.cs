using FluentValidation;

namespace MovieStore.Application.Genres.Commands.CreateGenre;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Tür adı boş geçilemez.")
            .Length(2, 150).WithMessage("Tür adı 2-150 karakterden oluşmak zorundadır.");
    }
}