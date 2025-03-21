namespace InventoryApi.Domain.Validators;

public interface IEmailValidator
{
    string Validate(string cpf);
}
