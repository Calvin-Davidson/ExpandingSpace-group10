using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    [SerializeField] private float PullStrenght = 10f;

    private Dictionary<GameObject, Rigidbody2D> objects = new Dictionary<GameObject, Rigidbody2D>();

    private void Update()
    {
        if (objects.Count > 0)
        {
            foreach (var set in objects)
            {
                if (set.Key && set.Value)
                {
                    var dx = transform.position.x - set.Key.transform.position.x;
                    var dy = transform.position.y - set.Key.transform.position.y;

                    if (set.Key.gameObject.tag == "Player" && GetComponentInParent<PlanetData>().hasPlayerOnIt())
                    {
                        set.Value.AddForce(
                            new Vector2(dx * (PullStrenght / 3) * Time.deltaTime,
                                dy * (PullStrenght / 3) * Time.deltaTime),
                            ForceMode2D.Force);
                    }
                    else
                    {
                        set.Value.AddForce(
                            new Vector2(dx * PullStrenght * Time.deltaTime, dy * PullStrenght * Time.deltaTime),
                            ForceMode2D.Force);
                    }
                }
                else
                {
                    objects.Remove(set.Key);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            objects.Add(other.gameObject, rb);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            objects.Remove(other.gameObject);
        }
    }
}