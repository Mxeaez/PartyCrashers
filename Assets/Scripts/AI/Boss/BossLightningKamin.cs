﻿using UnityEngine;
using System.Collections;

public class BossLightningKamin : MonoBehaviour
{

    [HideInInspector]
    public Vector3 m_ProjectileVelocity;
    public float m_Life;


    private int frame;
    private Rigidbody m_Body;

    // Use this for initialization
    void Start()
    {
        m_Body = GetComponent<Rigidbody>();
        m_Body.velocity = m_ProjectileVelocity;
        frame = 0;
    }

    //Called once object is activated
    void OnEnable()
    {
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_Body.velocity = m_ProjectileVelocity;
        frame++;

        if (frame > m_Life)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Player>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}
