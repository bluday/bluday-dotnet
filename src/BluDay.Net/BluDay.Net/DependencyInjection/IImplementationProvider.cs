namespace BluDay.Net.DependencyInjection;

public interface IImplementationProvider
{
    Type ServiceType { get; }

    IReadOnlyList<Type> ImplementationTypes { get; }

    object GetInstance(Type implementationType);
}