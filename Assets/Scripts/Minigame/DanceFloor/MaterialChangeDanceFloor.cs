﻿using UnityEngine;
using System.Collections;

public class MaterialChangeDanceFloor : MonoBehaviour {

    public Renderer m_DiscoBallLight;
    public Material m_ColorZero;
    public Material m_ColorOne;
    public Material m_ColorTwo;
    public Material m_ColorThree;
    public Material m_ColorFour;
    public Material m_ColorFive;
    public Material m_ColorSix;
    public Material m_ColorSeven;

    private float scoretime = 4;
    private float stoptime = 4;

    private bool stop = false;

    private Material m_DiscoBallON;
    private Material m_Temp;
    public GameObject m_Light;
    public int m_CurrentFloorColorInt;
    public int m_PreviousColorInt = -1;
    
    void Start()
    {
        m_CurrentFloorColorInt = -2;
    }

    void Update()
    {
        m_CurrentFloorColorInt = m_Light.GetComponent<LightChangeDancefloor>().CurrentColorInt;
        if (stop == true)
        {
            StartCoroutine(Stopedfor(scoretime));
            if (m_PreviousColorInt != -1)
            {
                m_DiscoBallLight.material = m_Temp;
            }
        }
        if (stop == false)
        {
            // Light not flashing
            // assigning the color (color shuffle)
            // Getting / Losing point 
            StartCoroutine(Stopfor(scoretime));
            // Light flashing
            // Color assigned
            // Cannot get / lose point
            StartCoroutine(ColorRandomiser(stoptime));

            m_DiscoBallLight.material = m_DiscoBallON;
            float emission = Mathf.PingPong(Time.time * 1.5f, 1);
            m_DiscoBallLight.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
            m_PreviousColorInt = m_CurrentFloorColorInt;
            m_Temp = m_DiscoBallON;
        }
    }

    IEnumerator ColorRandomiser(float wait)
    {

        if (m_CurrentFloorColorInt == 0)
        {
            m_DiscoBallON = m_ColorZero;
        }
        if (m_CurrentFloorColorInt == 1)
        {
            m_DiscoBallON = m_ColorOne;
        }
        if (m_CurrentFloorColorInt == 2)
        {
            m_DiscoBallON = m_ColorTwo;
        }
        if (m_CurrentFloorColorInt == 3)
        {
            m_DiscoBallON = m_ColorThree;
        }
        if (m_CurrentFloorColorInt == 4)
        {
            m_DiscoBallON = m_ColorFour;
        }
        if (m_CurrentFloorColorInt == 5)
        {
            m_DiscoBallON = m_ColorFive;
        }
        if (m_CurrentFloorColorInt == 6)
        {
            m_DiscoBallON = m_ColorSix;
        }
        if (m_CurrentFloorColorInt == 7)
        {
            m_DiscoBallON = m_ColorSeven;
        }
        yield return new WaitForSeconds(wait);
    }
    IEnumerator Stopfor(float wait)
    {
        //this is the amount of time i want it to wait
        yield return new WaitForSeconds(wait);
        //this is what it will do when the timehas passed

        stop = true;
    }

    IEnumerator Stopedfor(float wait)
    {
        //this is the amount of time i want it to wait
        yield return new WaitForSeconds(wait);
        //this is what it will do when the timehas passed
        stop = false;

    }
}
