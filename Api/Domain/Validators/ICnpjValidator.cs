namespace InventoryApi.Domain.Validators;

public interface ICnpjValidator
{
    string Validate(string cnpj);
}
