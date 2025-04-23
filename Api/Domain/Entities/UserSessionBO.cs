namespace Api.Domain.Entities;

public class UserSessionBO : AbstractEntityBO<long?>
{
    public DateTime CreatedAt { get; private set; }
    public int Attempts { get; private set; }
    public DateTime LastAttemptAt { get; private set; }
    public UserBO User { get; private set; }

    public UserSessionBO(long? id, DateTime createdAt, int attempts, DateTime lastAttemptAt, UserBO user) :
        base(id, createdAt, createdAt)
    {
        CreatedAt = createdAt;
        Attempts = attempts;
        LastAttemptAt = lastAttemptAt;
        User = user;
    }

    public static UserSessionBO NewSession(UserBO user)
    {
        return new UserSessionBO(null, DateTime.Now, 0, DateTime.Now, user);
    }

    public void AttemptLogin()
    {
        Attempts++;
        LastAttemptAt = DateTime.Now;
    }

    public void ResetAttempts()
    {
        Attempts = 0;
    }

    public bool IsTimedOut()
    {
        return Attempts >= 4 && (this.CreatedAt - LastAttemptAt).TotalMinutes > 2;
    }
}
