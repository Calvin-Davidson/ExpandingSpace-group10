using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class BlackHoleObjectPuller : MonoBehaviour
{
    private Dictionary<GameObject, Rigidbody2D> _rigidbody2Ds = new Dictionary<GameObject, Rigidbody2D>();
    private bool Actived = false;
    
    private void Start()
    {
        // Na 8,5 seconden word hij weer kleiner!
        Destroy(this.gameObject, 8.5f);
        StartCoroutine(activate());
    }

    // A delay before it attracts everything
    private IEnumerator activate()
    {
        yield return new WaitForSeconds(1);
        Actived = true;
    }


    void LateUpdate()
    {
        if (!Actived) return;
        foreach (KeyValuePair<GameObject, Rigidbody2D> set in _rigidbody2Ds)
        {
            if (set.Key == null) _rigidbody2Ds.Remove(set.Key);

            var dx = transform.position.x - set.Key.transform.position.x;
            var dy = transform.position.y - set.Key.transform.position.y;

            set.Value.velocity = new Vector2(dx * 2, dy * 2);
            set.Value.AddForce(
                new Vector2(dx * 100 * Time.deltaTime, dy * 100 * Time.deltaTime),
                ForceMode2D.Force);
        }
    }

    // Add's you to the pulled objects
    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rigidbody2D = other.GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            _rigidbody2Ds.Add(other.gameObject, rigidbody2D);
        }
    }


    // removes you from the pulled objects
    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rigidbody2D = other.GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            _rigidbody2Ds.Remove(other.gameObject);
        }
    }

    // Destroys object if pulled to center
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!Actived) return;
        if (other.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            if (other.gameObject.name == "Player" || other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerManager>().PlayerDie();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}