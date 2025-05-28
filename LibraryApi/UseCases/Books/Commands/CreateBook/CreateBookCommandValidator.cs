using FluentValidation;

namespace LibraryApi.UseCases.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Название книги обязательно.")
                .MaximumLength(200).WithMessage("Название книги не должно превышать 200 символов.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Автор обязателен.")
                .MaximumLength(100).WithMessage("Имя автора не должно превышать 100 символов.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Описание не должно превышать 1000 символов.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Цена должна быть неотрицательной.");
        }
    }
}
