namespace BluDay.Net.Common.DependencyInjection;

public interface IImplementationProvider
{
    Type ServiceType { get; }

    object GetInstance(Type implementationType);
}