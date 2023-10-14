using UnityEngine;
using UnityEngine.UI;

public class TalkBalloon : MonoBehaviour
{
    [SerializeField]
    Text _text;

    public void Initialize(string text)
    {
        _text.text = text;
    }
}