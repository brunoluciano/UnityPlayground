using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Relogio : MonoBehaviour
{

    public float timer;
    public float delay;
    public float velocidadePisca;
    public AudioClip SomAlarme;
    public AudioClip[] SomRelogioTick;
    public Text TextoAcordar;

    private float contPisca = 0.0f; 
    private Text texto;
    private float timerAux;
    private float delayAux;
    private float contTime = 0.0f;
    private float intervaloTick = 1.0f;
    public bool tocandoAlarme = false;
    private int percorreVetorAudio = 0;
    private float tempoTocandoAlarme = 0.0f;
    
    private Color corPadrao = new Color32(112,213,135,255);

    void Start()
    {
        texto = GetComponent<Text>();
        timer++;
        timerAux = timer;
        delayAux = delay;
        // TextoAcordar = GetComponent<Text>();
        TextoAcordar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        contPisca += Time.deltaTime;
        contTime += Time.deltaTime;

        if(timer >= 0) {
            string minutos = Mathf.Floor(timer / 60).ToString("00");
            string segundos = Mathf.Floor(timer % 60).ToString("00");
            texto.text = minutos + ":" + segundos;      
            if(contTime >= intervaloTick){  
                if(percorreVetorAudio >= SomRelogioTick.Length){
                    percorreVetorAudio = 0;
                }

                ControlaAudio.instancia.PlayOneShot(SomRelogioTick[percorreVetorAudio]);
                contTime = 0;
                percorreVetorAudio++;
            }
        } else {
            delay -= Time.deltaTime;
            texto.color = Color.red;
            tempoTocandoAlarme += Time.deltaTime;
            TextoAcordar.enabled = true;

            if(tocandoAlarme) {
                if(!ControlaAudio.instancia.isPlaying) {
                    // if(tempoTocandoAlarme >= SomAlarme.length) {
                    //     tocandoAlarme = false;
                    // }
                    tocaAlarme();
                }
            }
            
            if(tocandoAlarme == false) {
                tocaAlarme();
            }
            
            if(contPisca >= velocidadePisca) {
                texto.enabled = !texto.enabled;
                contPisca = 0;
            }

            if(Input.GetKeyUp(KeyCode.Space)) {
                SceneManager.LoadScene("AlarmeRelogio");
                // texto.color = corPadrao;
                // timer = timerAux;
                // delay = delayAux;
                // TextoAcordar.enabled = false;
                // texto.enabled = true;
                // tocandoAlarme = false;
            }
        }

        //  if(delay <= 0) {
        //     texto.color = corPadrao;
        //     timer = timerAux;
        //     delay = delayAux;
        //     tocandoAlarme = false;
        // }
    }

    void tocaAlarme() {
        tocandoAlarme = true;
        ControlaAudio.instancia.PlayOneShot(SomAlarme);
    }
}
