﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinigameTimeTracker : MonoBehaviour
{
    MinigameManager minigameManger;

    public CanvasGroup FirstFadingCanvas;
    public CanvasGroup SecondFadingCanvas;

    CanvasGroup rewardFadeInCanvas;
    Image startCountdownImage;
    public Sprite[] startCountdownTextures;

    float minigameTimerRaw;     //floats gets rounded to "minigameTimer" int in Update
    public int minigameTimer;

    float fadeTime = 2f;

    //Screen Fading floats
    float delayToFadeIn = 1f;
    float delayToShowResultBar = 2f;
    void Awake()
    {
        minigameManger = GetComponent<MinigameManager>();
        FirstFadingCanvas = GameObject.Find("First Fading Canvas").GetComponent<CanvasGroup>();
        SecondFadingCanvas = GameObject.Find("Second Fading Canvas").GetComponent<CanvasGroup>();
        startCountdownImage = GameObject.Find("Start Countdown Image").GetComponent<Image>();
    }
    void Update()
    {
        minigameTimer = (int)Mathf.Round(minigameTimerRaw);

        if (!minigameManger.minigameEnded)
        {
            minigameTimerRaw += Time.deltaTime;
            MinigameStart();
        }
        else
            MinigameEnd();

        //Minigame ends in 30s from start (6s is from 3, 2, 1 Countdown in MinigameStart())
        if (minigameTimerRaw >= 36f)
            minigameManger.minigameEnded = true;

        //TESTING
        if (Input.GetKeyDown(KeyCode.T))
        {
            minigameManger.minigameEnded = true;
        }
        /////////
        if (minigameManger.barsRaised)
            ScreenFading();
    }

    void MinigameStart()
    {
        //Disable Players' movement
        foreach (GameObject player in GameManager.m_Instance.m_Players)
            player.GetComponent<PlayerController>().m_CantMove = true;

        //3, 2, 1, GO Countdown
        if (minigameTimer == 2)
        {
            startCountdownImage.enabled = true;
            startCountdownImage.sprite = startCountdownTextures[0];
        }
        else if (minigameTimer == 3)
            startCountdownImage.sprite = startCountdownTextures[1];

        else if (minigameTimer == 4)
            startCountdownImage.sprite = startCountdownTextures[2];

        else if (minigameTimer == 5)
            startCountdownImage.sprite = startCountdownTextures[3];

        else if (minigameTimer >= 6)
        {
            startCountdownImage.enabled = false;
            //Enable Players' movement
            foreach (GameObject player in GameManager.m_Instance.m_Players)
                player.GetComponent<PlayerController>().m_CantMove = false;
        }   
    }

    void MinigameEnd()
    {
        foreach (GameObject player in GameManager.m_Instance.m_Players)
            player.GetComponent<PlayerController>().m_CantMove = true;

        //Black Background Fading Canvas
        delayToFadeIn -= Time.deltaTime;
        if (delayToFadeIn < 0)
        {
            if (FirstFadingCanvas.alpha < 0.6)
            {
                FirstFadingCanvas.alpha += Time.deltaTime / fadeTime;
            }

            delayToShowResultBar -= Time.deltaTime;
            if (delayToShowResultBar < 0)
            {
                minigameManger.showResultBar = true; //PASSES TO NEIGHBOUR SCRIPT
            }
        }
    }

    void ScreenFading()
    {
        if (SecondFadingCanvas.alpha < 0.6)
        {
            SecondFadingCanvas.alpha += Time.deltaTime / fadeTime;
        }
    }
}
