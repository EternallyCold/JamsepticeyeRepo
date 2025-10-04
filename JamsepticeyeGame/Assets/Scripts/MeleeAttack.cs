using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRadius = 3f;
    public float attackArc = 60f; // degrees 
    public float attackDamage = 20f;

    void Update()
    {
        Vector3 worldClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldClickPos.z = 0f; // idk exactly what unity returns, but keeping everything as vec3 makes for cleaner code
        Vector3 dirVec = worldClickPos - gameObject.transform.position;

        if (Input.GetMouseButtonDown(0)) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies) {
                Vector3 enemyPos = enemy.transform.position;
                float dist = (enemyPos - gameObject.transform.position).magnitude;

                if ((Vector3.Angle(dirVec, enemyPos - gameObject.transform.position) <= attackArc / 2f) && (dist <= attackRadius)) {
                    Enemy en = enemy.GetComponent<Enemy>();
                    en.health -= attackDamage;
                }
            }
        }
    }
}
