using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public Text textInput;
    public GameObject timerScript;
    public Button buttonConfirm;
    private float timer = 0.0f;

    void Update() {
        if(timerScript.GetComponent<Relogio>().timer <= 0) {
            
            // buttonConfirm.interactable = false;
        } else {
            buttonConfirm.interactable = true;
        }
    }

    public void SetTimerValue() {

        if(timerScript.GetComponent<Relogio>().timer <= 0) {
            SceneManager.LoadScene("AlarmeRelogio");
        }
        
        timer = int.Parse(textInput.text);
        timerScript.GetComponent<Relogio>().timer = timer++;
    }
}
