using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider Slider;
    public float health = 100f;
    public bool isGhost = false;
    public float ghostTime = 10f; // in seconds, low number for testing
    [SerializeField] private Animator animator; //added by mel to handle animation transitions

    private float timeSpendAsGhost = 0f;

    void Update()
    {

        Slider.value = health;

        if (isGhost) {
            timeSpendAsGhost += Time.deltaTime;

            if (timeSpendAsGhost >= ghostTime) { // ghost timer runs out
                SceneManager.LoadScene("LoseScreen");
            }
        }
        
        if (health <= 0f) {
            isGhost = true;
            health = 100f; // assuming ghosts can die
            animator.SetBool("isGhost", isGhost);
        }

        
    }
}
