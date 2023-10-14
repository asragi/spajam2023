using System;
using UnityEngine;

public class GetMessages : MonoBehaviour
{
    private RHttp _http;
    private Action<GetMessageResponse> _onComplete;

    public void Initialize(Action<GetMessageResponse> onComplete)
    {
        _onComplete = onComplete;
        _http = new(OnComplete, OnError);
    }

    public void Get(int user_id)
    {
        StartCoroutine(_http.Get($"{EndPoint.MessageURL}?user_id={user_id}"));
    }

    private void OnComplete(string body)
    {
        var res = JsonUtility.FromJson<GetMessageResponse>(body);
        _onComplete(res);
    }

    private void OnError(string message) {
        Debug.LogError(message);
    }
}
