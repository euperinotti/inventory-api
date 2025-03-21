using InventoryApi.Domain.Assertions;

namespace InventoryApi.Domain.Entities;

public class UserBO : AbstractEntityBO<long?>
{
    private string _name;
    private string _email;
    private string _password;

    public UserBO(long? id, string name, string email, string password, DateTime createdAt, DateTime updatedAt) :
        base(id, DateTime.Now, DateTime.Now)
    {
        Name = name;
        Email = email;
        Password = password;

        Validate();
    }

    public string Name
    {
        get => _name;
        private set => _name = value;
    }

    public string Email
    {
        get => _email;
        private set => _email = value;
    }

    public string Password
    {
        get => _password;
        private set => _password = value;
    }

    private void Validate()
    {
        Assert.IsNotNull(Name, "User must have a name");
        Assert.IsNotNull(Email, "User must have an email");
        Assert.IsNullOrWhiteSpace(Password, "User must have password");
    }
}
