using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static public DataManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    public void Save_Score(int _score)
    {
        PlayerPrefs.SetInt("Score", _score);
    }

    public void Save_BestScore(int _bestscore)
    {
        PlayerPrefs.SetInt("BestScore", _bestscore);
    }

    public int Load_Score()
    {
        return PlayerPrefs.GetInt("Score");
    }

    public int Load_BestScore()
    {
        return PlayerPrefs.GetInt("BestScore");
    }
}
