using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeRunner : MonoBehaviour
{
  private Animator animator;

  public float walkSpeed = 2.0f;
  public float turnSpeed = 1.5f;
  [SerializeField] private float runSpeed = 5f;
  private float horizontalInput;
  private CharacterController _controller;

  public Image fillImage;
  public int countdownTime;
  public Text countDownDisplay;
  public GameObject gameOverPanel;
  private bool continueCountDown = true;
  

  void Start()
  {
    if (SceneManager.GetActiveScene().name == "Level3")
    {
      gameObject.GetComponent<Player>().enabled = false;
      gameObject.GetComponent<KidsScript>().enabled = false;
    }
    StartCoroutine(CountDownToEnd());

    animator = transform.GetComponent<Animator>();
    _controller = transform.GetComponent<CharacterController>();

  }

  void Update()
  {
    Walk();
    Run();
    Turn();
  }
  
  IEnumerator CountDownToEnd(){
    while (countdownTime > 0 && continueCountDown) 
    {
      countDownDisplay.text = countdownTime.ToString();     
      yield return new WaitForSeconds(1f);

      countdownTime--;
    }
    
    countDownDisplay.text = countdownTime.ToString();

    if (continueCountDown)
    {
      gameOverPanel.SetActive(true);

      yield return new WaitForSeconds(1f);
    
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
    }
    
  }

  public void StopCountdown() 
  {
    continueCountDown = false;
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

  }
}

