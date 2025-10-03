using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoclipWall : MonoBehaviour
{
    private GameObject player;
    private Player playerComponent;

    void Start() 
    {
        player = GameObject.FindWithTag("Player");
        playerComponent = player.GetComponent<Player>();
    }

    void Update() 
    {
        this.GetComponent<Collider2D>().enabled = !playerComponent.isGhost;
    }
}
