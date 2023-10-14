using UnityEngine;

public class PostMessages : MonoBehaviour
{
    private RHttp _http;
    void Awake()
    {
        _http = new(OnComplete, OnError);
        Post(new(1, 22, "テストメッセージ"));
    }

    public void Post(PostMessagesRequest req)
    {
        string json = JsonUtility.ToJson(req);
        StartCoroutine(_http.Post(json, EndPoint.MessageURL));
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
