using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {

    public class OnMeteorCollision : MonoBehaviour
    {
        public PlayerManager playermanager;

        private void Start()
        {
            playermanager.GetPlayerData();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "meteoriet")
            {
                Debug.Log("DAMAGE");
                playermanager.GetPlayerData().TakeDamage(1);
            }
        }
    }
}
