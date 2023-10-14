using System.Collections;
using UnityEngine.Networking;

public class RHttp
{
    private readonly ILog _logger;
    public RHttp(ILog logger)
    {
        _logger = logger;
    }

    public IEnumerator Get(string url)
    {
        var req = UnityWebRequest.Get(url);

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.ProtocolError || req.result == UnityWebRequest.Result.ConnectionError)
        {
            _logger.Log(req.error);
            yield break;
        }

        _logger.Log(req.downloadHandler.text);
    }
}
