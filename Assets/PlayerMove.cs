using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 1;

    private Rigidbody _rigidbody;
    private Animator anim;
	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(h, 0, v) * speed*Time.deltaTime);
        _rigidbody.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);

        if (h != 0 || v != 0) {
            anim.SetBool("Move", true);
        } else {
            anim.SetBool("Move", false);

        }
	}
}
