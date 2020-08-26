using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Transition;

public class Grid : MonoBehaviour
{
    public GameObject boxOriginal;
    public float boxWidth;
    public float boxHeight;
    public GameObject[,] box = new GameObject[9,9];

    private float timer = 0.0f;

    void Start()
    {
        for (int i = 0; i < box.GetLength(0); i++) {
            for (int j = 0; j < box.GetLength(1); j++) {
                // Debug.Log(i + " - " + j);
                GameObject boxGrid = Instantiate(boxOriginal, new Vector3(0, 0, 0), Quaternion.identity);
                boxGrid.transform.SetParent(GameObject.FindGameObjectWithTag("Grid").transform, false);

                box[i,j] = boxGrid;

                GameObject text = box[i,j].transform.GetChild(0).gameObject;



                text.GetComponent<Text>().text = (Random.Range(1, 10)).ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        // timer += Time.deltaTime;

        // if(timer >= 1) {
        //     transform.
        //     localPositionTransition(new Vector3(10, 10, 10), 0.5f).
        //     JoinTransition().
        //     localPositionTransition(new Vector3(1, 1, 1), 0.5f);

        //     Color32 corBox = new Color32(
        //      ( byte )Random.Range( 0, 255 ),        // R
        //      ( byte )Random.Range( 0, 255 ),        // G
        //      ( byte )Random.Range( 0, 255 ),        // B
        //      ( byte )Random.Range( 125, 255 ) );      // A
             
        //     for (int i = 0; i < box.GetLength(0); i++) {
        //         for (int j = 0; j < box.GetLength(1); j++) {
        //             // byte r = Random.Range(0, 255);
        //             // byte g = Random.Range(0, 255);
        //             // byte b = Random.Range(0, 255);
                    

        //             box[i,j].GetComponent<Image>().color = corBox;

        //             GameObject text = box[i,j].transform.GetChild(0).gameObject;
        //             text.GetComponent<Text>().text = (Random.Range(1, 10)).ToString();


        //         }
        //     }
        //     timer = 0;
        // }
    }
}
