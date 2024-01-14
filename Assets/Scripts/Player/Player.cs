using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public static int Coins = 0;
    public float speedIncreaseInterval = 5.0f;
    public float speedIncreaseAmount = 1.0f;
    public float maxPlayerSpeed = 25.0f;
    public float leftRightSpeed = 4f;
    public float currentSpeed;
    private float _timer;
    public bool hasKey;
    public GameObject endText;
    public GameObject gameOverText;
    public Animator doorAnimator;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI coinText;
    private CharacterController _playerCharacterController;
    private Animator _playerAnimator;
    [SerializeField] private float levelLoadDelay = 1f;
    public GameObject deadTexture;

    void Start()
    {
        _playerCharacterController = GetComponent<CharacterController>();
        _timer = 0;
        currentSpeed = 3f;
        _playerAnimator = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            gameObject.GetComponent<KidsScript>().enabled = false;
            gameObject.GetComponent<Player>().enabled = true;
            _playerAnimator.SetBool("isRunning", true);
        }
    }

    void Update()
    {
        Movement();
        CheckEnd();
    }

    private void Movement()
    {
        _timer += Time.deltaTime ;
        if (_timer >= speedIncreaseInterval)
        {
            currentSpeed += speedIncreaseAmount;
            
            currentSpeed = Mathf.Min(currentSpeed, maxPlayerSpeed);
            _timer = 0f;
        }


        _playerCharacterController.Move(transform.forward * currentSpeed * Time.deltaTime);
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
        if (transform.position.x > -2)
        {
            _playerCharacterController.Move(Vector3.left * leftRightSpeed * Time.deltaTime);
        }
    }

    private void TurnRight()
    {
        if (transform.position.x < 2)
        {
            _playerCharacterController.Move(Vector3.right * leftRightSpeed * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            hit.transform.GetComponent<Car>().speed = 0;
            transform.GetComponent<CharacterController>().enabled = false;
            deadTexture.SetActive(true);
            //  Time.timeScale = 0f;
            Invoke("LoadLevelAgain", 1.0f);
        }
        else if (hit.gameObject.CompareTag("Key"))
        {
            Destroy(hit.gameObject);
            keyText.text = "1";
            hasKey = true;
        }
        else if (hit.gameObject.CompareTag("EndDoor"))
        {
            gameOverText.SetActive(true);
        }
        else if (hit.gameObject.CompareTag("End"))
        {
            endText.SetActive(true);
            transform.GetComponent<CharacterController>().enabled = false;
            this.enabled = false;
            coinText.text = "Total Coins: " + Coins.ToString();
            Coins = 0;
        }
    }

    private void LoadLevelAgain()
    {
        deadTexture.SetActive(false);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        transform.GetComponent<CharacterController>().enabled = true;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void CheckEnd()
    {
        if (transform.position.z >= 650 && hasKey)
        {
            hasKey = false;
            doorAnimator.SetTrigger("End");
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void TryAgain()
    {
        Invoke("LoadLevelAgain", 1.0f);
    }
}