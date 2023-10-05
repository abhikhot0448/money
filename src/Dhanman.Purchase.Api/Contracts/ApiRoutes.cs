namespace dhanman.money.Api.Contracts;

public static class ApiRoutes
{
    public const string apiVersion = "api/v{version:apiVersion}/";
    public static class Customers
    {
        public const string GetCustomers = apiVersion + "GetAllcustomers/{clientId:guid}";

        public const string CreateCustomer = apiVersion + "customers";

        public const string UpdateCustomer = apiVersion + "customer";

        public const string GetCustomerById = apiVersion + "customers/{id:guid}";
    }

    public static class InvoiceStatus
    {
        public const string GetInvoiceStatuses = apiVersion + "invoiceStatuses";

        public const string CreateInvoiceStatuses = apiVersion + "invoiceStatuses";

        public const string GetInvoiceStatusesById = apiVersion + "invoiceStatuses/{id:guid}";
    }

    public static class InvoicePayments
    {
        public const string GetInvoicePayments = apiVersion + "invoicePaymentss";

        public const string CreateInvoicePayments = apiVersion + "invoicePayments";

        public const string GetInvoicePaymentsById = apiVersion + "invoicePayments/{id:guid}";
    }
    public static class Authentication
    {
        public const string Login = "authentication/login";

        public const string Register = "authentication/register";
    }

    public static class InvoiceDetails
    {
        public const string GetInvoiceDetails = apiVersion + "GetAllinvoiceDetails";

        public const string CreateInvoiceDetail = apiVersion + "invoiceDetails";

        public const string GetInvoiceDetailsById = apiVersion + "invoiceDetails/{id:guid}";
    }
    public static class InvoiceHeaders
    {
        public const string GetInvoiceHeaders = apiVersion + "GetAllInvoiceHeaders";

        public const string CreateInvoiceHeaders = apiVersion + "invoiceHeaders";

        public const string GetInvoiceHeaderesById = apiVersion + "invoiceHeaders/{id:guid}";
    }

    public static class Invoices
    {
        public const string GetAllInvoices = apiVersion + "GetAllInvoices/{clientId:guid}";

        public const string CreateInvoice = apiVersion + "invoice";
    }

}
