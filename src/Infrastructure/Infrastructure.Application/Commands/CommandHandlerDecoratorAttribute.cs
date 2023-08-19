namespace Infrastructure.Application.Commands;

[AttributeUsage(AttributeTargets.Class)]
public class CommandHandlerDecoratorAttribute : Attribute
{
    public CommandHandlerDecoratorAttribute(Type decoratorType)
    {
        DecoratorType = decoratorType;
    }

    public Type DecoratorType { get; }
}