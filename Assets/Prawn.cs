using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Prawn : MonoBehaviour
{
    public ChopPrawn chopPrawn;
    public ChopPrawn chopPrawnClone;

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
        CollisionFloor();

        if (m_bIsHold)
            SetTransform(player.transform);
    }

    private void CollisionFloor()
    {
        Vector3 vTempPos = this.transform.position;
        if (vTempPos.y < 0.05f)
        {
            vTempPos.y = 0.05f;
            this.transform.position = vTempPos;
        }
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && m_bIsHold)
        {
            m_bIsHold = false;
            // 던지기
        }

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
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Knife") && !m_bIsDead)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))  // 다지기
            {
                player.GetComponent<Player>().SetPlayerIsMove(false);
                chopPrawnClone = Instantiate(chopPrawn, this.transform.position, Quaternion.identity);
                m_bIsDead = true;
            }
        }
    }

    void SetTransform(Transform pTrans)
    {
        this.transform.rotation = pTrans.rotation;
        this.transform.position = pTrans.position + pTrans.forward;
        this.transform.position += new Vector3(0, 0.9f, 0);
    }
}
