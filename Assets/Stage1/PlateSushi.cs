using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSushi : MonoBehaviour
{
    private GameObject player;
    private GameObject timeOut;

    private bool m_bIsDead = false;
    private bool m_bIsHold = false;

    public CoinPlus coinPlus;
    public CoinPlus coinPlusClone;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        timeOut = GameObject.FindWithTag("Timer");
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
            player.GetComponent<Player>().SetPlusCoin(25);
            player.GetComponent<Player>().SetAddCoin(25);

            List<Recipe> recipeListTmp = timeOut.GetComponent<TimeOut>().GetRecipeList();
            if(!recipeListTmp[0].m_bIsClear)
                recipeListTmp[0].m_bIsClear = true;
            // 시간 내에 음식 성공 코인 생성
            coinPlusClone = Instantiate(coinPlus);
            
            // 더러운 접시 or 새접시 생성


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
