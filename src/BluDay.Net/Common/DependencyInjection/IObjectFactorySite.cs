namespace BluDay.Net.Common.DependencyInjection;

public interface IObjectFactorySite
{
    IObjectFactoryInfo Info { get; }

    ObjectFactory Factory { get; }
}