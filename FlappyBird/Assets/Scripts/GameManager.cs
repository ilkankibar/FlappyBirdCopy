using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject MainMenuPanel;
    public GameObject InGamePanel;
    public TextMeshProUGUI highScoreText;
    public float score;
    private void Start()
    {
        Time.timeScale = 0;
        highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString("0");
    }
    private void Update()
    {
        scoreText.text = score.ToString("0");
    }
    public void StartButton()
    {
        MainMenuPanel.SetActive(false);
        InGamePanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void InstagramButton()
    {
        Application.OpenURL("https://www.instagram.com/nazmiilkankibar/?hl=tr");
    }
}
