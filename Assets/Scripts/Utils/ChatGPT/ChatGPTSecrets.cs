using UnityEngine;

// TODO: secrets‚ğScriptableObject‚ÅŠÇ—‚µ‚Ä‚æ‚¢‚í‚¯‚ª‚È‚¢
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChatGPTSecrets")]
public class ChatGPTSecrets : ScriptableObject
{
    public string API_KEY;
}
