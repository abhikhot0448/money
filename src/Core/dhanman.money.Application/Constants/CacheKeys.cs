namespace Dhanman.Money.Application.Constants;

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

}