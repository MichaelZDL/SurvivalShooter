using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float hp = 100;
    private Animator anim;
    private PlayerMove playMove;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        playMove = this.GetComponent<PlayerMove>();
	}

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            TakeDamage(30);
        }
    }
    public void TakeDamage(float damage) {
        if (hp <= 0) return;
        this.hp -= damage;

        if (hp <= 0) {
            anim.SetBool("Dead", true);
            Dead();
        }
    }

    void Dead() {
        this.playMove.enabled = false;
    }
}
