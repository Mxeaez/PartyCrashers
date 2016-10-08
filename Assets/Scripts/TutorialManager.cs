﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //If loading back to tutorial scene, set players location to their last
            foreach (GameObject p in GameManager.m_Instance.m_Players)
            {
                Player player = p.GetComponent<Player>();
                switch (player.m_Player)
                {
                    case Player.PLAYER.P1:
                        p.transform.position = GameManager.m_Instance.m_Player1.lastLocation;
                        break;
                    case Player.PLAYER.P2:
                        p.transform.position = GameManager.m_Instance.m_Player2.lastLocation;
                        break;
                    case Player.PLAYER.P3:
                        p.transform.position = GameManager.m_Instance.m_Player3.lastLocation;
                        break;
                    case Player.PLAYER.P4:
                        p.transform.position = GameManager.m_Instance.m_Player4.lastLocation;
                        break;
                }
            }

        Transform coins = GameObject.Find("R1_Coins").transform;
        foreach (Transform child in coins)
        {
            foreach(string name in GameManager.m_Instance.m_TutorialCoins)
            {
                if (child.gameObject.name == name)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
