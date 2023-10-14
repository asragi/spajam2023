using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ChatGPTConnection
{
    private readonly string _apiKey;
    //��b������ێ����郊�X�g
    private readonly List<ChatGPTMessageModel> _messageList = new();

    public ChatGPTConnection(string apiKey)
    {
        _apiKey = apiKey;
    }

    public void SetSystem(string content)
    {
        _messageList.Add(new() { role = "system", content = content });
    }

    public async Task<ChatGPTResponseModel> RequestAsync(string userMessage)
    {
        //���͐���AI��API�̃G���h�|�C���g��ݒ�
        var apiUrl = "https://api.openai.com/v1/chat/completions";

        _messageList.Add(new ChatGPTMessageModel { role = "user", content = userMessage });

        //OpenAI��API���N�G�X�g�ɕK�v�ȃw�b�_�[����ݒ�
        var headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer " + _apiKey},
                {"Content-type", "application/json"},
                {"X-Slack-No-Retry", "1"}
            };

        //���͐����ŗ��p���郂�f����g�[�N������A�v�����v�g���I�v�V�����ɐݒ�
        var options = new ChatGPTCompletionRequestModel()
        {
            model = "gpt-3.5-turbo",
            messages = _messageList
        };
        var jsonOptions = JsonUtility.ToJson(options);

        Debug.Log("����:" + userMessage);

        //OpenAI�̕��͐���(Completion)��API���N�G�X�g�𑗂�A���ʂ�ϐ��Ɋi�[
        using var request = new UnityWebRequest(apiUrl, "POST")
        {
            uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonOptions)),
            downloadHandler = new DownloadHandlerBuffer()
        };

        foreach (var header in headers)
        {
            request.SetRequestHeader(header.Key, header.Value);
        }

        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
            throw new Exception();
        }
        else
        {
            var responseString = request.downloadHandler.text;
            var responseObject = JsonUtility.FromJson<ChatGPTResponseModel>(responseString);
            Debug.Log("ChatGPT:" + responseObject.choices[0].message.content);
            _messageList.Add(responseObject.choices[0].message);
            return responseObject;
        }
    }
}