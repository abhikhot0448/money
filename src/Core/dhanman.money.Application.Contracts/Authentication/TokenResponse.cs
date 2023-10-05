namespace dhanman.money.Application.Contracts.Authentication;

public sealed class TokenResponse
{
    #region Properties
    public string Token { get; }
    #endregion

    #region Constructors
    public TokenResponse(string token) => Token = token;
    #endregion

}
