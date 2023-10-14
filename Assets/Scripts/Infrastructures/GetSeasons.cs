using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSeasons : MonoBehaviour
{
    private RHttp _http;
    void Awake()
    {
        _http = new(OnComplete, OnError);
        Get();
    }

    public void Get()
    {
        StartCoroutine(_http.Get(EndPoint.SeasonURL));
    }

    private void OnComplete(string body)
    {
        var res = JsonUtility.FromJson<GetSeasonResponse>(body);
        foreach (var item in res.seasons) {
            Debug.Log(item.name);
        }
    }

    private void OnError(string message) {
        Debug.LogError(message);
    }
}
