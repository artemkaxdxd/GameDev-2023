using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public PlayerController Сontroller;
  public float RunSpeed = 0.40f;
  float horizontalMove = 0f;
  bool jump = false;

  void Update()
  {
    horizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

    if (Input.GetButtonDown("Jump"))
    {
      jump = true;
    }
  }

  void FixedUpdate()
  {
    Сontroller.Move(horizontalMove, jump);
    jump = false;
  }
}
