using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAcceleration
{
    private static readonly int ShakeSpan = 15;
    private static readonly int ShakeCount = 2;
    private Vector3 _acceleration;
    private Vector3 _preAcceleration;
    private float _dotProduct;
    private int _shakeCount;

    public void Update()
    {
        _preAcceleration = _acceleration;
        _acceleration = Input.acceleration;
        _dotProduct = Vector3.Dot(_acceleration, _preAcceleration);
        if (_dotProduct < 0)
        {
            _shakeCount += ShakeSpan;
            return;
        }
        _shakeCount = Mathf.Max(0, _shakeCount - 1);
    }

    public bool CheckShake() {
        if (_shakeCount >= ShakeCount * ShakeSpan) {
            _shakeCount = 0;
            return true;
        }
        return false;
    }

    public int DevShakeCount => _shakeCount;
}
