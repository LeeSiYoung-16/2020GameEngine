using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrawnRecipe : MonoBehaviour
{
    RectTransform rcTrans;

    private float fRecipeDestroyTime = 20f;
    private GameObject player;
    public CoinPlus2 coinPlus;
    public CoinPlus2 coinPlusClone;

    [SerializeField] public Vector3 vUIPos;
    [SerializeField] public float fAddRecipeX = 0f;
    [SerializeField] public bool m_bIsDead = false;
    [SerializeField] public bool m_bIsClear = false;
    [SerializeField] public float myWidth = 0f;
    [SerializeField] public float myHeight = 0f;

    public PrawnRecipeIcon prawnrecipeIcon;
    public PrawnRecipeIcon prawnrecipeIconClone;

    private bool m_bIsCoin = false;
    private bool m_bIsAlreadyCoin = false;

    private void Awake()
    {
        vUIPos = new Vector3(Screen.width * 0.5f, Screen.height, 0f);
        this.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
    }

    void Start()
    {
        SetRecipePos();
        player = GameObject.FindWithTag("Player");

        prawnrecipeIconClone = Instantiate(prawnrecipeIcon, transform.position, Quaternion.identity);
        prawnrecipeIconClone.gameObject.SetActive(false);
    }

    private void SetRecipePos()
    {
        rcTrans = GetComponent<RectTransform>();
        myWidth = transform.gameObject.GetComponent<RectTransform>().rect.width;
        myHeight = transform.gameObject.GetComponent<RectTransform>().rect.height;
        vUIPos.y -= myHeight * 0.9f;
        this.rcTrans.position = vUIPos;
    }

    void Update()
    {
        if (vUIPos.x > fAddRecipeX)
            vUIPos.x -= 600f * Time.deltaTime;
        else
        {
            vUIPos.x = fAddRecipeX;
            prawnrecipeIconClone.gameObject.SetActive(true);
        }

        this.rcTrans.position = vUIPos;

        SetIconPos();
    }

    private void SetIconPos()
    {
        float IconX = vUIPos.x + myWidth * 0.3f;
        float IconY = vUIPos.y - myHeight * 1.25f;

        if (!prawnrecipeIconClone.m_bIsDead)
        {
            prawnrecipeIconClone.vUIPos.x = IconX;
            prawnrecipeIconClone.vUIPos.y = IconY;
        }
    }

    void LateUpdate()
    {
        StartCoroutine(DeadRecipe());

        if (m_bIsDead && !m_bIsAlreadyCoin && m_bIsCoin)
        {
            player.GetComponent<Player>().SetPlusCoin(-8);
            player.GetComponent<Player>().SetAddCoin(-8);
            coinPlusClone = Instantiate(coinPlus);
            m_bIsAlreadyCoin = true;
        }

        if (m_bIsDead || m_bIsClear)
            Destroy(this.gameObject);
    }

    IEnumerator DeadRecipe()
    {
        if (!m_bIsDead)
        {
            yield return new WaitForSeconds(fRecipeDestroyTime);
            if (!m_bIsCoin)
                m_bIsCoin = true;
            m_bIsDead = true;
        }
    }
}
