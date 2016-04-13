using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    private float hp = 100;
    private Animator anim;
    private NavMeshAgent agent;
    private EnemyMove enemyMove;
    void Awake() {
        anim = this.GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
        enemyMove = this.GetComponent<EnemyMove>();
    }
    public void TakeDamage(float damage) {
        if (this.hp <= 0) return;

        this.hp -= damage;
        if (this.hp <= 0) {
            Dead();
        }
    }

    void Dead() {
        anim.SetBool("Dead", true);
        agent.enabled = false;
        enemyMove.enabled = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
    }
}
