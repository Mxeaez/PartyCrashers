﻿using UnityEngine;
using System.Collections;

public class FizzyGunSetTrap : MonoBehaviour {

    [SerializeField]
    private GameObject StickyTrapPrefab;
    private Rigidbody rb;
    [HideInInspector]
    public bool m_SetTrap = false;
    [SerializeField]
    private float m_HealDestroyTimer;
    private float SpawnTrapSafety = 1;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        if (m_SetTrap == true)
        {
            // BUG: TRAP SPAWNS BEFORE HEALTH VELOCITY HITS ZERO.
            // Guess 1: When Cube hits the floor the velocity turns 0 for a frame, instantiating the trap before time.
            // Guess 2:

            //Debug.Log("Pickup is going to instantiate trap.");
            if (rb.velocity == Vector3.zero)
            {
                // StartCoroutine(SpawnTrap());
                GameObject trapGO = Instantiate<GameObject>(StickyTrapPrefab);
                trapGO.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
                trapGO.AddComponent<Rigidbody>();
                trapGO.GetComponent<Rigidbody>().mass = 0.5f;
                trapGO.GetComponent<Rigidbody>().useGravity = true;
                trapGO.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                trapGO.AddComponent<BoxCollider>();

                BoxCollider[] boxList = trapGO.GetComponents<BoxCollider>();
                BoxCollider newBox = new BoxCollider();

                // Get the right collider
                foreach(BoxCollider b in boxList)
                {
                    if(b.isTrigger != true)
                    {
                        newBox = b;
                    }
                }

                newBox.center = new Vector3(0f, 0.05f, 0f);
                newBox.size = new Vector3(1f, 0.1f, 1f);
                                
                m_SetTrap = false;
                //Debug.Log("Trap instantiated.");
                
                StopCoroutine(DestroyHeal());
                StartCoroutine(DestroyHeal());
            }
        }
    }

    private IEnumerator SpawnTrap()
    {
        yield return new WaitForSeconds(SpawnTrapSafety);        
    }

    private IEnumerator DestroyHeal()
    {
        yield return new WaitForSeconds(m_HealDestroyTimer);
        Destroy(this.gameObject);
    }
}
