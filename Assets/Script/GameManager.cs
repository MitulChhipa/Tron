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
    [SerializeField] private GameObject BlueWonPanel;
    [SerializeField] private GameObject RedWonPanel;
    [SerializeField] private GameObject DrawPanel;
    private int playerScore;
    private int enemyScore;

    private void Start()
    {
        redScore.text = enemyScore.ToString();
        blueScore.text = playerScore.ToString();
        BlueWonPanel.SetActive(false);
        RedWonPanel.SetActive(false);
        DrawPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        if(Time.time%10==0 && Time.time!=0)
        {
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
        RedWonPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void blueWon()
    {
        BlueWonPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void draw() 
    {
        DrawPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
