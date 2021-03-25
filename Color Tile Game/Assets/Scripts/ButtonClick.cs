using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public static bool tileCheck = true;

    private Button btn;
    private Color purple = new Color32(143, 0, 254, 255);
    private Color orange = new Color32(254, 161, 0, 255);
    private Color green = new Color32(0, 255, 50, 255);
    private Color yellow = new Color32(255, 255, 0, 255); // -- Color.yellow doesn't work? --
    private int lowEdge = 0;
    private int highEdge = 4;
    private bool mixSuccess = false;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Task change/mix the selected button color
    private void TaskOnClick()
    {
        // White button color change
        if (btn.GetComponent<Image>().color == Color.white && SelectColor.selectCheck == true)
        {
            btn.GetComponent<Image>().color = SelectColor.col;
            SelectColor.selectCheck = false;
            GameManager.turnNum++;
        }

        // Mix selected and surrounding colors
        else if(btn.GetComponent<Image>().color != Color.white && SelectColor.selectCheck == false)
        {
            SearchForButtons(); // Swap between working and test from below

            if (mixSuccess == true)
            {
                GameManager.turnNum++;
                mixSuccess = false;
            }
        }

        WhiteSpaceCheck();
    }

    // Check for white spaces
    private void WhiteSpaceCheck()
    {
        int counter = 0;
        for (int r = 0; r < 5; r++)
        {
            for (int c = 0; c < 5; c++)
            {
                if (PopGrid.gridArray[r, c].GetComponent<Image>().color == Color.white)
                {
                    counter++;
                }
            }
        }

        if (counter <= 0)
        {
            tileCheck = false;
        }
        else
        {
            tileCheck = true;
        }
    }

    // Search grid for selected button - TEST AREA / DEBUG -
    private void SearchForButtonsTest()
    {
        int valueRow;
        int valueCol;
        string valueString = btn.GetComponentInChildren<Text>().text;
        string[] valueSplit = valueString.Split('-');

        valueRow = Convert.ToInt32(valueSplit.GetValue(0));
        valueCol = Convert.ToInt32(valueSplit.GetValue(1));

        // DEBUG
        //print(valueRow);
        //print(valueCol);
        //print(valueString);
        //print(PopGrid.gridArray[valueRow, valueCol].GetComponentInChildren<Text>().text);

        valueRow--;
        valueCol--;

        if (PopGrid.gridArray[valueRow, valueCol].GetComponentInChildren<Text>().text == valueString)
        {
            Color tempD = Color.white;
            Color tempU = Color.white;
            Color tempR = Color.white;
            Color tempL = Color.white;

            // Red mix check with edge checks
            if (PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color == Color.red)
            {
                // Player preference check with selected button mix
                if (GameManager.p1Pref == true)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = purple;
                            tempD = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = orange;
                            tempD = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = purple;
                            tempU = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = orange;
                            tempU = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = purple;
                            tempR = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = orange;
                            tempR = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = purple;
                            tempL = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = orange;
                            tempL = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p1Col == purple && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                            GameManager.p1S += 1;
                        }
                        else if (GameManager.p1Col == orange && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                            GameManager.p1S += 1;
                        }
                        else
                        {
                            if (GameManager.p2Col == purple && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                GameManager.p2S += 1;
                            }
                            else if (GameManager.p2Col == orange && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                GameManager.p2S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != purple && GameManager.p2Col != purple)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                }
                                else if (GameManager.p1Col != orange && GameManager.p2Col != orange)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                }
                            }
                        }
                    }
                }
                else if (GameManager.p1Pref == false)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = purple;
                            tempD = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = orange;
                            tempD = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = purple;
                            tempU = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = orange;
                            tempU = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = purple;
                            tempR = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = orange;
                            tempR = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = purple;
                            tempL = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = orange;
                            tempL = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p2Col == purple && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                            GameManager.p2S += 1;
                        }
                        else if (GameManager.p2Col == orange && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                            GameManager.p2S += 1;
                        }
                        else
                        {
                            if (GameManager.p1Col == purple && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p1Col == orange && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                GameManager.p1S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != purple && GameManager.p2Col != purple)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                }
                                else if (GameManager.p1Col != orange && GameManager.p2Col != orange)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                }
                            }
                        }
                    }
                }
            }

            // Blue mix check with edge checks
            if (PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color == Color.blue)
            {
                // Player preference check with selected button mix
                if (GameManager.p1Pref == true)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = green;
                            tempD = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = purple;
                            tempD = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = green;
                            tempU = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = purple;
                            tempU = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = green;
                            tempR = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = purple;
                            tempR = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = green;
                            tempL = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = purple;
                            tempL = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p1Col == green && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                            GameManager.p1S += 1;
                        }
                        else if (GameManager.p1Col == purple && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                            GameManager.p1S += 1;
                        }
                        else
                        {
                            if (GameManager.p2Col == green && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                GameManager.p2S += 1;
                            }
                            else if (GameManager.p2Col == purple && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                GameManager.p2S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != green && GameManager.p2Col != green)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                }
                                else if (GameManager.p1Col != purple && GameManager.p2Col != purple)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                }
                            }
                        }
                    }
                }
                else if (GameManager.p1Pref == false)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = green;
                            tempD = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = purple;
                            tempD = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = green;
                            tempU = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = purple;
                            tempU = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = green;
                            tempR = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = purple;
                            tempR = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = green;
                            tempL = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = purple;
                            tempL = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p2Col == green && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                            GameManager.p2S += 1;
                        }
                        else if (GameManager.p2Col == purple && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                            GameManager.p2S += 1;
                        }
                        else
                        {
                            if (GameManager.p1Col == green && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p1Col == purple && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                GameManager.p1S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != green && GameManager.p2Col != green)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                }
                                else if (GameManager.p1Col != purple && GameManager.p2Col != purple)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                }
                            }
                        }
                    }
                }
            }

            // Yellow mix check with edge checks
            if (PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color == yellow)
            {
                // Player preference check with selected button mix
                if (GameManager.p1Pref == true)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = orange;
                            tempD = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = green;
                            tempD = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = orange;
                            tempU = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = green;
                            tempU = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = orange;
                            tempR = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = green;
                            tempR = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = orange;
                            tempL = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = green;
                            tempL = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p1Col == orange && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                            GameManager.p1S += 1;
                        }
                        else if (GameManager.p1Col == green && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                            GameManager.p1S += 1;
                        }
                        else
                        {
                            if (GameManager.p2Col == orange && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                GameManager.p2S += 1;
                            }
                            else if (GameManager.p2Col == green && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                GameManager.p2S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != orange && GameManager.p2Col != orange)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                }
                                else if (GameManager.p1Col != green && GameManager.p2Col != green)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                }
                            }
                        }
                    }
                }
                else if (GameManager.p1Pref == false)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = orange;
                            tempD = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = green;
                            tempD = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = orange;
                            tempU = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = green;
                            tempU = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = orange;
                            tempR = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = green;
                            tempR = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = orange;
                            tempL = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = green;
                            tempL = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p2Col == orange && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                            GameManager.p2S += 1;
                        }
                        else if (GameManager.p2Col == green && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                            GameManager.p2S += 1;
                        }
                        else
                        {
                            if (GameManager.p1Col == orange && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p1Col == green && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                GameManager.p1S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != orange && GameManager.p2Col != orange)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                }
                                else if (GameManager.p1Col != green && GameManager.p2Col != green)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    // Search grid for selected button
    private void SearchForButtons()
    {
        int valueRow;
        int valueCol;
        string valueString = btn.GetComponentInChildren<Text>().text;
        string[] valueSplit = valueString.Split('-');

        valueRow = Convert.ToInt32(valueSplit.GetValue(0));
        valueCol = Convert.ToInt32(valueSplit.GetValue(1));

        // DEBUG
        //print(valueRow);
        //print(valueCol);
        //print(valueString);
        //print(PopGrid.gridArray[valueRow, valueCol].GetComponentInChildren<Text>().text);

        valueRow--;
        valueCol--;

        if (PopGrid.gridArray[valueRow, valueCol].GetComponentInChildren<Text>().text == valueString)
        {
            Color tempD = Color.white;
            Color tempU = Color.white;
            Color tempR = Color.white;
            Color tempL = Color.white;

            // Red mix check with edge checks
            if (PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color == Color.red)
            {
                // Player preference check with selected button mix
                if (GameManager.p1Pref == true)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = purple;
                            tempD = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = orange;
                            tempD = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = purple;
                            tempU = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = orange;
                            tempU = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = purple;
                            tempR = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = orange;
                            tempR = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = purple;
                            tempL = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = orange;
                            tempL = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p1Col == purple && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                            GameManager.p1S += 1;
                        }
                        else if (GameManager.p1Col == orange && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                            GameManager.p1S += 1;
                        }
                        else
                        {
                            if (GameManager.p2Col == purple && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                GameManager.p2S += 1;
                            }
                            else if (GameManager.p2Col == orange && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                GameManager.p2S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != purple && GameManager.p2Col != purple)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                }
                                else if (GameManager.p1Col != orange && GameManager.p2Col != orange)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                }
                            }
                        }
                    }
                }
                else if (GameManager.p1Pref == false)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = purple;
                            tempD = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = orange;
                            tempD = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = purple;
                            tempU = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = orange;
                            tempU = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = purple;
                            tempR = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = orange;
                            tempR = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = purple;
                            tempL = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = orange;
                            tempL = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p2Col == purple && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                            GameManager.p2S += 1;
                        }
                        else if (GameManager.p2Col == orange && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                            GameManager.p2S += 1;
                        }
                        else
                        {
                            if (GameManager.p1Col == purple && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p1Col == orange && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                GameManager.p1S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != purple && GameManager.p2Col != purple)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                }
                                else if (GameManager.p1Col != orange && GameManager.p2Col != orange)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                }
                            }
                        }
                    }
                }
            }

            // Blue mix check with edge checks
            if (PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color == Color.blue)
            {
                // Player preference check with selected button mix
                if (GameManager.p1Pref == true)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = green;
                            tempD = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = purple;
                            tempD = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = green;
                            tempU = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = purple;
                            tempU = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = green;
                            tempR = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = purple;
                            tempR = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = green;
                            tempL = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = purple;
                            tempL = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p1Col == green && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                            GameManager.p1S += 1;
                        }
                        else if (GameManager.p1Col == purple && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                            GameManager.p1S += 1;
                        }
                        else
                        {
                            if (GameManager.p2Col == green && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                GameManager.p2S += 1;
                            }
                            else if (GameManager.p2Col == purple && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                GameManager.p2S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != green && GameManager.p2Col != green)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                }
                                else if (GameManager.p1Col != purple && GameManager.p2Col != purple)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                }
                            }
                        }
                    }
                }
                else if (GameManager.p1Pref == false)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = green;
                            tempD = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = purple;
                            tempD = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = green;
                            tempU = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = purple;
                            tempU = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = green;
                            tempR = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = purple;
                            tempR = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == yellow)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = green;
                            tempL = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = purple;
                            tempL = purple;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == purple)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == purple)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p2Col == green && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                            GameManager.p2S += 1;
                        }
                        else if (GameManager.p2Col == purple && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                            GameManager.p2S += 1;
                        }
                        else
                        {
                            if (GameManager.p1Col == green && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p1Col == purple && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                GameManager.p1S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != green && GameManager.p2Col != green)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                }
                                else if (GameManager.p1Col != purple && GameManager.p2Col != purple)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = purple;
                                }
                            }
                        }
                    }
                }
            }

            // Yellow mix check with edge checks
            if (PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color == yellow)
            {
                // Player preference check with selected button mix
                if (GameManager.p1Pref == true)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = orange;
                            tempD = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = green;
                            tempD = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = orange;
                            tempU = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = green;
                            tempU = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = orange;
                            tempR = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = green;
                            tempR = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = orange;
                            tempL = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = green;
                            tempL = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p1Col == orange && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                            GameManager.p1S += 1;
                        }
                        else if (GameManager.p1Col == green && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                            GameManager.p1S += 1;
                        }
                        else
                        {
                            if (GameManager.p2Col == orange && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                GameManager.p2S += 1;
                            }
                            else if (GameManager.p2Col == green && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                GameManager.p2S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != orange && GameManager.p2Col != orange)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                }
                                else if (GameManager.p1Col != green && GameManager.p2Col != green)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                }
                            }
                        }
                    }
                }
                else if (GameManager.p1Pref == false)
                {
                    if (valueRow < highEdge)
                    {
                        // Down
                        if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = orange;
                            tempD = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow + 1, valueCol].GetComponent<Image>().color = green;
                            tempD = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueRow > lowEdge)
                    {
                        // Up
                        if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = orange;
                            tempU = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow - 1, valueCol].GetComponent<Image>().color = green;
                            tempU = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol < highEdge)
                    {
                        // Right
                        if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = orange;
                            tempR = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol + 1].GetComponent<Image>().color = green;
                            tempR = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (valueCol > lowEdge)
                    {
                        // Left
                        if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.red)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = orange;
                            tempL = orange;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == orange)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == orange)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                        else if (PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color == Color.blue)
                        {
                            PopGrid.gridArray[valueRow, valueCol - 1].GetComponent<Image>().color = green;
                            tempL = green;
                            mixSuccess = true;

                            // Player color
                            if (GameManager.p1Col == green)
                            {
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p2Col == green)
                            {
                                GameManager.p2S += 1;
                            }
                        }
                    }

                    if (mixSuccess == true)
                    {
                        if (GameManager.p2Col == orange && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                            GameManager.p2S += 1;
                        }
                        else if (GameManager.p2Col == green && (GameManager.p2Col == tempD || GameManager.p2Col == tempU || GameManager.p2Col == tempR || GameManager.p2Col == tempL))
                        {
                            PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                            GameManager.p2S += 1;
                        }
                        else
                        {
                            if (GameManager.p1Col == orange && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                GameManager.p1S += 1;
                            }
                            else if (GameManager.p1Col == green && (GameManager.p1Col == tempD || GameManager.p1Col == tempU || GameManager.p1Col == tempR || GameManager.p1Col == tempL))
                            {
                                PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                GameManager.p1S += 1;
                            }
                            else
                            {
                                if (GameManager.p1Col != orange && GameManager.p2Col != orange)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = orange;
                                }
                                else if (GameManager.p1Col != green && GameManager.p2Col != green)
                                {
                                    PopGrid.gridArray[valueRow, valueCol].GetComponent<Image>().color = green;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
