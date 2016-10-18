﻿using UnityEngine;
using System.Collections;

public class Sword : Melee
{

    public int dashDistance = 25;

    public float dashDelay = 0.1f;

    public float smooth = 20f;

    public static bool attack = false;

    public float triggerLife = 0.5f;

    public GameObject swordTrigger;

    //PlayerController m_PlayerController;
    CharacterController m_CharacterController;




    // Use this for initialization
    void Start()
    {
        //m_PlayerController = GetComponentInParent<PlayerController>();
        m_CharacterController = GetComponentInParent<CharacterController>();

        swordTrigger.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (attack == true)
        {
            triggerLife -= Time.deltaTime;

        }
        if (triggerLife <= 0)
        {
            Debug.Log("time left = 0");
            attack = false;
            triggerLife = 0.5f;

        }
        if (attack == true)
        {
            swordTrigger.SetActive(true);
        }
        if (attack == false)
        {
            swordTrigger.SetActive(false);
        }
    }

    override public void primaryAttack()
    {
        attack = true;
    }

    override public void secondaryAttack()
    {
        attack = true;
        m_CharacterController.Move(m_CharacterController.transform.forward * Time.deltaTime * 50f);
    }

    IEnumerator dash()
    {
        yield return new WaitForSeconds(dashDelay);
        m_CharacterController.Move(m_CharacterController.transform.forward * Time.deltaTime * 10f);
    }
}
