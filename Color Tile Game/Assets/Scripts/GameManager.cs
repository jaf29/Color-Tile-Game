using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text player1Name;
    public Text player2Name;
    public Text player1Score;
    public Text player2Score;
    public Text turnCounter;
    public Text winText;
    public GameObject winScreen;

    public static Color p1Col;
    public static Color p2Col;
    public static int p1S;
    public static int p2S;
    public static bool p1Pref = false;
    public static int turnNum = 1;

    private Color purple = new Color32(143, 0, 254, 255);
    private Color orange = new Color32(254, 161, 0, 255);
    private Color green = new Color32(0, 255, 50, 255);

    // Start is called before the first frame update
    void Start()
    {
        player1Score.GetComponentInChildren<Text>().text = "0";
        player2Score.GetComponentInChildren<Text>().text = "0";
        turnCounter.GetComponent<Text>().text = "Player " + turnNum + "s Turn";

        // DEBUG
        //player1Name.GetComponent<Text>().color = green;
        //player2Name.GetComponent<Text>().color = orange;
    }

    private void Update()
    {
        player1Score.GetComponent<Text>().text = p1S.ToString();
        player2Score.GetComponent<Text>().text = p2S.ToString();

        // Player turn preference
        if (turnNum % 2 != 0)
        {
            turnNum = 1;
            p1Pref = true;
        }
        else if (turnNum % 2 == 0)
        {
            turnNum = 2;
            p1Pref = false;
        }

        turnCounter.GetComponent<Text>().text = "Player " + turnNum + "s Turn";
        if (ButtonClick.tileCheck == false)
        {
            GameEnd();
            ButtonClick.tileCheck = true;
        }
    }

    public void Player1Color()
    {
        player1Name.GetComponent<Text>().color = PlayerColor.col;
        p1Col = PlayerColor.col;
    }

    public void Player2Color()
    {
        player2Name.GetComponent<Text>().color = PlayerColor.col;
        p2Col = PlayerColor.col;
    }

    // Restarts game
    public void RestartGame()
    {
        p1S = 0;
        p2S = 0;
        turnNum = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Returns to main menu
    public void MainMenu()
    {
        p1S = 0;
        p2S = 0;
        turnNum = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Checks if the game is over
    private void GameEnd()
    {
        winScreen.SetActive(true);

        if (p1S > p2S)
        {
            winText.GetComponent<Text>().text = "Player 1 Wins!";
        }
        else if (p1S < p2S)
        {
            winText.GetComponent<Text>().text = "Player 2 Wins!";
        }
        else
        {
            winText.GetComponent<Text>().text = "Tie Game!";
        }
    }
}
