using chatbotv1.Models.OpenAI;

public class History
{
    public List<IMessage> Messages { get; }
    public History() {
        Messages = [];
    }

    public History AddMessage(IMessage message)
    {
        Messages.Add(message);
        return this;
    }
}