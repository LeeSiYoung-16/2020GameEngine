using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour
{
    private GameObject player;
 //   private GameObject plate;

    public PlateSushi PlateSushi;
    public PlateSushi PlateSushiClone;

    private bool m_bIsHold = false;
    private bool m_bIsDead = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    //    plate = GameObject.FindWithTag("Plate");
        player.GetComponent<Player>().SetPlayerIsMove(true);
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
        if (vTempPos.y < 0.249f)
        {
            vTempPos.y = 0.249f;
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
        if (other.gameObject.CompareTag("Player") && !m_bIsHold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                m_bIsHold = true;      
        }

        if (other.gameObject.CompareTag("Plate") && !m_bIsHold)
        {
            PlateSushiClone = Instantiate(PlateSushi, this.transform.position, Quaternion.Euler(0, -90, 0));
            m_bIsDead = true;
        }
    }

    void SetTransform(Transform pTrans)
    {
        this.transform.rotation = pTrans.rotation;
        this.transform.position = pTrans.position + pTrans.forward;
        this.transform.position += new Vector3(0, 0.8f, 0);
    }
}
