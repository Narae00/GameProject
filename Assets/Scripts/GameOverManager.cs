using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text m_Score;
    public Text m_BestScore;

    void Start()
    {
        m_Score.text = "SCORE : " + DataManager.instance.Load_Score().ToString();

        m_BestScore.text = "BEST SCORE : " + DataManager.instance.Load_BestScore().ToString();
    }

    public void ChangeScene_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeScene_InGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
