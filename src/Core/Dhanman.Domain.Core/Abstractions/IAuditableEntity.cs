namespace Dhanman.Domain.Core.Abstractions;

public interface IAuditableEntity
{
    #region Properties
    Guid CreatedBy { get; }
    Guid? ModifiedBy { get; }
    DateTime CreatedOnUtc { get; }
    DateTime? ModifiedOnUtc { get; }
    #endregion

}
