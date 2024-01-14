using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidsScript : MonoBehaviour
{
  private Animator animator;

  public float walkSpeed = 2.0f;
  public float turnSpeed = 1.5f;
  [SerializeField] private float runSpeed = 5f;
  private float horizontalInput;
  private CharacterController _controller;

  void Start()
  {
    if (SceneManager.GetActiveScene().name == "Room")
    {
      gameObject.GetComponent<KidsScript>().enabled = true;
    }

    animator = transform.GetComponent<Animator>();
    _controller = transform.GetComponent<CharacterController>();

  }

  void Update()
  {
    Walk();
    Run();
    Turn();
    //TurnAndMove();
  }



  //---------------------------WALK------------------------------------------
  private void Walk()
  {
    bool wKeyPressed = Input.GetKey("w");

    if (wKeyPressed)
    {
      animator.SetBool("isWalking", true);
      Turn();
      _controller.Move(transform.forward * walkSpeed * Time.deltaTime);

    }

    // when player stops pressing w key character will turn back to idle animation
    if (!wKeyPressed)
    {
      animator.SetBool("isWalking", false);
    }
  }

  // --------------------------------RUN-------------------------------------------------
  // This code snippet will be modified
  private void Run()
  {
    bool runKeyPressed = Input.GetKey(KeyCode.Z);

    if (runKeyPressed)
    {
      animator.SetBool("isRunning", true);
      Turn();
      _controller.Move(transform.forward * runSpeed * Time.deltaTime);
    }

    // when player stops pressing z key character will make transition to idle animation
    if (!runKeyPressed)
    {
      animator.SetBool("isRunning", false);
    }
  }

  private void Turn()
  {
    if (Input.GetKey(KeyCode.A))
    {
      // turn left
      transform.Rotate(0, -90 * Time.deltaTime, 0);

    }
    else if (Input.GetKey(KeyCode.D))
    {
      // turn right
      transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    /*private void TurnAndMove()
    {
      if (Input.GetKey(KeyCode.A))
      {
        _controller.Move(-transform.right * walkSpeed * Time.deltaTime);
  
      }
      else if (Input.GetKey(KeyCode.D))
      {
        _controller.Move( transform.right* walkSpeed * Time.deltaTime);
  
      }
    }
    private void Turn()
    {
      float pos = Input.GetAxis("Mouse X");
      transform.Rotate(0, pos * Time.deltaTime*turnSpeed, 0);
  
    }*/



  }
}

