using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField]
    Image _icon;
    [SerializeField]
    IconDict _dict;

    public void Initialize(int foodId)
    {
        _icon.sprite = _dict.Get(foodId);
    }
}