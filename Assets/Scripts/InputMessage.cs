using System;
using UnityEngine;
using UnityEngine.UI;

public class InputMessage: MonoBehaviour
{
    [SerializeField]
    ChatGPTSecrets _secrets;
    InputField _inputField;
    PostMessages _postMessages;
    CreateChatGPTMessage _gpt;

    int userId;
    int foodId;
    string _sendText;

    bool _isPosted;
    bool _isFinish = true;

    Action _refresh;


    public void Initialize(
        int userId,
        int foodId,
        string name,
        Action refresh
        )
    {
        this.userId = userId;
        this.foodId = foodId;
        _refresh = refresh;
        _inputField = GetComponent<InputField>();
        _postMessages = GetComponent<PostMessages>();
        _postMessages.Initialize(OnPostMessage);
        _gpt = new(name, _secrets);
    }

    public void OnSubmit()
    {
        var text = _inputField.text;
        if (string.IsNullOrEmpty(text)) return;
        _sendText = text;
        _inputField.text = "";
        // Post Message
        _postMessages.Post(new(userId, foodId, text, true));
        _isFinish = false;
    }

    private void OnPostMessage(string res)
    {
        Refresh();
        _isPosted = true;
    }

    private void Update()
    {
        if (_isFinish) return;
        StartGPT();
        PostGPT();

        void StartGPT()
        {
            if (!_isPosted) return;
            _isPosted = false;
            ReturnMessage(_sendText);
        }

        void PostGPT()
        {
            if (!shouldPost) return;
            shouldPost = false;
            _postMessages.Post(new(userId, foodId, gptAnswer, false));
            _isFinish = true;
        }
    }

    private void ReturnMessage(string message) {
        // Post Message
        _gpt.SendMessage(message).ContinueWith(r => OnGptPostEnd(r.Result));
    }

    string gptAnswer;
    bool shouldPost;
    private void OnGptPostEnd(string s) {
        Refresh();
        gptAnswer = s;
        shouldPost = true;
    }

    private void Refresh()
    {
        _refresh();
    }
}