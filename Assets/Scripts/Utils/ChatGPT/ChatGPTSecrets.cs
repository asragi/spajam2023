using UnityEngine;

// TODO: secrets��ScriptableObject�ŊǗ����Ă悢�킯���Ȃ�
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChatGPTSecrets")]
public class ChatGPTSecrets : ScriptableObject
{
    public string API_KEY;
}
