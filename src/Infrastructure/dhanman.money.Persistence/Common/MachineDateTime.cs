using Dhanman.Money.Application.Abstractions.Data;

namespace Dhanman.Money.Persistence.Common;

internal sealed class MachineDateTime : IDateTime
{
    public DateTime UtcNow => DateTime.UtcNow;
}
