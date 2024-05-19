using chatbotv1.Models.OpenAI;

public class History
{
    public int Id { get; set;}
    public List<IMessage> Messages { get; } = new List<IMessage>();
    public User User{ get; set; } = default!;

    public History AddMessage(IMessage message)
    {
        Messages.Add(message);
        return this;
    }
}