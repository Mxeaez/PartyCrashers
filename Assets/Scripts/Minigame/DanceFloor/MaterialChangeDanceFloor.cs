﻿using UnityEngine;
using System.Collections;

public class MaterialChangeDanceFloor : MonoBehaviour {

    public Renderer m_DiscoBallLight;
    //public Material m_ColorZero;
    //public Material m_ColorOne;
    //public Material m_ColorTwo;
    //public Material m_ColorThree;
    //public Material m_ColorFour;
    //public Material m_ColorFive;
    //public Material m_ColorSix;
    //public Material m_ColorSeven;

    public Material m_ColorRight;
    public Material m_ColorWrong;


    private float scoretime = 4;
    private float stoptime = 4;

    private bool stop = false;

    private Material m_DiscoBallON;
    private Material m_Temp;
    public GameObject m_Light;
    public int m_CurrentFloorColorInt;
    public int m_PreviousColorInt = -1;
    private int m_GreedColorPercentage;


    void Start()
    {
        m_CurrentFloorColorInt = -2;
    }

    void Update()
    {
        m_CurrentFloorColorInt = m_Light.GetComponent<LightChangeDancefloor>().CurrentColorInt;
        m_GreedColorPercentage = m_Light.GetComponent<LightChangeDancefloor>().GreenColorPercentage;
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

        if (m_CurrentFloorColorInt >= 0 && m_CurrentFloorColorInt < m_GreedColorPercentage)
        {
            m_DiscoBallON = m_ColorRight;
        }
        if (m_CurrentFloorColorInt >= m_GreedColorPercentage && m_CurrentFloorColorInt < 100)
        {
            m_DiscoBallON = m_ColorWrong;
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
