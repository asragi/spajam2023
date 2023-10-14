using UnityEngine;

public class DevHttp : MonoBehaviour
{
    [SerializeField]
    private RLog _logger;
    private RHttp _http;
    // Start is called before the first frame update
    private void Awake()
    {
        _http = new RHttp(_logger.Log, _logger.Log);
        
    }
    void Start()
    {
        StartCoroutine(_http.Get("https://weather.tsukumijima.net/api/forecast/city/400040"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
