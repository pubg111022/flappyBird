using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEndGame;
    bool isStart = true;
    int gamePoint = 0;
    public Text txtPoint;
    public GameObject panelEndGame;
    public Text txtEndPoint;
    public Button btnRestart;
    void Start()
    {
        Time.timeScale = 0;
        isEndGame = false;
        isStart = true;
        panelEndGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) && isStart)
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
            }
        }

        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        StartGame();
    }
    public void EndGame()
    {
        isStart = false;
        isEndGame = true;
        Time.timeScale = 0;
        panelEndGame.SetActive(true);
    }
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point : " + gamePoint.ToString();
        txtEndPoint.text = "Your Point : " + gamePoint;
    }
}
