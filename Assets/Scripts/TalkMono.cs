using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkMono : MonoBehaviour
{
    [SerializeField]
    Transform _messageParent;
    [SerializeField]
    TalkBalloon _userBalloon;
    [SerializeField]
    TalkBalloon _foodBalloon;
    [SerializeField]
    InputMessage _inputMessage;

    [SerializeField]
    Text _foodName;
    [SerializeField]
    Icon _icon;

    Animator _animator;


    public void Initialize(
        int userId,
        List<Message> messages,
        int foodId,
        string name,
        Action refresh
        )
    {
        Refresh(messages, foodId);
        _foodName.text = name;
        _icon.Initialize(foodId);

        _animator = GetComponent<Animator>();
        _animator.SetTrigger("in");

        _inputMessage.Initialize(userId, foodId, name, refresh);
    }

    public void Refresh(List<Message> messages, int foodId)
    {
        Debug.Log("RELOAD!!!");
        foreach ( Transform child in _messageParent ) {
            Destroy(child.gameObject);
        }
        foreach (Message m in messages)
        {
            var prefab = m.IsUser ? _userBalloon : _foodBalloon;
            var obj = Instantiate(prefab, _messageParent);
            if (!m.IsUser)
            {
                obj.SetIcon(foodId);
            }
            obj.Initialize(m.Text);
        }
    }
}