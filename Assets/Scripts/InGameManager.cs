using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public Text m_ScoreText;
    public Text m_BestScoreText;

    public Image m_PlayerHPbar;
    public Text m_PlayerHp;

    public Image m_EnemyHPbar;
    public Text m_EnemyHp;

    int m_Score = 0;
    int m_BestScore = 0;

    static public InGameManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        m_BestScore = DataManager.instance.Load_BestScore();
        ChangeData();
    }

    public void Kill_Enemy()
    {
        m_Score += 10;

        if (m_Score > m_BestScore)
        {
            m_BestScore = m_Score;
        }

        ChangeData();
    }

    void ChangeData()
    {
        m_ScoreText.text = "SCORE : " + m_Score.ToString();
        m_BestScoreText.text = "BEST SCORE : " + m_BestScore.ToString();
    }

    public void SaveData()
    {
        DataManager.instance.Save_Score(m_Score);
        DataManager.instance.Save_BestScore(m_BestScore);
    }

    public void Set_PlayerHP(int _maxHP, int _curHP)
    {
        m_PlayerHPbar.fillAmount = (1.0f / _maxHP) * _curHP;

        m_PlayerHp.text = _curHP.ToString() + "/" + _maxHP.ToString();
    }

    public void Set_EnemyHP(int _maxHP, int _curHP)
    {
        GameObject _gameObject = m_EnemyHPbar.rectTransform.parent.parent.gameObject;

        _gameObject.SetActive(true);

        m_EnemyHPbar.fillAmount = (1.0f / _maxHP) * _curHP;

        m_EnemyHp.text = _curHP.ToString() + "/" + _maxHP.ToString();

        if (_curHP <= 0)
            _gameObject.SetActive(false);
    }
}
