using System;
using UnityEngine;

namespace Player
{
    public class FloorCollision : MonoBehaviour
    {
        private movement mv;

        private void Start()
        {
            mv = GetComponentInParent<movement>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            mv.inAir = false;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            mv.inAir = true;
        }
    }
}