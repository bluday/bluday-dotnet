namespace BluDay.Net.Common.DependencyInjection;

public interface IObjectFactoryInfo
{
    // Should I expose the site?
    // IObjectFactorySite Site { get; }

    Type ServiceType { get; }

    Type ImplementationType { get; }
}