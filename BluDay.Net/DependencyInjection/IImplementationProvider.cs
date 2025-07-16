namespace BluDay.Net.DependencyInjection;

public interface IImplementationProvider
{
    Type ServiceType { get; }

    IEnumerable<Type> ImplementationTypes { get; }

    object GetInstance(Type implementationType);
}