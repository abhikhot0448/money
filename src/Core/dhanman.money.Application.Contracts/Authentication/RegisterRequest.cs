namespace dhanman.money.Application.Contracts.Authentication;

public sealed class RegisterRequest
{
    #region Properties
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
    #endregion

    #region Constructors
    public RegisterRequest()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        ConfirmPassword = string.Empty;
    }
    #endregion

}
