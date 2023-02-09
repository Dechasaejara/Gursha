namespace Gursha.Domain.Entities;

public class UserEntity
{
    public Guid ID { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

}