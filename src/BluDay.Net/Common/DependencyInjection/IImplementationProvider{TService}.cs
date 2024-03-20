namespace BluDay.Net.Common.DependencyInjection;

public interface IImplementationProvider<TService> : IImplementationProvider where TService : notnull
{
    TImplementation GetInstance<TImplementation>() where TImplementation : TService, new();
}