using Api.Domain.Assertions;
using Api.Infra.Validators;

namespace Api.Domain.Entities;

public class UserBO : AbstractEntityBO<long?>
{
    private string _name;
    private string _email;
    private string _password;

    public UserBO(long? id, string name, string email, string password, DateTime createdAt, DateTime updatedAt) :
        base(id, createdAt, updatedAt)
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
        Assert.IsNotNullOrWhiteSpace(Name, "User must have a name");
        Assert.IsNotNullOrWhiteSpace(Email, "User must have an email");
        Assert.IsNotNullOrWhiteSpace(Password, "User must have password");

        PasswordValidator validator = new PasswordValidator();
        validator.Validate(Password);
    }

    public void Update(UserBO bo)
    {
        Name = bo.Name;

        UpdatedAtNow();
    }

    public void ResetPassword(string newPassword)
    {
        Password = newPassword;
    }
}
