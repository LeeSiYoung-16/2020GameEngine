using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSushi : MonoBehaviour
{
    private GameObject player;

    private bool m_bIsDead = false;
    private bool m_bIsHold = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        CollisionFloor();

        if (Input.GetKeyDown(KeyCode.LeftControl) && m_bIsHold)
        {
            m_bIsHold = false;
            // 던지기
        }

        if (m_bIsHold)
            SetTransform(player.transform);
    }

    private void CollisionFloor()
    {
        Vector3 vTempPos = this.transform.position;
        if (vTempPos.y < 0f)
        {
            vTempPos.y = 0f;
            this.transform.position = vTempPos;
        }
    }

    void LateUpdate()
    {
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
        else if (other.gameObject.CompareTag("PassCounter") && !m_bIsHold)
        {   
            // 카운터에 보냈을 때 
            m_bIsDead = true;
            player.GetComponent<Player>().SetAddCoin(8);
            // 더러운 접시 생성

        }
    }

    void SetTransform(Transform pTrans)
    {
        this.transform.rotation = pTrans.rotation;
        this.transform.position = pTrans.position + pTrans.forward;
        this.transform.position += new Vector3(0, 0.8f, 0);
    }
}
