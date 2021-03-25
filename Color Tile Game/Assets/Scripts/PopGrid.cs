using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PopGrid : MonoBehaviour

{
    public GameObject prefab;
    public static GameObject[,] gridArray;

    //private int numToCreate = 25;
    private int gridRow = 5;
    private int gridCol = 5;

    // Start is called before the first frame update
    void Start()
    {
        Pop();
    }

    // Creates the amount of buttons to make the grid
    private void Pop()
    {
        gridArray = new GameObject[gridRow, gridCol];

        for (int r = 0; r < gridRow; r++)
        {
            for (int c = 0; c < gridCol; c++)
            {
                gridArray[r, c] = prefab;
                gridArray[r, c].GetComponentInChildren<Text>().text = ((r + 1) + "-" + (c + 1)).ToString();
                gridArray[r, c].GetComponentInChildren<Text>().enabled = true; // -- Hides Button Text --
                gridArray[r, c] = Instantiate(gridArray[r, c].gameObject as GameObject, transform) as GameObject;
                //gridArray[r, c] = PrefabUtility.InstantiatePrefab(gridArray[r, c].gameObject as GameObject, transform) as GameObject; // -- EDITOR ONLY --
                //print(gridArray[r, c].GetComponent<Button>().GetComponentInChildren<Text>().text);
            }
        }

        // DEBUG
        /*
        print(gridArray[0, 0].GetComponentInChildren<Text>().text); //1-1
        print(gridArray[1, 4].GetComponentInChildren<Text>().text); //2-5
        print(gridArray[3, 1].GetComponentInChildren<Text>().text); //4-2
        print(gridArray[4, 0].GetComponentInChildren<Text>().text); //5-1
        */

        // Original button creation
        /*
        for(int i = 0; i < numToCreate; i++)
        {
            prefab = (GameObject)Instantiate(prefab, transform);
            prefab.GetComponent<Button>().GetComponent<Image>().color = Color.white;
            prefab.GetComponentInChildren<Text>().text = (i + 1).ToString();
        }
        */
    }
}
