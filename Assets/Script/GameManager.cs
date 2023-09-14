using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI redScore;
    [SerializeField] private TextMeshProUGUI blueScore;
    [SerializeField] private GameObject powerCube;
    [SerializeField] private GameObject eventDisplayPanel;
    [SerializeField] private TextMeshProUGUI eventDisplayText;
    private int playerScore;
    private int enemyScore;
    private float timer;

    private void Start()
    {
        redScore.text = enemyScore.ToString();
        blueScore.text = playerScore.ToString();
        eventDisplayPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        if(timer>=10f)
        {
            timer = 0f;
            CreatePowerUp();
        }
    }

    public void playerScoreUpdate(int x)
    {
        playerScore = playerScore + x;
        blueScore.text = playerScore.ToString();
    }

    public void enemyScoreUpdate(int x)
    {
        enemyScore = enemyScore + x;
        redScore.text = enemyScore.ToString();
    }

    public void compareScore()
    {
        if(playerScore > enemyScore)
        {
            blueWon();
        }
        else if(playerScore < enemyScore)
        {
            redWon();
        }
        else if(playerScore == enemyScore)
        {
            draw();
        }
    }

    private void CreatePowerUp()
    {
        Vector3 newCor = new Vector3(Random.Range(-130.0f,130.0f),Random.Range(-70.0f,70.0f),0);
        Instantiate(powerCube,newCor,Quaternion.identity);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void redWon()
    {
        eventDisplayPanel.SetActive(true);
        eventDisplayText.text = "Yellow Won";
        eventDisplayText.color = Color.yellow;
        Time.timeScale = 0f;
    }

    public void blueWon()
    {
        eventDisplayPanel.SetActive(true);
        eventDisplayText.text = "Blue Won";
        eventDisplayText.color = Color.blue;
        Time.timeScale = 0f;
    }

    public void draw() 
    {
        eventDisplayPanel.SetActive(true);
        eventDisplayText.text = "Its a draw";
        eventDisplayText.color = Color.white;
        Time.timeScale = 0f;
    }
}
