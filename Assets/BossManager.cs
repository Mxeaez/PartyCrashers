﻿using UnityEngine;
using System.Collections;

public class BossManager : MonoBehaviour {

    //Get the players
    protected GameObject[] players;
    private Transform[] playerPositionsArray = { null, null, null, null };
    public GameObject m_backWall;

    // Use this for initialization
    void Start () {
        //Get the number of players
        players = GameManager.m_Instance.m_Players;
    }
	
	// Update is called once per frame
	void Update () {
	    //Move wall

        if(m_backWall.transform.position.z < GetLowestPlayerZ() - 5f && m_backWall.transform.position.z < -7f)
        {
            m_backWall.transform.position = new Vector3(m_backWall.transform.position.x, m_backWall.transform.position.y, Mathf.Lerp(m_backWall.transform.position.z,m_backWall.transform.position.z + 1f,0.1f));
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
            if(zCurrent > players[i].transform.position.z)
            {
                zCurrent = players[i].transform.position.z;
            }
        }
        return zCurrent;
    }
}
