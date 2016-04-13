using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float hp = 100;
    public float smoothing = 5;
    private Animator anim;
    private PlayerMove playMove;
    private SkinnedMeshRenderer bodyRender;
    private PlayerShoot playerShoot;

    void Awake() {
        anim = this.GetComponent<Animator>();
        playMove = this.GetComponent<PlayerMove>();
        this.bodyRender = GameObject.FindWithTag(Tags.PlayerSkin).GetComponent<Renderer>() as SkinnedMeshRenderer;
        playerShoot = this.GetComponentInChildren<PlayerShoot>();
    }
	// Use this for initialization
	void Start () {
        
	}

    void FixedUpdate() {
        if (bodyRender.material.color != Color.white) {
            bodyRender.material.color = Color.Lerp(bodyRender.material.color,Color.white, smoothing * Time.deltaTime);
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            TakeDamage(20);
        }
    }
    public void TakeDamage(float damage) {
        if (hp <= 0) return;
        this.hp -= damage;
        bodyRender.material.color = Color.red;
        if (hp <= 0) {
            anim.SetBool("Dead", true);
            Dead();
        }
    }

    void Dead() {
        this.playMove.enabled = false;
        this.playerShoot.enabled = false;
    }
}
