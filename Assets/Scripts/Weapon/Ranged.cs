﻿using UnityEngine;
using System.Collections;

public abstract class Ranged : Weapon
{
    [Header("Ranged Weapons Settings")]
    [SerializeField]
    protected GameObject m_RightTriggerProjectile;
    [SerializeField]
    protected GameObject m_LeftTriggerProjectile;
    [SerializeField]
    protected float m_ProjectileSpeed02;
    [SerializeField]
    protected GameObject[] m_FirePoint;


}
