﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 1;

    private Rigidbody _rigidbody;
    private Animator anim;
    private int groundLayerIndex = -1;
	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        groundLayerIndex = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //控制移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(h, 0, v) * speed*Time.deltaTime);
        _rigidbody.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);

        //控制转向
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 200, groundLayerIndex)) {
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }

        //控制动画
        if (h != 0 || v != 0) {
            anim.SetBool("Move", true);
        } else {
            anim.SetBool("Move", false);
        }

	}
}
