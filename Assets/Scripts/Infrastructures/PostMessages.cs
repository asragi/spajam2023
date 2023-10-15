using System;
using System.Collections;
using UnityEngine;

public class PostMessages : MonoBehaviour
{
    private RHttp _http;
    public Action<string> _onComplete;

    public void Initialize(Action<string> onComplete)
    {
        _onComplete = onComplete;
        _http = new(OnComplete, OnError);
    }


    public void Post(PostMessagesRequest req)
    {
        string json = JsonUtility.ToJson(req);
        Debug.Log($"POST{req.text}");
        StartCoroutine(_http.Post(json, EndPoint.MessageURL));
        Debug.Log($"POSTED{req.text}");
    }

    private void OnComplete(string body)
    {
        var res = JsonUtility.FromJson<GetMessageResponse>(body);
        _onComplete(body);
    }

    private void OnError(string message) {
        Debug.LogError(message);
    }
}
