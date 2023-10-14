using System.Threading.Tasks;

public class UseChatGPT
{
    private readonly ChatGPTSecrets _secrets;
    private readonly ChatGPTConnection _connection;

    public UseChatGPT(ChatGPTSecrets secrets)
    {
        _secrets = secrets;
        _connection = new(_secrets.API_KEY);
    }

    public void SetUp(string content)
    {
        _connection.SetSystem(content);
    }

    public async Task<string> SendMessage(string content)
    {
        if (!CanAPIKeyBeUsed())
            return "メッセージありがとう！";
        
        var task = _connection.RequestAsync(content);
        var result = await task;
        return result.choices[0].message.content;
    }

    private bool CanAPIKeyBeUsed() => !string.IsNullOrEmpty(_secrets.API_KEY);
}
