namespace TMPPP.Domain.Entities;

public abstract class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    // public string Password { get; set; }
    public string Email { get; set; }
    public UserRole UserRole { get; set; }

    protected User(string name, string email)
    {
        Name = name;
        Email = email;
    }
    protected User() { }//ef
}
