namespace BluDay.Net.DependencyInjection;

public interface IObjectFactoryInfo
{
    Type ServiceType { get; }

    Type ImplementationType { get; }
}