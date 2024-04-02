namespace BluDay.Net.DependencyInjection;

public interface IImplementationProvider
{
    Type ServiceType { get; }

    object GetInstance(Type implementationType);
}