using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class TransicaoPanel : MonoBehaviour
{
    public bool menuEmCima;
    public Vector3 posicaoInicial;
    public float velocidadeTransicao;
    public LeanEase tipoTransicao;

    void Start()
    {
        menuEmCima = true;
        posicaoInicial = transform.localPosition;
    }

    void Update()
    {
        if (menuEmCima)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit hit = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {

                    
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        Debug.Log("Click!!!");
                    }
                    else
                    {
                        Debug.Log("Click outside");
                        moveMenuPraBaixo();
                    }
                }
                else
                {
                    Debug.Log("Click outside of any object");
                    
                }
            }
        }
    }

    public void moveMenu()
    {
        if(menuEmCima)
        {
            moveMenuPraBaixo();
            menuEmCima = false;
        } else {
            moveMenuPraCima();
            menuEmCima = true;
        }
    }

    public void moveMenuPraBaixo()
    {
        transform.
            localPositionTransition(new Vector3(0, posicaoInicial.y-300, 0), velocidadeTransicao, tipoTransicao);
    }
    
    public void moveMenuPraCima()
    {
        transform.
            localPositionTransition(new Vector3(0, posicaoInicial.y, 0), velocidadeTransicao, tipoTransicao);
    }
}
