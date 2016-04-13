using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public float shootRate = 2;
    public float Attack = 30;
    private float timer = 0;
    private Light light;
    private ParticleSystem particleSys;
    private LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        particleSys = this.GetComponentInChildren<ParticleSystem>();
        lineRenderer = this.GetComponent<Renderer>() as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
	    timer += Time.deltaTime;
        if (timer > 1 / shootRate) {
            timer -= 1/shootRate;
            Shoot();
        }
	}

    void Shoot() {
        light.enabled = true;
        particleSys.Play();
        this.lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)) {
            lineRenderer.SetPosition(1, hitInfo.point);
            //判断当前的射击有没有碰撞到敌人
            if (hitInfo.collider.tag == Tags.Enemy) {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(Attack,hitInfo.point);
            }
        } else {
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
        }

        GetComponent<AudioSource>().Play();

        Invoke("ClearEffect", 0.05f);

    }

    void ClearEffect() {
        light.enabled = false;
        lineRenderer.enabled = false;
    }
}
