using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsScript : MonoBehaviour
{
  private Animator animator;
  
  public float walkSpeed = 2.0f;
  public float turnSpeed = 100.0f;
  private float horizontalInput;

  void Start()
  {
    animator = this.GetComponent<Animator>();
    
  }

  void Update()
  {
    Walk();
    Run();
  }
  
  
  
  //---------------------------WALK------------------------------------------
  private void Walk()
  {
    bool wKeyPressed = Input.GetKey("w");

    if (wKeyPressed)
    {
      animator.SetBool("isWalking", true); 
      Turn();
    }

    // when player stops pressing w key character will turn back to idle animation
    if(!wKeyPressed)
    {
      animator.SetBool("isWalking", false);
    }
  }

  // --------------------------------RUN-------------------------------------------------
  // This code snippet will be modified
  private void Run()
  {
    bool runKeyPressed = Input.GetKey("z");

    if(runKeyPressed)
    {
      animator.SetBool("isRunning", true);
    }

    // when player stops pressing z key character will make transition to idle animation
    if (!runKeyPressed)
    {
      animator.SetBool("isRunning", false);
    }
  }

  private void Turn()
  {
    if (Input.GetKey("a"))
    {
      // turn left
      transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }
    else if (Input.GetKey("d"))
    {
      // turn right
      transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
  }
  
}

