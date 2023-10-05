namespace dhanman.money.Application.Constants;

public static class CacheKeys
{
    #region Custmomers
    public static class Customers
    {
        public const string CacheKeyPrefix = "customers-{0}";

        public const string CustomerList = "GetAllcustomers-{0}-list-{1}";

        public const string CustomerById = "customers-{0}-by-id-{1}";
    }

    #endregion

    #region InvoiceStatus
    public static class InvoiceStatus
    {
        public const string CacheKeyPrefix = "invoiceStatus-{0}";

        public const string InvoiceStatusList = "invoiceStatus-{0}-list-{1}-{2}";

        public const string InvoiceStatusById = "invoiceStatus-{0}-by-id-{1}";
    }
    #endregion

    #region InvoiceDetails
    public static class InvoiceDetails
    {
        public const string CacheKeyPrefix = "InvoiceDetails-{0}";

        public const string InvoiceDetailList = "InvoiceDetails-{0}-list";

        public const string InvoiceDetailById = "InvoiceDetails-{0}-by-id-{1}";
    }

    #endregion

    #region InvoicePayments
    public static class InvoicePayments
    {
        public const string CacheKeyPrefix = "invoicePayments-{0}";

        public const string InvoicePaymentsList = "invoicePayments-{0}-list-{1}-{2}";

        public const string InvoicePaymentById = "invoicePayments-{0}-by-id-{1}";
    }

    #endregion

    #region InvoiceHeaders

    public static class InvoiceHeaders
    {
        public const string CacheKeyPrefix = "invoiceHeaders-{0}";

        public const string InvoiceHeaderList = "invoiceHeaders-{0}-list-{1}";

        public const string InvoiceHeaderById = "invoiceHeaders-{0}-by-id-{1}";
    }

    #endregion

    #region Invoices

    public static class Invoices
    {
        public const string CacheKeyPrefix = "invoices-{0}";

        public const string InvoicesList = "invoices-{0}-list-{1}";

    }
    #endregion

}