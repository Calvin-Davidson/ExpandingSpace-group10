using UnityEngine;

namespace Items
{
    public class ItemData : MonoBehaviour
    {
        [SerializeField] private string UIiconGameObjectName;

        public string getUIgameobjectName()
        {
            return this.UIiconGameObjectName;
        }
    }
}
