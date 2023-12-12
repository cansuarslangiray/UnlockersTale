using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtons : MonoBehaviour
{
    public Button okButton;
    public GameObject keyPanel;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = okButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        keyPanel.SetActive(false);
    }
}
