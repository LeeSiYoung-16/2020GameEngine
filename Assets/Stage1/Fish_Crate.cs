using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Fish_Crate : MonoBehaviour
{
    public Fish fish;
    public Fish fishClone;
    private bool m_bIsHold = false;

    void Start()
    {
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !m_bIsHold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fishClone = Instantiate(fish, transform.position, Quaternion.identity);
                m_bIsHold = true;
                fishClone.SetIsHold(m_bIsHold);
            }
        }
    }

    void Update()
    {
        m_bIsHold = fish.GetIsHold();
    }
}
