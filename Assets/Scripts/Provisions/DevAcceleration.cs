using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevAcceralation : MonoBehaviour
{
    [SerializeField]
    private RLog _rLog;
    private ILog _logger;
    private RAcceleration _acc;
    void Awake() {
        _logger = _rLog;
        _acc = new RAcceleration();
    }

    // Update is called once per frame
    void Update()
    {
        _acc.Update();
        var check = _acc.CheckShake();
        _logger.Log(check.ToString());
    }
}
