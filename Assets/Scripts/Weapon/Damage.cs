﻿using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{

    [HideInInspector]
    public float m_Damage;


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.Damage(m_Damage);
        }
    }
}
