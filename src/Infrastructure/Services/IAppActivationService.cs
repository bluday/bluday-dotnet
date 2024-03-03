namespace BluDay.Net.Services;

public interface IAppActivationService
{
    bool IsActivated { get; }

    void Activate();
}