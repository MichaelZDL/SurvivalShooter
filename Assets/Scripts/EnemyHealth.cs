using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    
    public AudioClip deathClip;
    public ParticleSystem particleSys;
    public float hp = 100;
    private Animator anim;
    private NavMeshAgent agent;
    private EnemyMove enemyMove;
    private EnemyAttack enemyAttack;

    void Awake() {
        anim = this.GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
        enemyMove = this.GetComponent<EnemyMove>();
        enemyAttack = this.GetComponent<EnemyAttack>();
    }
    public void TakeDamage(float damage,Vector3 hitPoint) {
        if (this.hp <= 0) return;

        this.hp -= damage;
        particleSys.transform.position = hitPoint;
        particleSys.Play();
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
        enemyAttack.enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;
        AudioSource.PlayClipAtPoint(deathClip, transform.position, 1.0f);
        anim.SetBool("Dead", true);
        agent.enabled = false;
        enemyMove.enabled = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
    }
}
