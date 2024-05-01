using chatbotv1.Models.OpenAI;

public class History
{
    public int Id { get; }
    public List<IMessage> Messages { get; }
    public History(User user) {
        Messages = [];
        User = user;
    }
    public User User{ get; set; }

    public History AddMessage(IMessage message)
    {
        Messages.Add(message);
        return this;
    }
}