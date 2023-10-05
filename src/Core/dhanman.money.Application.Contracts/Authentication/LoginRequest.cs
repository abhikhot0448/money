namespace Dhanman.Money.Application.Contracts.Authentication;

public sealed class LoginRequest
{
    #region Properties
    public string Email { get; set; }

    public string Password { get; set; }
    #endregion

    #region Constructors
    public LoginRequest()
    {
        Email = string.Empty;
        Password = string.Empty;
    }
    #endregion

}