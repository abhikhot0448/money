namespace Dhanman.Money.Api.Contracts;

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

   
    public static class Authentication
    {
        public const string Login = "authentication/login";

        public const string Register = "authentication/register";
    }
  

}
