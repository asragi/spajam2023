using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLog : MonoBehaviour, ILog
{
    public void Log(string text) {
        Debug.Log(text);
    }
}
