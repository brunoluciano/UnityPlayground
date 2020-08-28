using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Transition;

public class Grid : MonoBehaviour
{
    public GameObject boxOriginal;
    public GameObject[,] box = new GameObject[9,9];

    void Start()
    {
        validaGrid();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void validaGrid()
    {

        for (int i = 0; i < box.GetLength(0); i++) {
            for (int j = 0; j < box.GetLength(1); j++) {
                GameObject boxGrid = Instantiate(boxOriginal, new Vector3(0, 0, 0), Quaternion.identity);
                boxGrid.transform.SetParent(GameObject.FindGameObjectWithTag("Grid").transform, false);

                box[i,j] = boxGrid;

                // GameObject text = box[i,j].transform.GetChild(0).gameObject;
                // text.GetComponent<Text>().text = (Random.Range(1, 10)).ToString();
            }
        }

        for (int i = 0; i < box.GetLength(0); i++) {
            ArrayList vetAux = new ArrayList(9) {1,2,3,4,5,6,7,8,9};

            for (int j = 0; j < box.GetLength(1); j++) {
                bool possuiNumeroLinha = true;
                bool possuiNumeroColuna = true;
                bool possuiNumeroQuadrante = true;

                int numIndice = (Random.Range(0, vetAux.Count));
                string numero = vetAux[numIndice].ToString();

                possuiNumeroLinha = verificaLinha(i,numero);
                possuiNumeroColuna = verificaColuna(j,numero);  
                possuiNumeroQuadrante = verificaQuadrante(i, j,numero);  

                Debug.Log("Row: " + possuiNumeroLinha + " - Col: " + possuiNumeroColuna + " - Quad: " + possuiNumeroQuadrante + "- Número: " + numero);

                if(possuiNumeroLinha == false && possuiNumeroColuna == false && possuiNumeroQuadrante == false) {
                    GameObject text = box[i,j].transform.GetChild(0).gameObject;
                    text.GetComponent<Text>().text = numero;
                    vetAux.RemoveAt(numIndice);
                } else {
                    GameObject text = box[i,j].transform.GetChild(0).gameObject;
                    text.GetComponent<Text>().text = "99";
                }
            }
        }
    }

    bool verificaLinha(int row, string numero) {
        for(int i = 0; i < box.GetLength(0); i++) {
            GameObject boxChild = box[row,i].transform.GetChild(0).gameObject;
            string boxText = boxChild.GetComponent<Text>().text;
            
            if(boxText == numero) {
                return true;
            }
        }
        return false;
    }

    bool verificaColuna(int col, string numero) {
        for (int j = 0; j < box.GetLength(1); j++) {
            GameObject boxChild = box[j,col].transform.GetChild(0).gameObject;
            string boxText = boxChild.GetComponent<Text>().text;

            if(boxText == numero) {
                return true;
            }
        }
        return false;
    }

    bool verificaQuadrante(int row, int col, string numero) {
        int iIni, iFim, jIni, jFim;

        if(row >= 0 && row <= 3) {
            iIni = 0;
            iFim = 2;
        } else if(row >= 4 && row <= 6) {
            iIni = 3;
            iFim = 5;
        } else {
            iIni = 6;
            iFim = 8;
        }

        if(col >= 0 && col <= 3) {
            jIni = 0;
            jFim = 2;
        } else if(col >= 4 && col <= 6) {
            jIni = 3;
            jFim = 5;
        } else {
            jIni = 6;
            jFim = 8;
        }

        for (int i = iIni; i < iFim; i++) {
            for (int j = jIni; j < jFim; j++) {
                GameObject boxChild = box[i,j].transform.GetChild(0).gameObject;
                string boxText = boxChild.GetComponent<Text>().text;

                if(boxText == numero) {
                    return true;
                }
            }
        }

        return false;
    }


}
