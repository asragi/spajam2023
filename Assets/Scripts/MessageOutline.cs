using System;
using UnityEngine;
using UnityEngine.UI;

public class MessageOutline: MonoBehaviour
{
    [SerializeField]
    Text _nameText;
    [SerializeField]
    Text _messageText;

    private Action _onClick;

    public void Initialize(Message message, Action onClick)
    {
        _nameText.text = $"@{message.Writer}";
        _messageText.text = message.Text;
        _onClick = onClick;
    }

    public void OnClick()
    {
        _onClick();
    }
}