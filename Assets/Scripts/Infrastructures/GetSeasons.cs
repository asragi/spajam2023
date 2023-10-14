using System;
using UnityEngine;

public class GetSeasons : MonoBehaviour
{
    private RHttp _http;
    private Action<GetSeasonResponse> _onComplete;

    public void Initialize(Action<GetSeasonResponse> onComplete)
    {
        _onComplete = onComplete;
        _http = new(OnComplete, OnError);
    }

    public void Get()
    {
        StartCoroutine(_http.Get(EndPoint.SeasonURL));
    }

    private void OnComplete(string body)
    {
        var res = JsonUtility.FromJson<GetSeasonResponse>(body);
        _onComplete(res);
    }

    private void OnError(string message) {
        Debug.LogError(message);
    }
}
