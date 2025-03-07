using InventoryApi.Domain.Assertions;

namespace InventoryApi.Domain.Entities;

public class UserBO : AbstractEntityBO
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public UserBO(long? id, string name, string email, string password, DateTime createdAt, DateTime updatedAt) :
        base(id, DateTime.Now, DateTime.Now)
    {
        Name = name;
        Email = email;
        Password = password;

        Validate();
    }

    private void Validate()
    {
        Assert.IsNotNull(Name, "User must have a name");
        Assert.IsNotNull(Email, "User must have an email");
        Assert.IsNullOrWhiteSpace(Password, "User must have password");
    }
}
