using UnityEngine;
using UnityEngine.UI;

public class MessageOutline: MonoBehaviour
{
    [SerializeField]
    Text _nameText;
    [SerializeField]
    Text _messageText;

    public void Initialize(Message message)
    {
        _nameText.text = $"@{message.Writer}";
        _messageText.text = message.Text;
    }
}