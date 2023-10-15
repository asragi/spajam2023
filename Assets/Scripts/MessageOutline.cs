using System;
using UnityEngine;
using UnityEngine.UI;

public class MessageOutline: MonoBehaviour
{
    [SerializeField]
    Text _nameText;
    [SerializeField]
    Text _messageText;
    [SerializeField]
    Icon _icon;
    [SerializeField]
    GameObject _notify;

    private Action _onClick;

    public void Initialize(Message message, Action onClick)
    {
        _nameText.text = $"@{message.Writer}";
        _messageText.text = message.Text;
        _onClick = onClick;
        _icon.Initialize(message.FoodId);

        // for presentation
        int id = message.FoodId;
        if (id == 1 || id == 4)
        {
            _notify.SetActive(true);
        }
    }

    public void OnClick()
    {
        _onClick();
    }
}