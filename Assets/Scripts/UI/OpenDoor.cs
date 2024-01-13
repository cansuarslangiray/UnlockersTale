using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Animator animator;
    public GameObject doorPanel;
    private PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        // to get the PlayerInventory component attached to the player
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        // to check whether the player got the key to open the door or not
        if (playerInventory != null && playerInventory.NumberOfKeys > 0)
        {
            animator.SetBool("isOpen", true);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex+1;

            SceneManager.LoadScene(1);
        }
        else 
        {
            animator.SetBool("isOpen", false);
            doorPanel.SetActive(true);
        }

        
    }

    
}
