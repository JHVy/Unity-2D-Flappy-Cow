﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const string HIGHT_SCORE = "Hight Score";

    void IsGameStartedForTheFirstTime()
    {
        if(!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGHT_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _MakeSingleInstance();
        IsGameStartedForTheFirstTime();
    }

    void _MakeSingleInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        } 
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetHightScore(int score)
    {
        PlayerPrefs.SetInt(HIGHT_SCORE, score);
    }

    public int GetHightScore()
    {
        return PlayerPrefs.GetInt(HIGHT_SCORE);
    }
}
