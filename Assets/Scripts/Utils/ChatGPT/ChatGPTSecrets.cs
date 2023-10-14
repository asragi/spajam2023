using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: secretsをScriptableObjectで管理してよいわけがない
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChatGPTSecrets")]
public class ChatGPTSecrets : ScriptableObject
{
    public string API_KEY;
}
