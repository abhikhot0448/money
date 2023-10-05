﻿namespace Dhanman.Domain.Core.Abstractions;

public interface ISoftDeletableEntity
{
    DateTime? DeletedOnUtc { get; }
    bool IsDeleted { get; }
}
