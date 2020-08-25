using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonteiroSegundo : MonoBehaviour
{
    public GameObject timerScript;

    private float timer = 0.0f;
    private float anguloSegundo = 0.0f;
    private float segundo = 0.0f;  

    private Relogio relogioScript;

    void Start()
    {
        anguloSegundo = 360 / 60;
        relogioScript = GameObject.FindWithTag("Timer").GetComponent<Relogio>();        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(!relogioScript.tocandoAlarme) {
            segundo = (int) relogioScript.timer % 60;
        } else {
            segundo = 0;
        }

        transform.rotation = Quaternion.Euler(0, 0,(segundo * anguloSegundo));
    }
}
