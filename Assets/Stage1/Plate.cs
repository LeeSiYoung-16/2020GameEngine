using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private GameObject player;

    private bool m_bIsHold = false;
    private bool m_bIsDead = false;
    private bool m_bIsOnFood = false;

    public void SetIsPlateOnFood(bool bIsOnFood) { m_bIsOnFood = bIsOnFood; }
    public bool GetIsPlateOnFood() { return m_bIsOnFood; }

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
        {
            m_bIsHold = false;
            Destroy(this.gameObject);
        }
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
                { 
                    m_bIsHold = false;
                    m_bIsOnFood = false;
                }
            }
        }
        if (other.gameObject.CompareTag("PassCounter")/* && m_bIsOnFood*/)
        {
            if(m_bIsOnFood)
                player.GetComponent<Player>().SetAddCoin(8);
            // 더러운 접시 생성
            m_bIsDead = true;
        }
    }

    void SetTransform(Transform pTrans)
    {
        transform.rotation = pTrans.transform.rotation;
        transform.position = pTrans.position + pTrans.forward;
        transform.position += new Vector3(0, 0.8f, 0);
    }
}
