using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IconDict : MonoBehaviour
{
    [SerializeField]
    List<Pair> dictionary;
    [System.Serializable]
    public struct Pair
    {
        [SerializeField]
        public Sprite sprite;
        [SerializeField]
        public int foodId;
    }

    private Dictionary<int, Sprite> _sprites;

    public Sprite Get(int id)
    {
        if (_sprites == null)
        {
            _sprites = dictionary.ToDictionary(
                t => t.foodId,
                t => t.sprite);
        }
        return _sprites[id];
    }
}
