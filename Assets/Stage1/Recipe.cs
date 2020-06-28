using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    RectTransform rcTrans;

    private Vector3 vUIPos;
    private float fRecipeDestroyTime = 20f;

    [SerializeField]
    public float fAddRecipeX = 0f;
    [SerializeField]
    public bool m_bIsDead = false;

    // 처음에 2개 10초에 하나씩
    private void Awake()
    {
        vUIPos = new Vector3(700f, 363f, 0f);
        this.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
    }

    void Start()
    {
        rcTrans = GetComponent<RectTransform>();
        this.rcTrans.position = vUIPos;
    }

    void Update()
    {
        if (vUIPos.x > fAddRecipeX)
            vUIPos.x -= 600f * Time.deltaTime;
        else
            vUIPos.x = fAddRecipeX;

        this.rcTrans.position = vUIPos;
    }

    void LateUpdate()
    {
        StartCoroutine(DeadRecipe());
    }

    IEnumerator DeadRecipe()
    {
        if (!m_bIsDead)
        {
            yield return new WaitForSeconds(fRecipeDestroyTime);
            m_bIsDead = true;
        }       
    }
}
