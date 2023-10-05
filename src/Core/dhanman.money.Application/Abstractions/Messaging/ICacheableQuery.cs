namespace dhanman.money.Application.Abstractions.Messaging;

public interface ICacheableQuery<out TResponse> : IQuery<TResponse>
{
    #region Methodes

    string GetCacheKey();

    int GetCacheTime() => 10;

    #endregion
}