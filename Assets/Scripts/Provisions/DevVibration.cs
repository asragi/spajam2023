using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevVibration : MonoBehaviour
{
    [SerializeField]
    private RLog _rLog;
    private ILog _logger;
    // Start is called before the first frame update
    void Awake() {
        Initialize(_rLog);
    }

    public void Initialize(ILog logger) {
        _logger = logger;
    }

    public void OnClick() {
        _logger.Log("Click vibration button");
        var vibrate = new RVibration();
        vibrate.VibrateLong();
        if (!SystemInfo.supportsVibration) {
            _logger.Log("vibration not supported");
        }
    }
}
