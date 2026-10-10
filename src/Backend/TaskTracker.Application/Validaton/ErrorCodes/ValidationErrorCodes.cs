namespace TaskTracker.Application.Validaton.ErrorCodes;

public static class ValidationErrorCodes
{
    public const string PageNumberMinValue = "PAGE_NUMBER_MIN_VALUE";
    public const string PageSizeRange = "PAGE_SIZE_RANGE";

    public const string IdRequired = "ID_REQUIRED";
    public const string InvalidId = "INVALID_ID";

    public const string TitleRequired = "TITLE_REQUIRED";
    public const string TitleMaxLength = "TITLE_MAX_LENGTH";

    public const string DescriptionRequired = "DESCRIPTION_REQUIRED";
    public const string DescriptionMaxLength = "DESCRIPTION_MAX_LENGTH";

    public const string NameRequired = "NAME_REQUIRED";
    public const string NameMaxLength = "NAME_MAX_LENGTH";

    public const string TextRequired = "TEXT_REQUIRED";
    public const string TextMaxLength = "TEXT_MAX_LENGTH";
    public const string TextMinLength = "TEXT_MIN_LENGTH";
    public const string InvalidFormat = "INVALID_FORMAT";

    public const string EmailRequired = "EMAIL_REQUIRED";
    public const string InvalidEmail = "INVALID_EMAIL";

    public const string PasswordRequired = "PASSWORD_REQUIRED";
    public const string PasswordMinLength = "PASSWORD_MIN_LENGTH";
    public const string PasswordWeak = "PASSWORD_WEAK";

    public const string FirstNameRequired = "FIRST_NAME_REQUIRED";
    public const string FirstNameMaxLength = "FIRST_NAME_MAX_LENGTH";

    public const string LastNameRequired = "LAST_NAME_REQUIRED";
    public const string LastNameMaxLength = "LAST_NAME_MAX_LENGTH";

    public const string EnumRequired = "ENUM_REQUIRED";
    public const string InvalidEnumValue = "INVALID_ENUM_VALUE";

    public const string BooleanRequired = "BOOLEAN_REQUIRED";

    public const string DateRangeInvalid = "DATE_RANGE_INVALID";
    public const string DateRangeTooLarge = "DATE_RANGE_TOO_LARGE";
    public const string DeadlineRequired = "DEADLINE_REQUIRED";
    public const string DeadlineMustBeFuture = "DEADLINE_MUST_BE_FUTURE";

    public const string NoFieldsToUpdate = "NO_FIELDS_TO_UPDATE";
}