using UnityEngine;
using UnityEngine.UI;

public class TalkBalloon : MonoBehaviour
{
    [SerializeField]
    Text _text;
    [SerializeField]
    Icon? _icon;

    public void Initialize(string text)
    {
        _text.text = text;
    }

    public void SetIcon(int id)
    {
        _icon?.Initialize(id);
    }
}