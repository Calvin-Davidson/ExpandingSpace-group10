using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class OnMeteorCollision : MonoBehaviour
    {
        public PlayerManager playermanager;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "meteoriet")
            {
                playermanager.GetPlayerData().TakeDamage(1);
            }
        }
    }
}