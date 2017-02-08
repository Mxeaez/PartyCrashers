﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    //sound
    public GameObject SFXPlayer;
    public AudioClip[] hurtSFX;
    public AudioClip[] deathSFX;
    private AudioClip SFXtoPlay;

    //Kavells VFX code
    public GameObject deathVFX;
	//Kavells VFX code

    public float m_EnemyHealth = 100f;
    public GameObject m_Drop;
    [HideInInspector]
    public bool isInvincible = false;
    public void Kill()
    {
        Destroy(gameObject);

        Instantiate(m_Drop, gameObject.transform.position, gameObject.transform.rotation);

        for (int i = 0; i < GameManager.m_Instance.m_Players.Length; ++i)
        {
            Player player = GameManager.m_Instance.m_Players[i].GetComponent<Player>();
            player.m_Score += 100;
        }
    }

    public float GetEnemyHealth()
    {
        return m_EnemyHealth;
    }

    public void Damage(float health)
    {
        //Debug.Log("Damaged");
        if(isInvincible == true)
        {
        }
        if (isInvincible == false)
        {
            m_EnemyHealth -= health;
            //James Shound Code
            if (m_EnemyHealth > 0)
            {
                SFXtoPlay = hurtSFX[Random.Range(0, hurtSFX.Length)];

            }
            else
            {
                SFXtoPlay = deathSFX[Random.Range(0, deathSFX.Length)];

            }

            if (SFXPlayer != null)
            {
                AudioSource source = SFXPlayer.GetComponent<AudioSource>();
                source.clip = SFXtoPlay;
            }
            GameObject SFXtest = Instantiate(SFXPlayer, transform.position, transform.rotation) as GameObject;
            //James Shound Code
        }
        if (m_EnemyHealth <= 0)
        {
			//Kavells VFX code
			if (deathVFX != null) 
			{
				GameObject takeDamage;
				takeDamage = (GameObject)Instantiate (deathVFX, transform.position, transform.rotation);
				Destroy (takeDamage, 1f);
			}
			//Kavells VFX code
            Kill();
        }
    }

}
