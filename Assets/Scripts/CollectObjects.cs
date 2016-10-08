﻿using UnityEngine;
using System.Collections;

public class CollectObjects : MonoBehaviour
{

    private Player player;
    private PartyBar partyBar;

    void Start()
    {
        player = gameObject.GetComponent<Player>();
        partyBar = GameObject.Find("PartyBar_Game").transform.FindChild("Content").GetComponent<PartyBar>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Collectible collectible = other.GetComponent<Collectible>();

        if (collectible != null)
        {
            player.m_Gold += collectible.score;
            
            HUD.Instance.AdjustScore(collectible.score);

            if(partyBar != null)
            {
                partyBar.m_Current += collectible.score;
            }

            GameManager.m_Instance.m_TutorialCoins.Add(other.gameObject.name);

            if(collectible.type == Collectible.Type.Death)
            {
                //lose health
            }
            other.gameObject.SetActive(false);
        }
    }
}
