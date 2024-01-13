using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Text timeText;

    public int duration;

    private int remainingDuration;

    private void Start(){
        Begin(duration);
    }

    private void Begin(int second){
        remainingDuration = second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer(){
        while(remainingDuration > 0){
            timeText.text = $"{remainingDuration}";
            fillImage.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration / (float) duration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd(){ // this method can be used if we want to do something at the end

    }
}
