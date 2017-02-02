﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public bool minigameEnded;
    public bool showResultBar;
    public bool scoreSorted;
    public bool barsRaised;
    public bool showRewardCanvas;
    public bool rewardsSelected;

    public int P1_place, P2_place, P3_place, P4_place;      //int from 1 - 4

    public void endMinigame()
    {
        if (minigameEnded == false)
        {
            minigameEnded = true;
        }
    }

    void Update()
    {
        if (rewardsSelected)
        {
            GameManager.m_Instance.m_GameState = GameManager.GameState.Dungeon;
            SceneManager.LoadScene(GameManager.m_Instance.m_Tutorial.ToString());
        }
    }
}
