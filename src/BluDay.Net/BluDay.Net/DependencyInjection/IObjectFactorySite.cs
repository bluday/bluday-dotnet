namespace BluDay.Net.DependencyInjection;

public interface IObjectFactorySite
{
    IObjectFactoryInfo Info { get; }

    ObjectFactory Factory { get; }
}