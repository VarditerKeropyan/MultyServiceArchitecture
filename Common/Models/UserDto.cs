namespace Common.Models;

public class UserDto
{
    public string FullName { get; set; } = null!;
    public float Balance { get; set; } 
}

public class UserEntityDto
{
    public int ID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public float Balance { get; set; }
}