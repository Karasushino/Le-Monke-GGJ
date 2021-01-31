using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public AnimatorOverrideController Caveman;
	public AnimatorOverrideController AlmostMonke;
	public AnimatorOverrideController Monke;
	public AnimatorOverrideController LEMonke;


	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	public bool isCaveman = false;
	public bool isLeMonke = false;

	//bool dashAxis = false;
	
	// Update is called once per frame
	void Update () {

        if (isLeMonke)
		{
			horizontalMove = 0f;
				return;
			 }


		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump") && isCaveman)
		{
			jump = true;
		}

		if (Input.GetButtonDown("Dash"))
		{
			dash = true;
		}

		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/

	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.gameObject.CompareTag("Banana 1"))
        {
			SwaptoCaveman();
			runSpeed = 30.0f;
        }
		else if(collision.gameObject.CompareTag("Banana 2"))
        {
			GetComponent<Animator>().runtimeAnimatorController = AlmostMonke;
			CharacterController2D.isHairy = true;
		}
		else if(collision.gameObject.CompareTag("Banana 3"))
        {
			GetComponent<Animator>().runtimeAnimatorController = Monke;

		}
		else if (collision.gameObject.CompareTag("Banana 4"))
		{
			GetComponent<Animator>().runtimeAnimatorController = LEMonke;
			isLeMonke = true;
		}
	}

	void SwaptoCaveman()
	{
		GetComponent<Animator>().runtimeAnimatorController = Caveman;
		isCaveman = true;
	}

}
