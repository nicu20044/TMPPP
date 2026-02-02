using TMPPP;

namespace TMPPP_lab1;

public abstract class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }

    protected User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
