namespace Api.Domain.Exceptions;

public class AssertException(string message) : Exception(message);

public static class AssertExceptionMessage
{
    public static readonly string INVALID_CNPJ = "Invalid Cnpj";
    public static readonly string INVALID_CNPJ_LENGTH = "Invalid Cnpj length";
}
