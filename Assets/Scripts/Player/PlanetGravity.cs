using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    private readonly Dictionary<GameObject, PlanetData> Planets = new Dictionary<GameObject, PlanetData>();
    [SerializeField] private Rigidbody2D _playerRigid;
    
    private movement _movement;

    private void Start()
    {
        foreach (GameObject planet in GameObject.FindGameObjectsWithTag("planet"))
        {
            Planets.Add(planet, planet.GetComponent<PlanetData>());
        }

        _movement = GetComponent<movement>();
    }

    private void Update()
    {
        if (Planets.Count <= 0)
        {
            Debug.LogWarning("Er bestaan geen planeten ik disable mezelf");
            this.enabled = false;
        }
        

        var found = false;
        foreach (KeyValuePair<GameObject, PlanetData> set in Planets)
        {
            if (set.Value.getAttractPlayer())
            {
                set.Value.GetComponent<MeshRenderer>().material.color = Color.green;
                found = true;
                _playerRigid.gravityScale = 0;

                Vector3 forceDirection = (set.Key.transform.position - transform.position).normalized;
                _playerRigid.AddForce(set.Value.getPullStrenght() * forceDirection);

                if (set.Value.hasPlayerOnIt())
                {
                    set.Value.GetComponent<MeshRenderer>().material.color = Color.yellow;
                }
            }
            else
            {
                set.Value.GetComponent<MeshRenderer>().material.color = Color.black;
            }
        }
    }

    public Dictionary<GameObject, PlanetData> getPlanets()
    {
        return this.Planets;
    }
}