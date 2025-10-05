using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHandler : MonoBehaviour
{
    public List<Collectible> collectedCollectibles;

    void Start() {
        collectedCollectibles = new List<Collectible>();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("collectible")) {
            coll.gameObject.SetActive(false); 
            collectedCollectibles.Add(coll.gameObject.GetComponent<Collectible>());

            // if y'all wanna add effects when collected, add it here
        }
    }
}
