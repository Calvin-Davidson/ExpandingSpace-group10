using System;
using UnityEngine;

namespace Player
{
    public class PullToGround : MonoBehaviour
    {
        private PlayerRotator _playerRotator;
        private Rigidbody2D _PlayerRigid;

        [SerializeField] private bool InAir = false;
        private bool _onGround = false;

        private void Start()
        {
            _PlayerRigid = GetComponent<Rigidbody2D>();
            _playerRotator = GetComponent<PlayerRotator>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W)) return;
            if (_playerRotator.GetLastHit() != Vector2.zero)
            {
                if (InAir)
                {
                    _PlayerRigid.AddForce(-(new Vector2(transform.position.x - _playerRotator.GetLastHit().x,
                        transform.position.y - _playerRotator.GetLastHit().y) * 150));
                }
                else
                {
                    if (!_onGround)
                    {
                        _PlayerRigid.AddForce(-(new Vector2(transform.position.x - _playerRotator.GetLastHit().x,
                            transform.position.y - _playerRotator.GetLastHit().y) * 50));
                    }
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "PlayerInAir") InAir = false;
            if (other.gameObject.name == "WalkableFloor") _onGround = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "PlayerInAir") InAir = true;
            if (other.gameObject.name == "WalkableFloor") _onGround = false;
        }

        public bool getInAir()
        {
            return this.InAir;
        }
    }
}