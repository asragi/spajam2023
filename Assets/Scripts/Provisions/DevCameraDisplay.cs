using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevCameraDisplay : MonoBehaviour
{
    [SerializeField]
    private RLog _rLog;
    private ILog _logger;
    [SerializeField]
    private RawImage _rawImage;
    private WebCamTexture _cam;
    private WebCamDevice[] _camDevices;

    void Awake() {
        _logger = _rLog;

        _cam = new WebCamTexture();
        _camDevices = WebCamTexture.devices;
        _rawImage.texture = _cam;
        _cam.Play();
        _logger.Log($"Camera Device Count: {_camDevices.Length}");

    }
}
