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
������̏������݂͈ȉ��̂悤�ɂӂ�܂��Ă��������D
���Ȃ��͎��g�� {aiName} �ł���悤�ɂӂ�܂��Ă��������D
�l�Ԃ̉�b�̂悤�ɁC�񋓂Ȃǂ͂Ȃ�ׂ������C��b���Ńe�L�X�g��Ԃ��Ă��������D
�ԓ��͊Ȍ��ȓ��e�ɂ��Ă��������D
�܂��C�u�ł��܂��v�̎g�p������C�uA��B����I�v�Ƃ����`�ŕԓ����Ă��������D
";
        _chatGPT.SetUp(setUpContent);
    }

    public Task<string> SendMessage(string message)
    {
        return _chatGPT.SendMessage(message);
    }
}
