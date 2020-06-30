using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSushi : MonoBehaviour
{
    private GameObject player;
    private GameObject timeOut;
    private GameObject plateReturn;

    private bool m_bIsDead = false;
    private bool m_bIsHold = false;

    public CoinPlus coinPlus;
    public CoinPlus coinPlusClone;

    public Plate plate;
    public Plate plateClone;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        timeOut = GameObject.FindWithTag("Timer");
        plateReturn = GameObject.FindWithTag("PlateReturn");
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
            // 시간 내에 음식 성공 코인 생성
            List<Recipe> recipeListTmp = timeOut.GetComponent<TimeOut>().GetRecipeList();
            if(!recipeListTmp[0].m_bIsClear)
            {
                player.GetComponent<Player>().SetPlusCoin(35);
                player.GetComponent<Player>().SetAddCoin(35);
                coinPlusClone = Instantiate(coinPlus);
                recipeListTmp[0].m_bIsClear = true;
            }

            // 더러운 접시 or 새접시 생성
            Vector3 vPlatePos = plateReturn.transform.position;
            vPlatePos.y += 1f;
            plateClone = Instantiate(plate, vPlatePos, Quaternion.identity);
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
