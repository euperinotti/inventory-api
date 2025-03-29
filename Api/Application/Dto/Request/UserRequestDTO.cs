namespace Api.Application.Dto.Request;

public class UserRequestDTO
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
