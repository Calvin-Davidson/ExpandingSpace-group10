using System;
using UnityEngine;

namespace Player
{
    public class PullToGround : MonoBehaviour
    {
        private PlayerRotator _playerRotator;
        private Rigidbody2D _PlayerRigid;

        [SerializeField] private bool InAir = false;

        private void Start()
        {
            _PlayerRigid = GetComponent<Rigidbody2D>();
            _playerRotator = GetComponent<PlayerRotator>();
        }

        private void Update()
        {
            if (_playerRotator.getLastHit() != Vector2.zero)
            {
                if (InAir)
                {
                    _PlayerRigid.AddForce(-(new Vector2(transform.position.x - _playerRotator.getLastHit().x,
                        transform.position.y - _playerRotator.getLastHit().y) * 35));
                }
                else
                {
                    _PlayerRigid.AddForce(-(new Vector2(transform.position.x - _playerRotator.getLastHit().x,
                        transform.position.y - _playerRotator.getLastHit().y) * 50));
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "PlayerInAir") InAir = false;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "PlayerInAir") InAir = true;
        }

        public bool getInAir()
        {
            return this.InAir;
        }
    }
}