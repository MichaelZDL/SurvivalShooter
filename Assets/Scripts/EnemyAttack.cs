using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    private float attack = 5;
    public float timePerAttack = 1;
    private float timer;
    void Start() {
        timer = timePerAttack;
    }
    public void OnTriggerStay(Collider col) {
        if (col.tag == Tags.player) {
            timer += Time.deltaTime;
            if (timer >= timePerAttack) {
                timer -= timePerAttack;
                col.GetComponent<PlayerHealth>().TakeDamage(attack);
        }
        


        }
    }
}
