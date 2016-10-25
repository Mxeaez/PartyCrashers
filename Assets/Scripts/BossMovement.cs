﻿using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {

    GameObject[] players;
    public float StartPosX = 0;
    public float StartPosY = 1;
    public float StartPosZ = 100;
    public float RunAwayDistance = 5;
    public float ChaseDistance = 10;
    public float StayDistance = 20;
    public float m_Distance;
    public float BossMoveSpeed = 20;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(StartPosX, StartPosY, StartPosZ);
        players = GameObject.FindGameObjectsWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        float NewX = transform.position.x;
        float NewY = transform.position.y;
        float NewZ = transform.position.z;

        Vector3 MoveBackward;
        Vector3 MoveToward;

        // Get closest player
        for (int i = 0; i < players.Length; i++)
        {
            if (i == 0)
            {
                m_Distance = Vector3.Distance(players[i].transform.position, transform.position);
                MoveBackward = transform.position - players[i].transform.position;
                MoveToward = players[i].transform.position - transform.position;
                if (m_Distance <= RunAwayDistance)
                {
                    transform.position += MoveBackward * BossMoveSpeed * Time.deltaTime;
                }
                else if (m_Distance > ChaseDistance && m_Distance < StayDistance)
                {
                    transform.position += MoveToward * BossMoveSpeed * Time.deltaTime;
                }
                else if (m_Distance >= StayDistance)
                {
                    // Do nothing
                }
            }
            else
            {
                if (Vector3.Distance(players[i].transform.position, transform.position) < m_Distance)
                {
                    m_Distance = Vector3.Distance(players[i].transform.position, transform.position);
                    MoveBackward = transform.position - players[i].transform.position;
                    MoveToward = players[i].transform.position - transform.position;
                    if (m_Distance <= RunAwayDistance)
                    {
                        transform.position += MoveBackward * BossMoveSpeed * Time.deltaTime;
                    }
                    else if (m_Distance > ChaseDistance && m_Distance < StayDistance)
                    {
                        transform.position += MoveToward * BossMoveSpeed * Time.deltaTime;
                    }
                    else if (m_Distance >= StayDistance)
                    {
                        // Do nothing
                    }
                }
            }
        }
    }
}
