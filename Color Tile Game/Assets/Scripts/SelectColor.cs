using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectColor : MonoBehaviour
{
    public static Color col;
    public static bool selectCheck;

    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        selectCheck = false;
    }

    // Saves selected color to variable and checks if a color is already selected
    private void TaskOnClick()
    {
        if (selectCheck == false)
        {
            col = btn.GetComponent<Image>().color;
            selectCheck = true;
        }
        else if (selectCheck == true && col != btn.GetComponent<Image>().color)
        {
            col = btn.GetComponent<Image>().color;
        }
        else
        {
            selectCheck = false;
        }
    }
}
