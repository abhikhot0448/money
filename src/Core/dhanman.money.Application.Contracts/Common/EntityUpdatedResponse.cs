namespace Dhanman.Money.Application.Contracts.Common;

public sealed class EntityUpdatedResponse
{
    #region Constructor
    public EntityUpdatedResponse(Guid id) => Id = id;

    #endregion

    #region Properties

    public Guid Id { get; }

    #endregion
}
