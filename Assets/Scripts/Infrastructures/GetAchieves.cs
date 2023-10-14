using UnityEngine;

public class GetAchieves : MonoBehaviour
{
    private RHttp _http;
    void Awake()
    {
        _http = new(OnComplete, OnError);
        Get(1);
    }

    public void Get(int user_id)
    {
        StartCoroutine(_http.Get($"{EndPoint.AchievementURL}?user_id={user_id}"));
    }

    private void OnComplete(string body)
    {
        var res = JsonUtility.FromJson<GetAchievementResponse>(body);
        foreach (var item in res.achievements) {
            Debug.Log(item.name);
        }
    }

    private void OnError(string message) {
        Debug.LogError(message);
    }
}
