using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour{
	Animator myAnimator;
	public float speed = 5.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	CharacterController controller;
	float currSpeed, param1;

	void Start(){
		controller = GetComponent<CharacterController>();
		myAnimator = GetComponent<Animator>();   
	}
		
	void Update(){
		param1 = 0;
		if(controller.isGrounded){
			currSpeed = speed;
			param1 = Mathf.Abs(Input.GetAxis("Vertical"));
			myAnimator.SetFloat("Speed", param1);

			transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
			myAnimator.SetFloat("Speed", param1);

			moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= currSpeed;
		}
		if(!myAnimator.IsInTransition(0)){
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}
	}
}