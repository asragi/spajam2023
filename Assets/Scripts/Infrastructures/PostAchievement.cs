using UnityEngine;

public class PostAchievement : MonoBehaviour
{
    private RHttp _http;
    void Awake()
    {
        _http = new(OnComplete, OnError);
        Post(new(11, 2));
    }

    public void Post(PostAchievementRequest req)
    {
        string json = JsonUtility.ToJson(req);
        StartCoroutine(_http.Post(json, EndPoint.AchievementURL));
    }

    private void OnComplete(string body)
    {
        var res = JsonUtility.FromJson<GetMessageResponse>(body);
        foreach (var item in res.messages) {
            Debug.Log(item.text);
        }
    }

    private void OnError(string message) {
        Debug.LogError(message);
    }
}
