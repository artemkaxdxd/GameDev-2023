using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private PlayerController _controller;
  [SerializeField] private Animator _animator;
  [SerializeField] private Button _jumpButton;
  [SerializeField] private Joystick _joystick;

  const float runSpeed = 0.4f;
  //float horizontalMoveButtons = 0f;
  float horizontalMove = 0f;
  bool jump = false;

  private void Awake()
  {
    _jumpButton.onClick.AddListener(() =>
    {
      jump = true;
      _animator.SetBool("IsJumping", true);
    });
  }

  void Update()
  {
    //horizontalMoveButtons = Input.GetAxisRaw("Horizontal") * runSpeed;
    horizontalMove = _joystick.Horizontal * runSpeed;

    _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    if (Input.GetButtonDown("Jump"))
    {
      jump = true;
      _animator.SetBool("IsJumping", true);
    }
  }

  void FixedUpdate()
  {
    _controller.Move(horizontalMove, jump);
    //_controller.Move(horizontalMoveButtons, jump);
    jump = false;
  }

  private void OnDestroy()
  {
    _jumpButton.onClick.RemoveAllListeners();
  }

  public void OnLanding()
  {
    _animator.SetBool("IsJumping", false);
  }
}
