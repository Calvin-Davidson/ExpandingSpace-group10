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
            mv.jumpCount = 0;
        }
    }
}
