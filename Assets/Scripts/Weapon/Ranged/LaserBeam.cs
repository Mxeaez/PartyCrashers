﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
{    
    Bow bow;
    LineRenderer m_LineRenderer;
    Damage dmg;

    [SerializeField]
    private GameObject m_LaserBeamFX;   //TODO: Instantiate this efect feom line renderer start to line renderer max lenght while line renderer is enabled

    void Start()
    {
        dmg = GetComponent<Damage>();
        bow = GetComponentInParent<Bow>();       
        m_LineRenderer = GetComponent<LineRenderer>();         
        m_LineRenderer.enabled = false;
    }

    void Update()
    {            
        m_LineRenderer.SetWidth(bow.laserWidth, bow.laserWidth);

        Ray ray = new Ray(transform.position, transform.forward);
        m_LineRenderer.SetPosition(0, ray.origin);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, bow.m_LaserLenght);
        foreach(RaycastHit hit in hits)
        {
            if(m_LineRenderer.enabled == true)
            {
                if (hit.transform.GetComponent<EnemyHealth>() != null)
                {
                    EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
                    if (dmg != null)
                    {
                        dmg.m_Damage = bow.m_Damage * bow.m_LaserDmgMultiplier;
                    }
                    else
                    {
                        Debug.Log("Bullet doesn't have a Damage Component");
                    }
                    enemyHealth.Damage(dmg.m_Damage);
                }
            }
            
        }
                   
        m_LineRenderer.SetPosition(1, ray.GetPoint(bow.m_LaserLenght));

    }
}








/*
[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
{

    [SerializeField]
    private float laserWidth = 1.0f;
    [SerializeField]
    private float noise = 1.0f;
    [SerializeField]
    private float maxLenght = 50.0f;
    [SerializeField]
    private Color color = Color.red;

    LineRenderer lineRenderer;
    private int lenght;
    Vector3[] position;
    Transform myTransform;
    Transform endEffectTransform;
    // The particle system that will be created by the laser.
    [SerializeField]
    private ParticleSystem endEffect;
    Vector3 offset;



    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(laserWidth, laserWidth);
        myTransform = transform;
        offset = new Vector3(0, 0, 0);
        endEffect = GetComponentInChildren<ParticleSystem>();
        if (endEffect)
            endEffectTransform = endEffect.transform;
    }

    void Update()
    {
        RenderLaser();
    }

    void RenderLaser()
    {
        // Shoot our laser forward.
        UpdateLenght();

        lineRenderer.SetColors(color, color);
        // Nove through the Array
        for (int i = 0; i < lenght; i++)
        {
            // Set the position here to the current location and project it in the forward direction of the object it is attached to.
            offset.x = myTransform.position.x + i * myTransform.forward.x + Random.Range(-noise, noise);
            offset.z = i * myTransform.forward.z + Random.Range(-noise, noise) + myTransform.position.z;
            position[i] = offset;
            position[0] = myTransform.position;

            lineRenderer.SetPosition(i, position[i]);
        }
    }

    void UpdateLenght()
    {
        // Raycast from the location of the cube forwards.
        RaycastHit[] hit;
        hit = Physics.RaycastAll(myTransform.position, myTransform.forward, maxLenght);
        int i = 0;
        while (i < hit.Length)
        {
            // Check to make sure we arn't hitting triggers but colliders
            if (!hit[i].collider.isTrigger)
            {
                lenght = (int)Mathf.Round(hit[i].distance) + 2;
                position = new Vector3[lenght];
                // Move our End Effect particle system to hit point and start playing it.
                if (endEffect)
                {
                    endEffectTransform.position = hit[i].point;
                    if (!endEffect.isPlaying)
                        endEffect.Play();
                }
                lineRenderer.SetVertexCount(lenght);
                return;
            }
            i++;
        }
        // If we're not hitting anything, don't play the particle effects
        if (endEffect)
        {
            if (endEffect.isPlaying)
                endEffect.Stop();
        }
        maxLenght = (int)maxLenght;
        position = new Vector3[lenght];
        lineRenderer.SetVertexCount(lenght);
    }


}

// https://forum.unity3d.com/threads/laser-beam-script-in-c.122500/
*/










