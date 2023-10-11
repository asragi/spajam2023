using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevCameraDisplay : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImage;
    private WebCamTexture _cam;

    void Awake() {
        _cam = new WebCamTexture();
        _rawImage.texture = _cam;
        _cam.Play();
    }
}
