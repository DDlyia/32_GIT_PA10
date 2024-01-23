using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    [SerializeField] private Text Txt_HighScore = null;
    private int Score = 0;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;
        Txt_HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        
    }

    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
            StartGame();
        UpdateHighScore();
    }

    public void UpdateScore()
    {
        Score ++;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameOver");
    }
    public void UpdateHighScore()
    {
        if (Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score);
            Txt_HighScore.text = Score.ToString();
            
        }
    }
}
