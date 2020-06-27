using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private GameObject player;

    private bool m_bIsHold = false;
    private bool m_bIsDead = false;
    private bool m_bIsOnFood = false;

 //   public void SetIsPlateOnFood(bool bIsOnFood) { m_bIsOnFood = bIsOnFood; }
 //   public bool GetIsPlateOnFood() { return m_bIsOnFood; }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        CollisionFloor();

        if (m_bIsOnFood)
            m_bIsDead = true;

        if (m_bIsHold)
            SetTransform(player.transform);
        //    else
        //        transform.position = this.transform.position;
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
        if (other.gameObject.CompareTag("Player") && !m_bIsDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!m_bIsHold)
                    m_bIsHold = true;
                else
                {
                    m_bIsHold = false;
                    m_bIsOnFood = false;
                }
            }
        }
        else if (other.gameObject.CompareTag("Sushi") && !m_bIsDead)
        {   // 음식이랑 닿았을 때
            m_bIsDead = true;
            //if (other.gameObject.CompareTag("PassCounter") && m_bIsOnFood)
            //{
            //    if(m_bIsOnFood)
            //        player.GetComponent<Player>().SetAddCoin(8);
            //    // 더러운 접시 생성
            //    m_bIsDead = true;
            //}
        }
    }

    void SetTransform(Transform pTrans)
    {
        transform.rotation = pTrans.transform.rotation;
        transform.position = pTrans.position + pTrans.forward;
        transform.position += new Vector3(0, 0.8f, 0);
    }
}
