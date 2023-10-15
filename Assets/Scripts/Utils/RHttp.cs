using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine.Networking;

public class RHttp
{
    private Action<string> _onComplete;
    private Action<string> _onError;
    public RHttp(Action<string> onComplete, Action<string> onError)
    {
        _onComplete = onComplete;
        _onError = onError;

    }

    public IEnumerator Get(string url)
    {
        var req = UnityWebRequest.Get(url);

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.ProtocolError || req.result == UnityWebRequest.Result.ConnectionError)
        {
            _onError(req.error);
            yield break;
        }

        _onComplete(req.downloadHandler.text);
    }

    public IEnumerator Post(string myJson, string url)
    {
        UnityEngine.Debug.Log($"POSTJSON:{myJson}");
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(myJson);
        var request = new UnityWebRequest(url, "POST")
        {
            uploadHandler = new UploadHandlerRaw(postData),
            downloadHandler = new DownloadHandlerBuffer()
        };
        request.SetRequestHeader("Content-Type", "application/json");
        _onComplete("");
        yield return request.Send();
    }
}
