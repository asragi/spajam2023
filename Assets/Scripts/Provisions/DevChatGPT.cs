using UnityEngine;

public class DevChatGPT : MonoBehaviour
{
    [SerializeField]
    private ChatGPTSecrets _secrets;
    [SerializeField]
    private RLog _logger;
    private UseChatGPT _chatGPT;

    private void Awake()
    {
        _chatGPT = new(_secrets);
        _chatGPT.SendMessage("ping")
            .ContinueWith(res => OnComplete(res.Result));
        _logger.Log("SEND...");
    }

    private void OnComplete(string response)
    {
        _logger.Log(response);
    }
}
