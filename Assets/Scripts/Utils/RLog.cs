using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RLog : MonoBehaviour, ILog
{
    [SerializeField]
    private TextMeshProUGUI _text;
    private string _textCache = "";
    private int _lineCount = 0;

    public void Log(string text) {
        _lineCount++;
        if (_lineCount > 10) {
            _lineCount = 0;
            _textCache = "";
        }
        _textCache = _textCache + '\n' + text;
        _text.text = _textCache;
        Debug.Log(text);
    }
}
