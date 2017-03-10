﻿using UnityEngine;
using System.Collections;

public class BossManager : MonoBehaviour
{

    //Get the players
    protected GameObject[] players;
    private Transform[] playerPositionsArray = { null, null, null, null };
    public GameObject m_backWall;

    public GameObject boss;

    public AudioClip[] BadBoySFX;
    public AudioClip[] GothSFX;
    public AudioClip[] NerdSFX;
    public AudioClip[] MascotSFX;
    public AudioClip SFXtoPlay;
    public bool m_IsStart = false;
    private Player player;
    // Use this for initialization

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    void Start()
    {
        //Get the number of players
        players = GameManager.m_Instance.m_Players;


        //Boss
        if (boss.active == true)
        {
            boss.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move wall
        if (GetLowestPlayerZ() > 0)
        {
            if (m_backWall.transform.position.z < GetLowestPlayerZ() - 5f && m_backWall.transform.position.z < 33f)
            {
                m_backWall.transform.position = new Vector3(m_backWall.transform.position.x, m_backWall.transform.position.y, Mathf.Lerp(m_backWall.transform.position.z, GetLowestPlayerZ() - 5f, 0.1f));
            }
        }
        //Activate Boss
        if (m_backWall.transform.position.z >= 33f)
        {
            boss.SetActive(true);

            if (!m_IsStart)
            {
                if (player.m_Model == Player.Model.Badboy)
                {
                    SFXtoPlay = BadBoySFX[Random.Range(0, BadBoySFX.Length)];
                    AudioManager.m_Instance.PushMusic(SFXtoPlay);
                }

                if (player.m_Model == Player.Model.Goth)
                {
                    SFXtoPlay = GothSFX[Random.Range(0, GothSFX.Length)];
                    AudioManager.m_Instance.PushMusic(SFXtoPlay);
                }

                if (player.m_Model == Player.Model.Nerd)
                {
                    SFXtoPlay = NerdSFX[Random.Range(0, NerdSFX.Length)];
                    AudioManager.m_Instance.PushMusic(SFXtoPlay);
                }

                if (player.m_Model == Player.Model.Mascot)
                {
                    SFXtoPlay = MascotSFX[Random.Range(0, MascotSFX.Length)];
                    AudioManager.m_Instance.PushMusic(SFXtoPlay);
                }

                m_IsStart = true;
            }
        }
    }
    GameObject getClosestPlayer()
    {
        float distance = 0f;
        GameObject target = null;
        for (int i = 0; i < players.Length; i++)
        {
            if (i == 0)
            {
                distance = Vector3.Distance(players[i].transform.position, transform.position);
                target = players[i];
            }
            else
            {
                if (Vector3.Distance(players[i].transform.position, transform.position) < distance)
                {
                    distance = Vector3.Distance(players[i].transform.position, transform.position);
                    target = players[i];
                }
            }
        }
        return target;
    }

    float GetLowestPlayerZ()
    {
        float zCurrent = 200f;
        for (int i = 0; i < players.Length; i++)
        {
            if (zCurrent > players[i].transform.position.z)
            {
                zCurrent = players[i].transform.position.z;
            }
        }
        return zCurrent;
    }
}
