using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    
    public AudioClip deathClip;
    private ParticleSystem particleSystem;
    private float hp = 100;
    private Animator anim;
    private NavMeshAgent agent;
    private EnemyMove enemyMove;
    void Awake() {
        anim = this.GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
        enemyMove = this.GetComponent<EnemyMove>();
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
    }
    public void TakeDamage(float damage,Vector3 hitPoint) {
        if (this.hp <= 0) return;

        this.hp -= damage;
        particleSystem.transform.position = hitPoint;
        particleSystem.Play();
        this.GetComponent<AudioSource>().Play();
        if (this.hp <= 0) {
            Dead();
        }
    }

    void Update() {
        if (hp <= 0) {
            transform.Translate(Vector3.down * Time.deltaTime * 0.05f);
            if (transform.position.y <= -0.8f) {
                
                Destroy(this.gameObject);
            }
        }
    }
    void Dead() {
        AudioSource.PlayClipAtPoint(deathClip, transform.position, 1.0f);
        anim.SetBool("Dead", true);
        agent.enabled = false;
        enemyMove.enabled = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
    }
}
