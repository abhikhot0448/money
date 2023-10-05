namespace Dhanman.Domain.Core.Primitives
{
    public sealed class Error : ValueObject
    {
        #region Properties
        public string Code { get; }

        public string Message { get; }

        public static implicit operator string(Error? error) => error?.Code ?? string.Empty;

        internal static Error None => new Error(string.Empty, string.Empty);

        #endregion

        #region Constructors
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }
        #endregion

        #region Methodes
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
        }
        #endregion

    }
}
