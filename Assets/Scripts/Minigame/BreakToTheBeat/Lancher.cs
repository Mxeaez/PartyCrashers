﻿using UnityEngine;
using System.Collections;

public class Lancher : MonoBehaviour
{
    public float m_FireIntervalMin = 5;
    public float m_FireIntervalMax = 10;
    public GameObject m_VasePrefeb;
    public GameObject m_VasePrefeb1;
    public GameObject m_VasePrefeb2;
    public Transform m_ShotPos;
    private float m_LastShotTime;
    private int m_ramdom;
    public int m_GoldPer = 20;
    public int m_BlackPer = 20;
    private float m_Timer;
    // Use this for initialization
    void Start()
    {
        m_LastShotTime = Time.time;
        m_Timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= 10 && m_Timer < 20)
        {
            m_FireIntervalMin = 3;
            m_FireIntervalMax = 8;
        }
        if (m_Timer >= 20 && m_Timer < 30)
        {
            m_FireIntervalMin = 1;
            m_FireIntervalMax = 5;
        }
        if (m_Timer >= 30)
        {
            // game end
        }
        bool canShoot = (m_LastShotTime + Random.Range(m_FireIntervalMin, m_FireIntervalMax)) < Time.time;
        // Shoot!
        if (canShoot)
        {
            if (m_VasePrefeb != null && m_VasePrefeb1 != null && m_VasePrefeb2 != null)
            {
                if (m_ShotPos != null)
                {
                    m_ramdom = Random.Range(0, 100);
                    if (m_ramdom >= 0 && m_ramdom < 60)
                    {
                        GameObject shot = Instantiate(m_VasePrefeb, m_ShotPos.position, m_ShotPos.rotation) as GameObject;
                        if (m_Timer >= 10 && m_Timer < 20)
                        {
                            shot.GetComponent<VaseSpeed>().velocity = 10;
                        }
                        if (m_Timer >= 20 && m_Timer < 30)
                        {
                            shot.GetComponent<VaseSpeed>().velocity = 15;
                        }
                        if (m_Timer >= 30)
                        {
                            // game end
                        }
                    }
                    if (m_ramdom >= 60 && m_ramdom < 80)
                    {
                        GameObject shot = Instantiate(m_VasePrefeb1, m_ShotPos.position, m_ShotPos.rotation) as GameObject;
                        if (m_Timer >= 10 && m_Timer < 20)
                        {
                            shot.GetComponent<VaseSpeed>().velocity = 10;
                        }
                        if (m_Timer >= 20 && m_Timer < 30)
                        {
                            shot.GetComponent<VaseSpeed>().velocity = 15;
                        }
                        if (m_Timer >= 30)
                        {
                            // game end
                        }
                    }
                    if (m_ramdom >= 80 && m_ramdom <= 100)
                    {
                        GameObject shot = Instantiate(m_VasePrefeb2, m_ShotPos.position, m_ShotPos.rotation) as GameObject;
                        if (m_Timer >= 10 && m_Timer < 20)
                        {
                            shot.GetComponent<VaseSpeed>().velocity = 10;
                        }
                        if (m_Timer >= 20 && m_Timer < 30)
                        {
                            shot.GetComponent<VaseSpeed>().velocity = 15;
                        }
                        if (m_Timer >= 30)
                        {
                            // game end
                        }
                    }
                }
                //else
                //{
                //    GameObject shot = GameObject.Instantiate<GameObject>(m_VasePrefeb);
                //    shot.transform.position = transform.position;
                //    shot.transform.forward = transform.forward;
                //    shot.transform.up = transform.up;
                //}
                m_LastShotTime = Time.time;
            }
        }
    }
}
