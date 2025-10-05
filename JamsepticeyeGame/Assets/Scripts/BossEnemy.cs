using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    public float health = 300f;
    public float dps = 100f;

    private GameObject playerObj;
    private Player player;

    void Start() {
        playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Player>();
    }

    void Update() {
        if (health <= 0f) {
            SceneManager.LoadScene("WinScreen");
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) 
        {
            player.health -= dps * Time.deltaTime;
        } 
    }
}
