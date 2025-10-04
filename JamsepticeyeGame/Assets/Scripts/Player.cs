using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public bool isGhost = false;
    public float ghostTime = 10f; // in seconds, low number for testing
    [SerializeField] private Animator animator; //added by mel to handle animation transitions

    private float timeSpendAsGhost = 0f;

    void Update()
    {
        if (isGhost) {
            timeSpendAsGhost += Time.deltaTime;

            if (timeSpendAsGhost >= ghostTime) {
                isGhost = false;
                health = 100f; // assuming health resets to full after ghost time ends 
            }
        }

        if (health <= 0f) {
            isGhost = true;
            health = 100f; // assuming ghosts can die
            animator.SetBool("isGhost", true); //switches player sprite to ghost sprite animation
        }
        else
        {
            animator.SetBool("isGhost", false); //does nothing to the player sprite
        }
    }
}
