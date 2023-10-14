using System;
using UnityEngine;

public class GetAchieves : MonoBehaviour
{
    private RHttp _http;
    private Action<GetAchievementResponse> _onComplete;

    public void Initialize(Action<GetAchievementResponse> onComplete)
    {
        _onComplete = onComplete;
        _http = new(OnComplete, OnError);
    }

    public void Get(int user_id)
    {
        StartCoroutine(_http.Get($"{EndPoint.AchievementURL}?user_id={user_id}"));
    }

    private void OnComplete(string body)
    {
        var res = JsonUtility.FromJson<GetAchievementResponse>(body);
        _onComplete(res);
    }

    private void OnError(string message) {
        Debug.LogError(message);
    }
}
