using dhanman.money.Application.Abstractions.Data;

namespace dhanman.money.Persistence.Common;

internal sealed class MachineDateTime : IDateTime
{
    public DateTime UtcNow => DateTime.UtcNow;
}
