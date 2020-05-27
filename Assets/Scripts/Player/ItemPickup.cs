using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player
{
    public class ItemPickup : MonoBehaviour
    {
        private List<ItemData> playerInventory;
        [SerializeField] private AudioSource PickupSound;
        private void Start()
        {
            playerInventory = GetComponent<PlayerManager>().GetPlayerData().getinventory();
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "PickupItem")
            {
                playerInventory.Add(other.gameObject.GetComponent<ItemData>());
                
                PickupSound.Play();
                
                Destroy(other.gameObject);

                List<string> messages = new List<string>();
                messages.Add("goed gedaan breng het items snel terug naar het schip!");
                messages.Add("wouw je hebt een item gevonden, breng hem snel naar het schip");
                messages.Add("items moeten naar het schip gebracht worden.");

                GameObject.Find("dialog").GetComponent<DialogSystem>()
                    .Dialog(0, messages[Random.Range(0, messages.Count)]);
            }
        }
    }
}