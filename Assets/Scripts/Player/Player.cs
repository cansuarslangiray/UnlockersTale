using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float initialSpeed = 5.0f;
    public float speedIncreaseInterval = 50.0f; // How often to increase speed.
    public float speedIncreaseAmount = 1.0f;
    public float maxPlayerSpeed = 25.0f;
    public float leftRightSpeed = 4f;
    private float _currentSpeed;
    private float _timer;
    private CharacterController _playerCharacterController;
    private Animator _playerAnimator;
    private bool _canTurnAgain;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            gameObject.GetComponent<KidsScript>().enabled = false;
            gameObject.GetComponent<Player>().enabled = true;

        }

        _playerCharacterController = GetComponent<CharacterController>();
        _timer = 0;
        _currentSpeed = initialSpeed;
        _playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _timer = Time.deltaTime;
        if (_timer >= speedIncreaseInterval)
        {
            _currentSpeed += speedIncreaseAmount;

            _currentSpeed = Mathf.Min(_currentSpeed, maxPlayerSpeed);
            _timer = 0f;
        }

        _playerCharacterController.Move(transform.forward * _currentSpeed * Time.deltaTime);
        _playerAnimator.SetBool("isRunning", true);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            TurnLeft();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            TurnRight();
        }
    }

    private void TurnLeft()
    {
        if (transform.position.x > -3)
        {
            _playerCharacterController.Move(Vector3.left * leftRightSpeed * Time.deltaTime);
        }
    }

    private void TurnRight()
    {
        if (transform.position.x < 3)
        {
            _playerCharacterController.Move(Vector3.right * leftRightSpeed * Time.deltaTime);
        }
    }
}