namespace dhanman.money.Application.Contracts.Common;

public sealed class EntityCreatedResponse
{
    #region Properties
    public Guid Id { get; }
    #endregion

    #region Constructors
    public EntityCreatedResponse(Guid id) => Id = id;
    #endregion
   
}