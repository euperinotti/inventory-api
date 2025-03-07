namespace InventoryApi.Domain.Security;

public interface IEncrypter
{
    string Hash(string data);
    string Hash(object data);
}
