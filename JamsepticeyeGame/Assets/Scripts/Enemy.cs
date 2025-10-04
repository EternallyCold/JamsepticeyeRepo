using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float dps = 50f;

    private GameObject playerObj;
    private Player player;

    void Start() {
        playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Player>();
    }

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) 
        {
            player.health -= dps * Time.deltaTime;
        } 
    }
}
