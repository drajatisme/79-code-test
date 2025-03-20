using FluentValidation;

namespace Skeleton.Application.Common;

public abstract class BaseValidator<T> : AbstractValidator<T>
{
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        if (model is not T typedModel)
            throw new ArgumentException($"Model is not of type {typeof(T).Name}", nameof(model));

        var context =
            ValidationContext<T>.CreateWithOptions(typedModel, x => x.IncludeProperties(propertyName));
        var result = await ValidateAsync(context);

        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}