namespace BluDay.Net.Extensions.DependencyInjection;

public interface IImplementationProvider
{
    Type ServiceType { get; }

    object GetInstance(Type implementationType);
}