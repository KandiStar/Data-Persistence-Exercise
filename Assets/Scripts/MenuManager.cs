using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public Text highscoreText;
    public DataManager dataManager;
    public Text nameText;
    private void Awake()
    {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        UpdateScoreBoard();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void UpdateScoreBoard()
    {
        highscoreText.text = "High Score " + dataManager.playername + ": " + dataManager.highscore;
    }
    public void SaveName()
    {
        dataManager.playername = nameText.text;
        UpdateScoreBoard();
        dataManager.SaveData();
    }

    public void ResetScore()
    {
        dataManager.highscore = 0;
        dataManager.playername = null;
        UpdateScoreBoard();
    }
}
