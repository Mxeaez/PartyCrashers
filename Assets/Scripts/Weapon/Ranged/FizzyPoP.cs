﻿using UnityEngine;
using System.Collections;
using System;

public class FizzyPoP : Ranged
{

    [Header("Fizzy PoP Gun")]

    #region Floats
    [SerializeField]
    private float m_MaxSprayCharge = 5f;    
    [SerializeField]
    private float m_AngleModifier = .5f;
    #endregion

    #region Bools
    private bool m_IsDown = false;
    private bool m_CanHeal = false;

    #endregion

    #region Components
    private Player Player;
    private GameObject FizzyCone;
    #endregion

    //Test
    bool m_IsFiring = false;

    void Start()
    {
        FizzyCone = transform.FindChild("FizzyGunCone").gameObject;
        FizzyCone.SetActive(false);
        Player = GetComponentInParent<Player>();
    }

    void Update()
    {
        #region Primary Attack
        // Shoot if Button Down
        if (Input.GetAxisRaw(Player.m_PrimaryAttack + Player.getControllerAsString()) == 1 && m_IsDown)
            ShootSpray();        
        else
            FizzyCone.SetActive(false);
        #endregion

        #region Secoindary Attack
        // Shoot if Button Down
        if (Input.GetAxisRaw(Player.m_SecondaryAttack + Player.getControllerAsString()) == 0 && m_CanHeal)
        {
            ShootHeal();
            Debug.Log("Is Shooting Spray");
        }
        #endregion
    }


    public override void primaryAttack()
    {               
        if (m_CoolDown <= Time.time - m_Weapon1Cooldown || m_CoolDown == 0)
        {
            m_IsDown = true;
        }            
    }

    public override void secondaryAttack()
    {
        if (m_SecondaryCoolDown <= Time.time - m_Weapon2Cooldown || m_SecondaryCoolDown == 0)
        {
            m_CanHeal = true;
            m_SecondaryCoolDown = Time.time;
        }
    }

    private void ShootSpray()
    {
        float counter = 0.0f;
        FizzyCone.SetActive(true);
        counter += Time.deltaTime;
        //do
        //{
        //    counter += Time.deltaTime;
        //    Debug.Log(counter);
        //} while (counter < m_MaxSprayCharge);

        if (counter >= m_MaxSprayCharge)
        {
            //FizzyCone.SetActive(false);
            m_IsDown = false;    
            m_CoolDown = Time.time;
            counter = 0;
        }

    }

    private void ShootHeal()
    {
        GameObject healPrefab;
        healPrefab = (GameObject)Instantiate(m_LeftTriggerProjectile, m_FirePoint[0].gameObject.transform.position, m_FirePoint[0].gameObject.transform.rotation);
        healPrefab.GetComponent<Rigidbody>().AddForce(healPrefab.transform.up * m_ProjectileSpeed02);        
        m_CanHeal = false;
    }

    private void assignDamage(GameObject bullet)
    {
        if (bullet.GetComponent<Damage>() != null)
        {
            bullet.GetComponent<Damage>().m_Damage = m_Damage;
        }
        else
        {
            Debug.Log("Bullet doesn't have a Damage Component");
        }
    }
}