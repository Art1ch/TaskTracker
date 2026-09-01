using FluentValidation;
using System.Linq.Expressions;
using TaskTracker.Application.Validaton.ErrorCodes;

namespace TaskTracker.Application.Validaton.Validators;

public abstract class ValidatorBase<T> : AbstractValidator<T>
{
    private const int MinPageSize = 10;
    private const int MaxPageSize = 50;
    private const int TitleMaxLength = 200;
    private const int DescriptionMaxLength = 500;
    private const int NameMaxLength = 100;
    private const int TextMaxLength = 255;
    private const int FirstNameMaxLength = 100;
    private const int LastNameMaxLength = 100;

    protected void ValidatePage(Expression<Func<T, int>> expression)
    {
        RuleFor(expression)
            .GreaterThanOrEqualTo(1)
            .WithErrorCode(ValidationErrorCodes.PageNumberMinValue);
    }

    protected void ValidatePageSize(Expression<Func<T, int>> expression)
    {
        RuleFor(expression)
            .InclusiveBetween(MinPageSize, MaxPageSize)
            .WithErrorCode(ValidationErrorCodes.PageSizeRange);
    }

    protected void ValidateId(Expression<Func<T, Guid>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.IdRequired);
    }

    protected void ValidateId(Expression<Func<T, Guid?>> expression, bool required = false)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.IdRequired);
        }

        rule
            .Must(id => !id.HasValue || id.Value != Guid.Empty)
            .WithErrorCode(ValidationErrorCodes.InvalidId);
    }

    protected void ValidateTitle(Expression<Func<T, string?>> expression, bool required = false)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.TitleRequired);
        }

        rule
            .MaximumLength(TitleMaxLength)
            .WithErrorCode(ValidationErrorCodes.TitleMaxLength);
    }

    protected void ValidateDescription(Expression<Func<T, string?>> expression, bool required = false)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.DescriptionRequired);
        }

        rule
            .MaximumLength(DescriptionMaxLength)
            .WithErrorCode(ValidationErrorCodes.DescriptionMaxLength);
    }

    protected void ValidateName(Expression<Func<T, string?>> expression, bool required = false)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.NameRequired);
        }

        rule
            .MaximumLength(NameMaxLength)
            .WithErrorCode(ValidationErrorCodes.NameMaxLength);
    }

    protected void ValidateText(Expression<Func<T, string?>> expression, bool required = false, int maxLength = TextMaxLength)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.TextRequired);
        }

        rule
            .MaximumLength(maxLength)
            .WithErrorCode(ValidationErrorCodes.TextMaxLength);
    }

    protected void ValidateEmail(Expression<Func<T, string?>> expression, bool required = false)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.EmailRequired);
        }

        rule
            .EmailAddress()
            .WithErrorCode(ValidationErrorCodes.InvalidEmail);
    }

    protected void ValidateFirstName(Expression<Func<T, string?>> expression, bool required = false)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.FirstNameRequired);
        }

        rule
            .MaximumLength(FirstNameMaxLength)
            .WithErrorCode(ValidationErrorCodes.FirstNameMaxLength);
    }

    protected void ValidateLastName(Expression<Func<T, string?>> expression, bool required = false)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.LastNameRequired);
        }

        rule
            .MaximumLength(LastNameMaxLength)
            .WithErrorCode(ValidationErrorCodes.LastNameMaxLength);
    }

    protected void ValidatePassword(Expression<Func<T, string?>> expression, bool required = false)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.PasswordRequired);
        }

        rule
            .MinimumLength(6)
            .WithErrorCode(ValidationErrorCodes.PasswordMinLength)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$")
            .WithErrorCode(ValidationErrorCodes.PasswordWeak);
    }

    protected void ValidateEnum<TEnum>(Expression<Func<T, TEnum?>> expression, bool required = false) where TEnum : struct, Enum
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotNull()
                .WithErrorCode(ValidationErrorCodes.EnumRequired);
        }

        rule
            .Must(value => !value.HasValue || Enum.IsDefined(typeof(TEnum), value.Value))
            .WithErrorCode(ValidationErrorCodes.InvalidEnumValue);
    }

    protected void ValidateBoolean(Expression<Func<T, bool?>> expression, bool required = false)
    {
        if (required)
        {
            RuleFor(expression)
                .NotNull()
                .WithErrorCode(ValidationErrorCodes.BooleanRequired);
        }
    }

    protected void ValidateDateRange(
        Expression<Func<T, DateTime?>> fromExpression,
        Expression<Func<T, DateTime?>> toExpression)
    {
        RuleFor(x => x)
            .Must(x =>
            {
                var from = fromExpression.Compile()(x);
                var to = toExpression.Compile()(x);
                return !from.HasValue || !to.HasValue || from.Value <= to.Value;
            })
            .WithErrorCode(ValidationErrorCodes.DateRangeInvalid);
    }

    protected void ValidateDeadline(Expression<Func<T, DateTime?>> expression, bool required = false)
    {
        var rule = RuleFor(expression);

        if (required)
        {
            rule
                .NotNull()
                .WithErrorCode(ValidationErrorCodes.DeadlineRequired);
        }

        rule
            .Must(date => !date.HasValue || date.Value > DateTime.UtcNow)
            .WithErrorCode(ValidationErrorCodes.DeadlineMustBeFuture);
    }
}