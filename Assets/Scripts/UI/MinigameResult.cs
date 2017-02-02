﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class MinigameResult : MonoBehaviour
{
    MinigameManager minigameManager;
    MinigameTimeTracker minigameTimeTracker;
    public Image P1_Bar, P2_Bar, P3_Bar, P4_Bar;
    float speed = 2f;
    int maxScore = 7000;

    //Tracks and playersScores P1-4 scores in odrder (playersScore1 - highest)
    public int scorePlace1, scorePlace2, scorePlace3, scorePlace4;

    //List & Array for sorting players'score
    public List<int> allScoresList = new List<int>();
    public int[] allScores = new int[4];

    //Delays between Raising Result Bars
    float delay = 3.5f;
    float firstDelay;
    float secondDelay;
    float ThirdDelay;

    //TEMP.!!! WILL BE RENAMED/REMOVED//
    bool test = true;
    bool test2 = true;
    bool test3 = true;
    bool test4 = true;
    float delay4 = 5f;
    public int P1_Score, P2_Score, P3_Score, P4_Score;      //TEMP.! REPLACE WITH PLAYERS' ACTUAL SCORE//
    //

    private float resultBarAmount(float score, float scoreMin, float scoreMax, float scoreMinFillAmount, float scoreMaxFillAmount)
    {
        return (score - scoreMin) * (scoreMaxFillAmount - scoreMinFillAmount) / (scoreMax - scoreMin) + scoreMinFillAmount;

    }
    void Awake()
    {
        minigameManager = GetComponent<MinigameManager>();
        minigameTimeTracker = GetComponent<MinigameTimeTracker>();

        P1_Bar = GameObject.Find("P1_Panel/Result Bar/Content").GetComponent<Image>();
        P2_Bar = GameObject.Find("P2_Panel/Result Bar/Content").GetComponent<Image>();
        P3_Bar = GameObject.Find("P3_Panel/Result Bar/Content").GetComponent<Image>();
        P4_Bar = GameObject.Find("P4_Panel/Result Bar/Content").GetComponent<Image>();

        firstDelay = delay;
        secondDelay = firstDelay + delay;
        ThirdDelay = secondDelay + delay;
    }

    void Update()
    {
        if (minigameManager.showResultBar)
        {
            GameManager.m_Instance.m_GameState = GameManager.GameState.Dungeon;
            SceneManager.LoadScene(GameManager.m_Instance.m_Tutorial.ToString());
        }
            //SortingScores();

        SetPlayerPlace();
    }

    void SortingScores()
    {
        if (!minigameManager.scoreSorted)
        {
            //Adds all players' scores to an array
            switch (GameManager.m_Instance.m_NumOfPlayers)
            {
                case 1:
                    allScores[0] = P1_Score;
                    break;
                case 2:
                    allScores[0] = P1_Score; allScores[1] = P2_Score;
                    break;
                case 3:
                    allScores[0] = P1_Score; allScores[1] = P2_Score; allScores[2] = P3_Score;
                    break;
                case 4:
                    allScores[0] = P1_Score; allScores[1] = P2_Score; allScores[2] = P3_Score; allScores[3] = P4_Score;
                    break;
            }
            //If statements instead of switch [needs to be a step-by-step removal from the list]
            if (GameManager.m_Instance.m_NumOfPlayers >= 1) //Place 1
            {
                scorePlace1 = allScores.Max();               //Gives Place 1 the highest score from all players
                allScoresList = allScores.ToList();     //Converts Array to List
                allScoresList.Remove(allScores.Max());  //Deletes the highest score that was given to Place 1
                allScores = allScoresList.ToArray();    //Converts List back to Array
            }
            if (GameManager.m_Instance.m_NumOfPlayers >= 2) //Place 2
            {
                scorePlace2 = allScores.Max(); allScoresList = allScores.ToList();
                allScoresList.Remove(allScores.Max()); allScores = allScoresList.ToArray();
            }
            if (GameManager.m_Instance.m_NumOfPlayers >= 3) //Place 3
            {
                scorePlace3 = allScores.Max(); allScoresList = allScores.ToList();
                allScoresList.Remove(allScores.Max()); allScores = allScoresList.ToArray();
            }
            if (GameManager.m_Instance.m_NumOfPlayers >= 4) //Place 4
            {
                scorePlace4 = allScores.Max();
                allScoresList = allScores.ToList(); allScoresList.Remove(allScores.Max()); allScores = allScoresList.ToArray();
                //Now both Array and List are empty but scorePlace1, scorePlace2, scorePlace3, scorePlace4 have sorted scores
            }
            minigameManager.scoreSorted = true;
        }
        RaisingResultBar();
    }

    void SetPlayerPlace()
    {
        if (P1_Score == scorePlace1) minigameManager.P1_place = 1;
        if (P1_Score == scorePlace2) minigameManager.P1_place = 2;
        if (P1_Score == scorePlace3) minigameManager.P1_place = 3;
        if (P1_Score == scorePlace4) minigameManager.P1_place = 4;

        if (P2_Score == scorePlace1) minigameManager.P2_place = 1;
        if (P2_Score == scorePlace2) minigameManager.P2_place = 2;
        if (P2_Score == scorePlace3) minigameManager.P2_place = 3;
        if (P2_Score == scorePlace4) minigameManager.P2_place = 4;

        if (P3_Score == scorePlace1) minigameManager.P3_place = 1;
        if (P3_Score == scorePlace2) minigameManager.P3_place = 2;
        if (P3_Score == scorePlace3) minigameManager.P3_place = 3;
        if (P3_Score == scorePlace4) minigameManager.P3_place = 4;

        if (P4_Score == scorePlace1) minigameManager.P4_place = 1;
        if (P4_Score == scorePlace2) minigameManager.P4_place = 2;
        if (P4_Score == scorePlace3) minigameManager.P4_place = 3;
        if (P4_Score == scorePlace4) minigameManager.P4_place = 4;
    }

    void RaisingResultBar()
    {
        switch (GameManager.m_Instance.m_NumOfPlayers)
        {
            case 1:
                P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                delay4 -= Time.deltaTime;
                if (delay4 < 0)
                    minigameManager.barsRaised = true;
                break;

            case 2:
                if (test)
                {
                    P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace2, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    P2_Bar.fillAmount = Mathf.Lerp(P2_Bar.fillAmount, resultBarAmount(scorePlace2, 0, maxScore, 0, 1), speed * Time.deltaTime);
                }

                firstDelay -= Time.deltaTime;
                if (firstDelay < 0)
                {
                    test = false;
                    if (minigameManager.P1_place == 1)
                        P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    if (minigameManager.P2_place == 1)
                        P2_Bar.fillAmount = Mathf.Lerp(P2_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                }
                delay4 -= Time.deltaTime;
                if (delay4 < 0)
                    minigameManager.barsRaised = true;
                break;

            case 3:
                if (test)
                {
                    P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace3, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    P2_Bar.fillAmount = Mathf.Lerp(P2_Bar.fillAmount, resultBarAmount(scorePlace3, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    P3_Bar.fillAmount = Mathf.Lerp(P3_Bar.fillAmount, resultBarAmount(scorePlace3, 0, maxScore, 0, 1), speed * Time.deltaTime);
                }

                firstDelay -= Time.deltaTime;
                if (firstDelay < 0)
                {
                    test = false;
                    if (test2)
                    {
                        if (minigameManager.P1_place == 1 || minigameManager.P1_place == 2)
                            P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace2, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P2_place == 1 || minigameManager.P2_place == 2)
                            P2_Bar.fillAmount = Mathf.Lerp(P2_Bar.fillAmount, resultBarAmount(scorePlace2, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P3_place == 1 || minigameManager.P3_place == 2)
                            P3_Bar.fillAmount = Mathf.Lerp(P3_Bar.fillAmount, resultBarAmount(scorePlace2, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    }
                }

                secondDelay -= Time.deltaTime;
                if (secondDelay < 0)
                {
                    test2 = false;
                    if (test3)
                    {
                        if (minigameManager.P1_place == 1)
                            P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P2_place == 1)
                            P2_Bar.fillAmount = Mathf.Lerp(P2_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P3_place == 1)
                            P3_Bar.fillAmount = Mathf.Lerp(P3_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    }
                }
                delay4 -= Time.deltaTime;
                if (delay4 < 0)
                    minigameManager.barsRaised = true;
                break;
            case 4:
                if (test)
                {
                    P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace4, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    P2_Bar.fillAmount = Mathf.Lerp(P2_Bar.fillAmount, resultBarAmount(scorePlace4, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    P3_Bar.fillAmount = Mathf.Lerp(P3_Bar.fillAmount, resultBarAmount(scorePlace4, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    P4_Bar.fillAmount = Mathf.Lerp(P4_Bar.fillAmount, resultBarAmount(scorePlace4, 0, maxScore, 0, 1), speed * Time.deltaTime);
                }

                firstDelay -= Time.deltaTime;
                if (firstDelay < 0)
                {
                    test = false;
                    if (test2)
                    {
                        if (minigameManager.P1_place == 1 || minigameManager.P1_place == 2 || minigameManager.P1_place == 3)
                            P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace3, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P2_place == 1 || minigameManager.P2_place == 2 || minigameManager.P2_place == 3)
                            P2_Bar.fillAmount = Mathf.Lerp(P2_Bar.fillAmount, resultBarAmount(scorePlace3, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P3_place == 1 || minigameManager.P3_place == 2 || minigameManager.P3_place == 3)
                            P3_Bar.fillAmount = Mathf.Lerp(P3_Bar.fillAmount, resultBarAmount(scorePlace3, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P4_place == 1 || minigameManager.P4_place == 2 || minigameManager.P4_place == 3)
                            P4_Bar.fillAmount = Mathf.Lerp(P4_Bar.fillAmount, resultBarAmount(scorePlace3, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    }
                }

                secondDelay -= Time.deltaTime;
                if (secondDelay < 0)
                {
                    test2 = false;
                    if (test3)
                    {
                        if (minigameManager.P1_place == 1 || minigameManager.P1_place == 2)
                            P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace2, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P2_place == 1 || minigameManager.P2_place == 2)
                            P2_Bar.fillAmount = Mathf.Lerp(P2_Bar.fillAmount, resultBarAmount(scorePlace2, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P3_place == 1 || minigameManager.P3_place == 2)
                            P3_Bar.fillAmount = Mathf.Lerp(P3_Bar.fillAmount, resultBarAmount(scorePlace2, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P4_place == 1 || minigameManager.P4_place == 2)
                            P4_Bar.fillAmount = Mathf.Lerp(P4_Bar.fillAmount, resultBarAmount(scorePlace2, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    }
                }

                ThirdDelay -= Time.deltaTime;
                if (ThirdDelay < 0)
                {
                    test3 = false;
                    if (test4)
                    {
                        if (minigameManager.P1_place == 1)
                            P1_Bar.fillAmount = Mathf.Lerp(P1_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P2_place == 1)
                            P2_Bar.fillAmount = Mathf.Lerp(P2_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P3_place == 1)
                            P3_Bar.fillAmount = Mathf.Lerp(P3_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                        if (minigameManager.P4_place == 1)
                            P4_Bar.fillAmount = Mathf.Lerp(P4_Bar.fillAmount, resultBarAmount(scorePlace1, 0, maxScore, 0, 1), speed * Time.deltaTime);
                    }
                }
                break;
        }
    }
}
