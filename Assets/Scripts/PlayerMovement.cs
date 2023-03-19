using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public PlayerController Controller;
  public Animator Animator;
  public float RunSpeed = 0.40f;
  float horizontalMove = 0f;
  bool jump = false;

  void Update()
  {
    horizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

    Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    if (Input.GetButtonDown("Jump"))
    {
      jump = true;
      Animator.SetBool("IsJumping", true);
    }
  }

  void FixedUpdate()
  {
    Controller.Move(horizontalMove, jump);
    jump = false;
  }

  public void OnLanding()
  {
    Animator.SetBool("IsJumping", false);
  }
}
