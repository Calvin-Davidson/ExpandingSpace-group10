using UnityEngine;

namespace Items
{
    public class ItemData : MonoBehaviour
    {
        [SerializeField] private string UIiconGameObjectName;
        [SerializeField] private Sprite FoundSprite;
        public string getUIgameobjectName()
        {
            return this.UIiconGameObjectName;
        }

        public Sprite getFoundSprite()
        {
            return this.FoundSprite;
        }
    }
}
