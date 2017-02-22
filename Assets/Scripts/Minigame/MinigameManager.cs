﻿/*
 *   Minigame manager holds a Finite State Machine with the following states that should be the same for all mini games:
 *   
 *   PreGameCountdown (initial state) >> ScoreAndTimeTrack >> ResultSummary >> RewardSelecion (final state)
 * 
 *   Each state presented above is defined in its own script.
 */
using UnityEngine;

[RequireComponent(typeof(MinigamePreGameCountdown))]
public class MinigameManager : MonoBehaviour
{
    [HideInInspector]
    public enum EMinigameState { PreGameCountdown, ScoreAndTimeTrack, ResultSummary, RewardSelection };
    [HideInInspector]
    public int m_P1Place, m_P2Place, m_P3Place, m_P4Place;
    [HideInInspector]
    public int m_ScorePlace1, m_ScorePlace2, m_ScorePlace3, m_ScorePlace4;

    // Member variables
    private EMinigameState m_CurrentState;
    private PartyBar       m_PartyBar;

    public Canvas      m_MinigameCanvas;
    public Canvas      m_RewardSelectionCanvas;
    public Canvas      m_BossPromptCanvas;
    public CanvasGroup m_FirstFadingCanvas;
    public CanvasGroup m_SecondFadingCanvas;

    public float        m_DelayToFadeIn;
    public float        m_DelayToShowResultBar;
    public float        m_DelayToShowRewards;
    public float        m_FadeTime;

    private void Start()
    {
        m_PartyBar = GetComponentInChildren<PartyBar>();
        m_CurrentState = EMinigameState.PreGameCountdown;
        m_P1Place = 0;
        m_P2Place = 0;
        m_P3Place = 0;
        m_P4Place = 0;
        m_ScorePlace1 = 0;
        m_ScorePlace2 = 0;
        m_ScorePlace3 = 0;
        m_ScorePlace4 = 0;
        m_RewardSelectionCanvas.gameObject.SetActive(false);
        m_BossPromptCanvas.gameObject.SetActive(false);
    }

    public EMinigameState GetMinigameState()
    {
        return m_CurrentState;
    }

    public void UpdateMinigameState()
    {
        switch (m_CurrentState)
        {
            case EMinigameState.PreGameCountdown:
                m_CurrentState = EMinigameState.ScoreAndTimeTrack;
                break;
            case EMinigameState.ScoreAndTimeTrack:
                m_CurrentState = EMinigameState.ResultSummary;
                break;
            case EMinigameState.ResultSummary:
                m_CurrentState = EMinigameState.RewardSelection;
                break;
            default:
                Debug.LogAssertion("[Minigame Manager] Invalid state update");
                break;
        }
    }

    //public bool minigameEnded;
    //public bool showResultBar;
    //public bool scoreSorted;
    //public bool barsRaised;
    //public bool showRewardCanvas;
    //public bool rewardsSelected;

    //public int P1_place, P2_place, P3_place, P4_place;      //int from 1 - 4

    //public void endMinigame()
    //{
    //    if (minigameEnded == false)
    //    {
    //        minigameEnded = true;
    //    }
    //}

    //void Update()
    //{
    //    if (rewardsSelected)
    //    {
    //        GameManager.m_Instance.m_GameState = GameManager.GameState.Dungeon;
    //        SceneManager.LoadScene(GameManager.m_Instance.m_Tutorial.ToString());
    //    }
    //}
}
