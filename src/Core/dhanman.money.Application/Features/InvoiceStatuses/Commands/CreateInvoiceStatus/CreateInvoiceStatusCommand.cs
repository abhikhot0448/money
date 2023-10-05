using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.InvoiceStatuses.Commands.CreateInvoiceStatus;

public class CreateInvoiceStatusCommand : ICommand<Result<EntityCreatedResponse>>
{
    #region Properties
    public Guid InvoiceStatusId { get; }
    public Guid ClientId { get; }
    public string Name { get; }

    #endregion

    #region Constructors

    public CreateInvoiceStatusCommand(Guid invoiceStatusId, Guid clientId, string name)
    {
        InvoiceStatusId = invoiceStatusId;
        Name = name;
        ClientId = clientId;
    }

    #endregion

}


