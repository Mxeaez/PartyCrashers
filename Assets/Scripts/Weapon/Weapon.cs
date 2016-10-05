﻿using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    public Animation m_Anim;
    public int m_Damage = 0;
    public float m_AttackSpeed = 0;
    public AudioClip[] m_PrimarySounds;
    public AudioClip[] m_SecondarySounds;
    public AudioClip[] m_SoundsOnHit;
    protected float m_CoolDown;
    protected float m_CoolDown02;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public abstract void primaryAttack();

    public abstract void secondaryAttack();
}
