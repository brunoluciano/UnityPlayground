using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject boxOriginal;
    public float boxWidth;
    public float boxHeight;
    public GameObject[,] box = new GameObject[9,9];

    void Start()
    {
        for (int i = 0; i < box.GetLength(0); i++) {
            for (int j = 0; j < box.GetLength(1); j++)
            {
                // Debug.Log(i + " - " + j);
                GameObject boxGrid = Instantiate(boxOriginal, new Vector3(i*40-Screen.width/2 + 50, j*40 - Screen.height/2 + 50, 0), Quaternion.identity);
                boxGrid.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
