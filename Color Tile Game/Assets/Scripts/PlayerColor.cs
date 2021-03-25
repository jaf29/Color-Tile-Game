using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColor : MonoBehaviour
{
    public static Color col;

    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Saves selected color to variable
    private void TaskOnClick()
    {
        col = btn.GetComponent<Image>().color;
    }
}
