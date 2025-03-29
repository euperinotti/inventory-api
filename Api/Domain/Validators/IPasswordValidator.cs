namespace Api.Domain.Validators;

public interface IPasswordValidator
{
    void Validate(string password);
}
