using System.Threading.Tasks;

public class CreateChatGPTMessage
{
    private readonly UseChatGPT _chatGPT;

    public CreateChatGPTMessage(
        string aiName,
        ChatGPTSecrets secrets
        )
    {
        _chatGPT = new(secrets);
        string setUpContent = @$"
次からの書き込みは以下のようにふるまってください．
あなたは自身が {aiName} であるようにふるまってください．
人間の会話のように，列挙などはなるべく避け，会話調でテキストを返してください．
返答は簡潔な内容にしてください．
また，「ですます」の使用を避け，「AはBだよ！」という形で返答してください．
";
        _chatGPT.SetUp(setUpContent);
    }

    public Task<string> SendMessage(string message)
    {
        return _chatGPT.SendMessage(message);
    }
}
