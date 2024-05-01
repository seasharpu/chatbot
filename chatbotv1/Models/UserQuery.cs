public class UserQuery {
    public int Id { get; set; }
    public User? User { get; set; }
    public string InputText { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public History History { get; set; } = default!;
}