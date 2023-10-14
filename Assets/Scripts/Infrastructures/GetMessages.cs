using UnityEngine;

public class GetMessages : MonoBehaviour
{
    private RHttp _http;
    void Awake()
    {
        _http = new(OnComplete, OnError);
        Get(1);
    }

    public void Get(int user_id)
    {
        StartCoroutine(_http.Get($"{EndPoint.MessageURL}?user_id={user_id}"));
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
