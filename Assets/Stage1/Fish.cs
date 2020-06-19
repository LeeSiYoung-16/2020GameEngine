using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public ChopFish Chopfish;
    public ChopFish ChopfishClone;

    private GameObject player;

    private bool m_bIsHold = false;
    private bool m_bIsDead = false;

    public void SetIsHold(bool bIsHold) { m_bIsHold = bIsHold; }
    public bool GetIsHold() { return m_bIsHold; }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (m_bIsHold)
            SetTransform(player.transform);
    //    else
    //        transform.position = this.transform.position;
    }

    void LateUpdate()
    {
        if (m_bIsDead)
            Destroy(this.gameObject);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!m_bIsHold)
                    m_bIsHold = true;
                else
                    m_bIsHold = false;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Knife") && !m_bIsDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<Player>().SetPlayerIsMove(false);
                ChopfishClone = Instantiate(Chopfish, this.transform.position, Quaternion.Euler(0, -90, 0));
                m_bIsDead = true;
            }
        }
    }

    void SetTransform(Transform pTrans)
    {
        this.transform.rotation = pTrans.rotation;
        this.transform.position = pTrans.position + pTrans.forward;
        this.transform.position += new Vector3(0, 0.8f, 0);
    }
}
