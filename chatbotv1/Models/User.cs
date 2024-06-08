public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime lastActivity { get; set; }
}

//RECENT DTO EDIT
public class UsernameDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
}

//RECENT DTO EDIT
public class UsernameAndPasswordDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
