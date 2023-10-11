using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RLog : MonoBehaviour, ILog
{
    [SerializeField]
    private TextMeshProUGUI _text;
    private string _textCache = "";

    public void Log(string text) {
        _textCache = _textCache + '\n' + text;
        _text.text = _textCache;
        Debug.Log(text);
    }
}
