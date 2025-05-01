using Api.Domain.Exceptions;
using Api.Domain.Validators;

namespace Api.Infra.Validators;

public class CnpjValidator : ICnpjValidator
{
    public void Validate(string cnpj)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int resto;
        string digito;
        string tempCnpj;

        cnpj = Sanitize(cnpj);

        if (cnpj.Length != 14)
        {
            throw new ValidationException(AssertExceptionMessage.INVALID_CNPJ_LENGTH);
        }

        tempCnpj = cnpj.Substring(0, 12);

        resto = CalculateChars(tempCnpj, multiplicador1);

        digito = resto.ToString();
        tempCnpj = tempCnpj + digito;

        resto = CalculateChars(tempCnpj, multiplicador2);

        digito = digito + resto.ToString();

        if (!cnpj.EndsWith(digito))
        {
            throw new ValidationException(AssertExceptionMessage.INVALID_CNPJ);
        }
    }

    private string Sanitize(string cnpj)
    {
        return cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
    }

    private int CalculateChars(string cnpj, int[] multipliers)
    {
        int soma = cnpj.Select((t, i) => int.Parse(t.ToString()) * multipliers[i]).Sum();

        int resto = soma % 11;

        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }

        return resto;
    }
}
