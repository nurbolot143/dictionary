using Infrastructure.Seedwork.Validation;

namespace Infrastructure.Application.Commands;

public class CommandHandlerResult
{
    public static readonly CommandHandlerResult Unit = new(value: new object(), error: null);

    private readonly SystemError? _error;

    private readonly object? _value;

    private CommandHandlerResult(object? value, SystemError? error)
    {
        _value = value;
        _error = error;
    }

    public bool IsFailure => _error is not null;
    public SystemError Error => _error ?? throw new InvalidOperationException("Cannot get error, result is in success state");
    public object Value => _value ?? throw new InvalidOperationException("Cannot get value, result is in error state");

    public static CommandHandlerResult Success(object result)
    {
        return new CommandHandlerResult(result, error: null);
    }

    public static CommandHandlerResult Failure(SystemError error)
    {
        return new CommandHandlerResult(null, error);
    }
}