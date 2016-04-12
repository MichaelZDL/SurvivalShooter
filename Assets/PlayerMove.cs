using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 1;

    private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(h, 0, v) * speed*Time.deltaTime);
        rigidbody.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);
	}
}
