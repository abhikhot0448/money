using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.InvoicePayments.Commands
{
    public class CreateInvoicePaymentCommand : ICommand<Result<EntityCreatedResponse>>
    {
        #region Properties
        public Guid ClientId { get; }
        public Guid InvoicePaymentId { get; }
        public decimal Amount { get; }
        public Guid InvoiceHeaderId { get; }
        public Guid TransactionId { get; }
        public Guid COAId { get; }
        #endregion

        #region Constructor
        public CreateInvoicePaymentCommand(Guid invoicePaymentId, Guid clientId, decimal amount, Guid invoiceHeaderId, Guid transactionId, Guid cOaId)
        {
            InvoicePaymentId = invoicePaymentId;
            ClientId = clientId;
            Amount = amount;
            InvoiceHeaderId = invoiceHeaderId;
            TransactionId = transactionId;
            COAId = cOaId;
        }
        #endregion

    }
}
